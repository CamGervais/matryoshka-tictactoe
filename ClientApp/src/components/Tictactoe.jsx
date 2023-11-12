import React, { Component } from 'react';
import { Board } from './Board';
export class Tictactoe extends Component {
  constructor(props) {
    super(props);
    this.state = {
      tilesPlayers: [0, 0, 0, 0, 0, 0, 0, 0, 0],
      winner: 0,
      draw: false
    }
    this.restartGame = this.restartGame.bind(this);
    this.setWinner = this.setWinner.bind(this);
    this.setDraw = this.setDraw.bind(this);
    this.setTiles = this.setTiles.bind(this);
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
          tilesPlayers: data.tiles,
          winner: data.winner,
          draw: data.draw
        })
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
        tilesPlayers: [0, 0, 0, 0, 0, 0, 0, 0, 0],
        winner: 0,
        draw: false
      })
    })
  }

  setWinner(newWinner) {
    this.setState({
      winner: newWinner
    })
  }

  setDraw(isDraw) {
    this.setState({
      draw: isDraw
    })
  }

  setTiles(newTiles) {
    this.setState({
      tilesPlayers: newTiles
    })
  }

  render() {
    let drawMessage = "";
    if (this.state.draw) {
      drawMessage = "It's a draw!";
    }

    let winnerMessage = "";
    if (this.state.winner != 0) {
      winnerMessage = `Player ${this.state.winner} wins!`;
    }

    return (
      <div>
        {drawMessage}
        {winnerMessage}
        <Board setWinner={this.setWinner} setDraw={this.setDraw} setTiles={this.setTiles}
          winner={this.state.winner} draw={this.state.draw} tilesPlayers={this.state.tilesPlayers}></Board>
        <button onClick={() => this.restartGame()}>Restart game</button>
      </div>

    )
  }
}