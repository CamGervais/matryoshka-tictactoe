import React, { Component } from 'react';
import { MatryoshkaPieces } from './MatryoshkaPieces';
import { MatryoshkaTile } from "./MatryoshkaTile";
import "./style/MatryoshkaBoard.css"

export class MatryoshkaBoard extends Component {
  constructor(props) {
    super(props);
    this.state = {
      draggableSquarePieces: [0, 0, 0, 0, 0, 0],
      draggableCirclePieces: [1, 1, 1, 1, 1, 1]
    }
    this.play = this.play.bind(this);
  }

  play(tileId, pieceSize, pieceIndex, pieceShape) {
    if (this.props.status.toLowerCase() == "ongoing") {
      fetch("/game/human", {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          "tileIndex": tileId,
          "playedElement": pieceSize
        })
      }).then(res => {
        if (res.status === 200) {
          return res.json();
        }
      })
        .then(data => {
          if (data != undefined) {
            this.props.setTiles(data.currentBoard);
            this.props.setStatus(data.gameStatus);

            if (pieceShape == "square") {
              const newDraggableSquarePieces = this.state.draggableSquarePieces.map((pieceValue, index) => {
                if (index == pieceIndex) {
                  return 2;
                }
                else if (pieceValue === 0) {
                  return 1;
                }
                else {
                  return pieceValue;
                }
              });
              const newDraggableCirclePieces = this.state.draggableCirclePieces.map((pieceValue, _) => {
                if (pieceValue === 1) {
                  return 0;
                }
                else {
                  return pieceValue;
                }
              });
              this.setState({
                draggableSquarePieces: newDraggableSquarePieces,
                draggableCirclePieces: newDraggableCirclePieces
              });
            }

            else if (pieceShape == "circle") {
              const newDraggableCirclePieces = this.state.draggableCirclePieces.map((pieceValue, index) => {
                if (index == pieceIndex) {
                  return 2;
                }
                else if (pieceValue === 0) {
                  return 1;
                }
                else {
                  return pieceValue;
                }
              });
              const newDraggableSquarePieces = this.state.draggableSquarePieces.map((pieceValue, _) => {
                if (pieceValue === 1) {
                  return 0;
                }
                else {
                  return pieceValue;
                }
              });
              this.setState({
                draggableSquarePieces: newDraggableSquarePieces,
                draggableCirclePieces: newDraggableCirclePieces
              });
            }
          }

          if (this.props.usesComputer && data.gameStatus.toLowerCase() == "ongoing") {
            this.computerPlay();
          }
        })
    }
  }

  computerPlay() {
    fetch("/game/computer", {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
    }).then(res => {
      if (res.status === 200) {
        return res.json();
      }
    })
      .then(data => {
        if (data != undefined) {
          this.props.setTiles(data.currentBoard);
          this.props.setStatus(data.gameStatus);
        }
      })
  }

  handleDropPiece(e, tileIndex) {
    e.preventDefault();
    const pieceSize = e.dataTransfer.getData("pieceSize");
    const pieceIndex = e.dataTransfer.getData("pieceIndex");
    const pieceShape = e.dataTransfer.getData("pieceShape");
    this.play(tileIndex, pieceSize, pieceIndex, pieceShape);
  }

  render() {
    return (
      <div className="boardArea">
        <MatryoshkaPieces shape="square" draggablePieces={this.state.draggableSquarePieces}></MatryoshkaPieces>
        <div className="tileBoard">
          <div className="tileFirstRow" >
            <div id="tile0" onDrop={(e) => this.handleDropPiece(e, 0)} onDragOver={(e) => e.preventDefault()}>
              <MatryoshkaTile player={this.props.tilesPlayers[0]} />
            </div>
            <div id="tile1" onDrop={(e) => this.handleDropPiece(e, 1)} onDragOver={(e) => e.preventDefault()}>
              <MatryoshkaTile player={this.props.tilesPlayers[1]} />
            </div>
            <div id="tile2" onDrop={(e) => this.handleDropPiece(e, 2)} onDragOver={(e) => e.preventDefault()}>
              <MatryoshkaTile player={this.props.tilesPlayers[2]} />
            </div>
          </div>
          <div className="tileSecondRow">
            <div id="tile3" onDrop={(e) => this.handleDropPiece(e, 3)} onDragOver={(e) => e.preventDefault()}>
              <MatryoshkaTile player={this.props.tilesPlayers[3]} />
            </div>
            <div id="tile4" onDrop={(e) => this.handleDropPiece(e, 4)} onDragOver={(e) => e.preventDefault()}>
              <MatryoshkaTile player={this.props.tilesPlayers[4]} />
            </div>
            <div id="tile5" onDrop={(e) => this.handleDropPiece(e, 5)} onDragOver={(e) => e.preventDefault()}>
              <MatryoshkaTile player={this.props.tilesPlayers[5]} />
            </div>
          </div>
          <div className="tileThirdRow">
            <div id="tile6" onDrop={(e) => this.handleDropPiece(e, 6)} onDragOver={(e) => e.preventDefault()}>
              <MatryoshkaTile player={this.props.tilesPlayers[6]} />
            </div>
            <div id="tile7" onDrop={(e) => this.handleDropPiece(e, 7)} onDragOver={(e) => e.preventDefault()}>
              <MatryoshkaTile player={this.props.tilesPlayers[7]} />
            </div>
            <div id="tile8" onDrop={(e) => this.handleDropPiece(e, 8)} onDragOver={(e) => e.preventDefault()}>
              <MatryoshkaTile player={this.props.tilesPlayers[8]} />
            </div>
          </div>
        </div>
        <MatryoshkaPieces shape="circle" draggablePieces={this.state.draggableCirclePieces}></MatryoshkaPieces>
      </div>
    )
  }
}
