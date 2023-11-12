import React, { Component } from 'react';
import { Tile } from "./Tile";
import "./Board.css"

export class Board extends Component {
  constructor(props) {
    super(props);
    this.play = this.play.bind(this);
  }

  play(tileId) {
    if (!this.props.winner && !this.props.draw) {
      fetch("/game/play", {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          "TileIndex": tileId
        })
      }).then(res => {
        if (res.status === 200) {
          return res.json();
        }
      })
        .then(data => {
          if (data != undefined) {
            this.props.setTiles(data.currentBoard);
            if (data.gameWinner != 0) {
              this.props.setWinner(data.gameWinner)
            }
            if (data.draw) {
              this.props.setDraw(true)
            }
          }
        })
    }
  }

  render() {
    return (
      <div className="tileBoard">
        <div className="tileFirstRow" >
          <div id="tile0" onClick={() => this.play(0)}>
            <Tile player={this.props.tilesPlayers.filter((_, index) => index === 0)} />
          </div>
          <div id="tile1" onClick={() => this.play(1)}>
            <Tile player={this.props.tilesPlayers.filter((_, index) => index === 1)} />
          </div>
          <div id="tile2" onClick={() => this.play(2)}>
            <Tile player={this.props.tilesPlayers.filter((_, index) => index === 2)} />
          </div>
        </div>
        <div className="tileSecondRow">
          <div id="tile3" onClick={() => this.play(3)}>
            <Tile player={this.props.tilesPlayers.filter((_, index) => index === 3)} />
          </div>
          <div id="tile4" onClick={() => this.play(4)}>
            <Tile player={this.props.tilesPlayers.filter((_, index) => index === 4)} />
          </div>
          <div id="tile5" onClick={() => this.play(5)}>
            <Tile player={this.props.tilesPlayers.filter((_, index) => index === 5)} />
          </div>
        </div>
        <div className="tileThirdRow">
          <div id="tile6" onClick={() => this.play(6)}>
            <Tile player={this.props.tilesPlayers.filter((_, index) => index === 6)} />
          </div>
          <div id="tile7" onClick={() => this.play(7)}>
            <Tile player={this.props.tilesPlayers.filter((_, index) => index === 7)} />
          </div>
          <div id="tile8" onClick={() => this.play(8)}>
            <Tile player={this.props.tilesPlayers.filter((_, index) => index === 8)} />
          </div>
        </div>
      </div>
    )
  }
}
