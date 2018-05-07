﻿namespace ChessPlus

module Waves =
  open Well
  
  type DefaultAmplitude = unit
  
  type UpdateTcpConnectionAmplitude = { Connected : bool }
  let updateTcpConnectionLocation = ("connection", "tcp")
  let updateTcpConnectionWave amplitude = (updateTcpConnectionLocation, amplitude)
  
  type UpdateUdpConnectionAmplitude = { Connected : bool }
  let updateUdpConnectionLocation = ("connection", "udp")
  let updateUdpConnectionWave amplitude = (updateUdpConnectionLocation, amplitude)
  
  type AddTileAmplitude = { Coordinate : Coordinate; Tile : Tile }
  let addTileLocation = ("tile", "add")
  let addTileWave amplitude = (addTileLocation, amplitude)
  
  let requireLoginLocation = ("player", "in")
  let requireLoginWave amplitude = (requireLoginLocation, amplitude)
  
  type LoginAmplitude = { Name : Name }
  let loginLocation = ("player", "join")
  let loginWave amplitude = (loginLocation, amplitude)
  
  type PlayerCreatedAmplitude = { Player : Player }
  let playerCreatedLocation = ("player", "created")
  let playerCreatedWave amplitude = (playerCreatedLocation, amplitude)
  
  type ConfirmLoginAmplitude = { Player : Player }
  let confirmLoginLocation = ("player", "add")
  let confirmLoginWave amplitude = (confirmLoginLocation, amplitude)
  
  type FailedLoginAmplitude = { Reason : string }
  let failedLoginLocation = ("player", "error")
  let failedLoginWave amplitude = (failedLoginLocation, amplitude)
  
  type ReportFailureAmplitude = { Reason : string }
  let reportFailureLocation = ("global", "error")
  let reportFailureWave amplitude = (reportFailureLocation, amplitude)
  
  type NewDuelAmplitude = { Map : Territory }
  let newDuelLocation = ("duel", "new")
  let newDuelWave amplitude = (newDuelLocation, amplitude)
  
  type StartDuelAmplitude = { Duel : Duel }
  let startDuelLocation = ("duel", "add")
  let startDuelWave amplitude = (startDuelLocation, amplitude)
  
  type JoinDuelAmplitude = { Player : Player; ID : string }
  let joinDuelLocation = ("duelist", "join")
  let joinDuelWave amplitude = (joinDuelLocation, amplitude)
  
  type AddDuelistAmplitude = { Duelist : Duelist }
  let addDuelistLocation = ("duelist", "add")
  let addDuelistWave amplitude = (addDuelistLocation, amplitude)
  
  type SetupBoardAmplitude = { Board : Board }
  let setupBoardLocation = ("board", "start")
  let setupBoardWave amplitude = (setupBoardLocation, amplitude)
  
  type AddPieceAmplitude = { Piece : Pieces; Coordinate : Coordinate }
  let addPieceLocation = ("piece", "add")
  let addPieceWave amplitude = (addPieceLocation, amplitude)
  
  type RemovePieceAmplitude = { Coordinate : Coordinate }
  let removePieceLocation = ("piece", "remove")
  let removePieceWave amplitude = (removePieceLocation, amplitude)
  
  type MovePieceAmplitude = { Piece : Pieces; From : Coordinate; To : Coordinate }
  let movePieceLocation = ("piece", "move")
  let movePieceWave amplitude = (movePieceLocation, amplitude)
  
  type ConquerTileAmplitude = { Piece : Pieces; From : Coordinate; To : Coordinate }
  let conquerTileLocation = ("piece", "conquer")
  let conquerTileWave amplitude = (conquerTileLocation, amplitude)
  
  type SelectTileAmplitude = { Player : Color; Coordinate : Coordinate }
  let selectTileLocation = ("tile", "confirm_select")
  let selectTileWave amplitude = (selectTileLocation, amplitude)
  
  type SelectClientTileAmplitude = { Coordinate : Coordinate }
  let selectClientTileLocation = ("tile", "select")
  let selectClientTileWave amplitude = (selectClientTileLocation, amplitude)
  
  type DeselectTileAmplitude = { Player : Color }
  let deselectTileLocation = ("tile", "deselect")
  let deselectTileWave amplitude = (deselectTileLocation, amplitude)

  type Amplitude =
  | DefaultAmplitude of DefaultAmplitude
  | UpdateTcpConnectionAmplitude of UpdateTcpConnectionAmplitude
  | UpdateUdpConnectionAmplitude of UpdateUdpConnectionAmplitude
  | AddTileAmplitude of AddTileAmplitude
  | LoginAmplitude of LoginAmplitude
  | PlayerCreatedAmplitude of PlayerCreatedAmplitude
  | ConfirmLoginAmplitude of ConfirmLoginAmplitude
  | FailedLoginAmplitude of FailedLoginAmplitude
  | ReportFailureAmplitude of ReportFailureAmplitude
  | NewDuelAmplitude of NewDuelAmplitude
  | StartDuelAmplitude of StartDuelAmplitude
  | JoinDuelAmplitude of JoinDuelAmplitude
  | AddDuelistAmplitude of AddDuelistAmplitude
  | SetupBoardAmplitude of SetupBoardAmplitude
  | AddPieceAmplitude of AddPieceAmplitude
  | RemovePieceAmplitude of RemovePieceAmplitude
  | MovePieceAmplitude of MovePieceAmplitude
  | ConquerTileAmplitude of ConquerTileAmplitude
  | SelectClientTileAmplitude of SelectClientTileAmplitude
  | SelectTileAmplitude of SelectTileAmplitude
  | DeselectTileAmplitude of DeselectTileAmplitude
  