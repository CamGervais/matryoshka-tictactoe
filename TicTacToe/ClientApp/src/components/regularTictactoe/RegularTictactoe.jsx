﻿import React, { Component } from 'react';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';
import { RegularBoard } from './RegularBoard';
import "./style/RegularTictactoe.css"

export class RegularTictactoe extends Component {
  constructor(props) {
    super(props);
    this.state = {
      tilesPlayers: [0, 0, 0, 0, 0, 0, 0, 0, 0],
      status: "",
      boardType: "regular",
      usesComputer: false,
      gameStarted: false,
      currentPlayer: 1
    }
    this.setStatus = this.setStatus.bind(this);
    this.setTiles = this.setTiles.bind(this);
  }

  startGame() {
    fetch("/game", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        "boardType": this.state.boardType,
        "usesComputer": this.state.usesComputer
      })
    }).then(() => {
        this.setState({
          status: "Ongoing",
          gameStarted: true
        })
      })
  }

  restartGame() {
    fetch("/game", {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        "boardType": this.state.boardType,
        "usesComputer": this.state.usesComputer
      })
    }).then(() => {
        this.setState({
          tilesPlayers: [0, 0, 0, 0, 0, 0, 0, 0, 0],
          status: "Ongoing"
        })
      })
  }

  setStatus(newStatus) {
    this.setState({
      status: newStatus,
      currentPlayer: this.state.currentPlayer == 1 ? 2 : 1
    })
  }

  setTiles(newTiles) {
    this.setState({
      tilesPlayers: newTiles
    })
  }

  setUsesComputerValue(e) {
    this.setState({
      usesComputer: e.target.checked
    })
  }

  render() {
    if (this.state.gameStarted) {
      let statusMessage = `Player ${this.state.currentPlayer} is playing...`;
      if (this.state.status == "Draw") {
        statusMessage = "It's a draw!";
      }
      else if (this.state.status == "Player1Win") {
        statusMessage = "Player 1 wins!";
      }
      else if (this.state.status == "Player2Win") {
        statusMessage = "Player 2 wins!";
      }

      return (
        <div className="board">
          <div className="textLines">
            {statusMessage}
          </div>
          
          <RegularBoard setStatus={this.setStatus} setTiles={this.setTiles}
            status={this.state.status} tilesPlayers={this.state.tilesPlayers} usesComputer={this.state.usesComputer}>
          </RegularBoard>
          <Button className="buttons" color="primary" onClick={() => this.restartGame()}>Restart game</Button>
        </div>
      )
    }
    else {
      return (
        <div className="startGameForm">
          <Form>
            <FormGroup
              check
              inline
            >
              <Input type="checkbox" className="checkboxes" onChange={e => this.setUsesComputerValue(e)} />
              <Label check className="textLines">
                Play against computer
              </Label>
            </FormGroup>
          </Form>
          <Button color="primary" className="buttons" onClick={() => this.startGame()}>Start game</Button>
        </div>
      )
    }
  }
}