import React, { Component } from 'react';
import { RegularTile } from "./RegularTile";
import "./style/RegularBoard.css"

export class RegularBoard extends Component {
  constructor(props) {
    super(props);
    this.play = this.play.bind(this);
  }

  play(tileId) {
    if (this.props.status.toLowerCase() == "ongoing") {
      fetch("/game/human", {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          "tileIndex": tileId
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

  render() {
    return (
      <div className="tileBoard">
        <div className="tileFirstRow" >
          <div id="tile0" onClick={() => this.play(0)}>
            <RegularTile player={this.props.tilesPlayers[0]} />
          </div>
          <div id="tile1" onClick={() => this.play(1)}>
            <RegularTile player={this.props.tilesPlayers[1]} />
          </div>
          <div id="tile2" onClick={() => this.play(2)}>
            <RegularTile player={this.props.tilesPlayers[2]} />
          </div>
        </div>
        <div className="tileSecondRow">
          <div id="tile3" onClick={() => this.play(3)}>
            <RegularTile player={this.props.tilesPlayers[3]} />
          </div>
          <div id="tile4" onClick={() => this.play(4)}>
            <RegularTile player={this.props.tilesPlayers[4]} />
          </div>
          <div id="tile5" onClick={() => this.play(5)}>
            <RegularTile player={this.props.tilesPlayers[5]} />
          </div>
        </div>
        <div className="tileThirdRow">
          <div id="tile6" onClick={() => this.play(6)}>
            <RegularTile player={this.props.tilesPlayers[6]} />
          </div>
          <div id="tile7" onClick={() => this.play(7)}>
            <RegularTile player={this.props.tilesPlayers[7]} />
          </div>
          <div id="tile8" onClick={() => this.play(8)}>
            <RegularTile player={this.props.tilesPlayers[8]} />
          </div>
        </div>
      </div>
    )
  }
}
