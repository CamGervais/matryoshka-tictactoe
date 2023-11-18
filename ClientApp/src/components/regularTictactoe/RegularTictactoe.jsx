import React, { Component } from 'react';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';
import { RegularBoard } from './RegularBoard';

export class RegularTictactoe extends Component {
  constructor(props) {
    super(props);
    this.state = {
      tilesPlayers: [0, 0, 0, 0, 0, 0, 0, 0, 0],
      status: "",
      usesComputer: false,
      gameStarted: false
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
        "boardType": "regular",
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
        "boardType": "regular",
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
      status: newStatus
    })
  }

  setTiles(newTiles) {
    this.setState({
      tilesPlayers: newTiles
    })
  }

  updateUsesComputerValue(e) {
    this.setState({
      usesComputer: e.target.checked
    })
  }

  render() {
    if (this.state.gameStarted) {
      let statusMessage = "";
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
        <div>
          {statusMessage}
          <RegularBoard setStatus={this.setStatus} setTiles={this.setTiles}
            status={this.state.status} tilesPlayers={this.state.tilesPlayers} usesComputer={this.state.usesComputer}>
          </RegularBoard>
          <Button color="primary" onClick={() => this.restartGame()}>Restart game</Button>
        </div>
      )
    }
    else {
      return (
        <div>
          <Form>
            <FormGroup
              check
              inline
            >
              <Input type="checkbox" onChange={e => this.updateUsesComputerValue(e)} />
              <Label check>
                Play against computer
              </Label>
            </FormGroup>
          </Form>
          <Button color="primary" onClick={() => this.startGame()}>Start game</Button>
        </div>
      )
    }
  }
}