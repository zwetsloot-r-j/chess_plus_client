﻿namespace ChessPlus

module Movements =
  open Finders
  open Fetchers
  open Updaters
  open Option
  open Types
  
  let (<*>) = Option.apply
  
  let private areRuleConditionsMet rule tileSelectionWell =
    match rule with
    | MoveRule { Offset = (-7, 0) } ->
      JsonConversions.RuleDto.export rule |> JsonConversions.export |> Logger.warn
    | _ -> ()
    
    MoveRule.map (fun { Condition = conditions } ->
      Clauses.areMet conditions rule tileSelectionWell
    ) rule
    |> Option.defaultValue (Ok false)
    |> Result.map (Logger.inspect "areConditionsMet?")
    
  let private filterSatisfiedRules rules tileSelectionWell =
    let (<*>) = Result.apply
  
    List.fold (fun acc rule ->
      match acc with
      | Ok r ->
        Ok (fun isSatisfied ->
          if isSatisfied
          then rule::r
          else r
        )
        <*> areRuleConditionsMet rule tileSelectionWell
      | err ->
        err
    ) (Ok List.empty) rules

  let calculateMovableTiles playerColor tileSelectionWell =
    let pieceWell = fetchPieceWell ()
  
    findSelectedTileCoord playerColor tileSelectionWell
    >>= fun coord -> if Pool.Pieces.isPlayerPiece coord pieceWell then Some coord else None
    >>= fun coord -> fetchPieceMovementRules coord <!> (Tuple.retn2 coord)
    <!> fun (coord, rules) -> (coord, filterSatisfiedRules rules tileSelectionWell)
    <!> fun ((r, c), rules) -> ((Row.toInt r, Column.toInt c), rules)
    <!> (fun ((r, c), rules) ->
      rules
      |> Result.map (List.map (MoveRule.map (fun { Offset = (x, y) } ->
        (r + x, c + y)
      )))
      |> Result.map (List.map (Option.defaultValue (0, 0)))
      |> Result.map (fun coordinates -> List.map (Coordinate.fromInt >> Result.toOption) coordinates)
      |> Result.map Option.filter
    )
    |> Option.defaultValue (Ok List.empty)
   
  let resetMovableTiles playerColor tileSelectionWell =
    TileSelections.updateSelectionConquerable playerColor (fun _ -> List.empty) tileSelectionWell
   
  let updateMovableTiles playerColor tileSelectionWell =
    match calculateMovableTiles playerColor tileSelectionWell, Pool.isPlayer playerColor with
    | Ok coords, true ->
      resetMovableTiles playerColor tileSelectionWell
      |> TileSelections.updateSelectionConquerable playerColor (fun _ -> coords)
    | Error e, _ ->
      Logger.warn e
      tileSelectionWell
    | _, _ ->
      tileSelectionWell
    
  let isMovableTile coord well =
    fetchOwnConquerableTileCoords ()
    |> List.contains coord