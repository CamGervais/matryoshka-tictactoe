import React, { Component } from 'react';
import { Tile } from "./Tile";
import "./Board.css"

export class Board extends Component {
  constructor(props) {
    super(props);
    this.state = {
      tilePlayers: [0, 0, 0, 0, 0, 0, 0, 0, 0]
    }
    this.play = this.play.bind(this);
    this.restartGame = this.restartGame.bind(this);
  }

  componentDidMount() {
    fetch("/game/", {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json'
      }
    }).then(res => res.json())
      .then(data => {
        this.setState({
          tilePlayers: data.tiles
        })
      })
  }

  play(tileId) {
    fetch("/game/play", {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        "TileIndex": tileId
      })
    }).then(res => {
        if (res.status === 200) { //no then if not 200
          return res.json();
        }
      })
      .then(data => {
        const tilesReplaced = this.state.tilePlayers.map((value, index) => {
          if (index === tileId) {
            return data.currentPlayerId;
          } else {
            return value;
          }
        });
        this.setState({
          tilePlayers: tilesReplaced
        }) //if winner or tie
      })
  }

  restartGame() {
    fetch("/game/", {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json'
      }
    }).then(() => {
      this.setState({
        tilePlayers: [0, 0, 0, 0, 0, 0, 0, 0, 0]
      })
    })
  }

  render() {
    return (
      <div>
        <div className="tileBoard">
          <div className="tileFirstRow" >
            <div id="tile0" onClick={() => this.play(0)}>
              <Tile player={this.state.tilePlayers.filter((_, index) => index === 0)} />
            </div>
            <div id="tile1" onClick={() => this.play(1)}>
              <Tile player={this.state.tilePlayers.filter((_, index) => index === 1)} />
            </div>
            <div id="tile2" onClick={() => this.play(2)}>
              <Tile player={this.state.tilePlayers.filter((_, index) => index === 2)} />
            </div>
          </div>
          <div className="tileSecondRow">
            <div id="tile3" onClick={() => this.play(3)}>
              <Tile player={this.state.tilePlayers.filter((_, index) => index === 3)} />
            </div>
            <div id="tile4" onClick={() => this.play(4)}>
              <Tile player={this.state.tilePlayers.filter((_, index) => index === 4)} />
            </div>
            <div id="tile5" onClick={() => this.play(5)}>
              <Tile player={this.state.tilePlayers.filter((_, index) => index === 5)} />
            </div>
          </div>
          <div className="tileThirdRow">
            <div id="tile6" onClick={() => this.play(6)}>
              <Tile player={this.state.tilePlayers.filter((_, index) => index === 6)} />
            </div>
            <div id="tile7" onClick={() => this.play(7)}>
              <Tile player={this.state.tilePlayers.filter((_, index) => index === 7)} />
            </div>
            <div id="tile8" onClick={() => this.play(8)}>
              <Tile player={this.state.tilePlayers.filter((_, index) => index === 8)} />
            </div>
          </div>
        </div>

        <button onClick={() => this.restartGame()}>Restart game</button>
      </div>
      
    )
  }
}
