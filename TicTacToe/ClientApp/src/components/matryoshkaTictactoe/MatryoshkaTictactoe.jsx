import React from 'react';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';
import { RegularTictactoe } from '../regularTictactoe/RegularTictactoe';
import { MatryoshkaBoard } from './MatryoshkaBoard';
import "../regularTictactoe/style/RegularTictactoe.css"

export class MatryoshkaTictactoe extends RegularTictactoe {
  constructor(props) {
    super(props);
    this.state = {
      tilesPlayers: [0, 0, 0, 0, 0, 0, 0, 0, 0],
      status: "",
      boardType: "matryoshka",
      usesComputer: false,
      gameStarted: false
    }
    this.setStatus = this.setStatus.bind(this);
    this.setTiles = this.setTiles.bind(this);
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
        <div className="board">
          <div className="textLines">
            {statusMessage}
          </div>
          <MatryoshkaBoard setStatus={this.setStatus} setTiles={this.setTiles}
            status={this.state.status} tilesPlayers={this.state.tilesPlayers} usesComputer={this.state.usesComputer}>
          </MatryoshkaBoard>
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
              <Input type="checkbox" className="checkboxes" onChange={e => this.updateUsesComputerValue(e)} />
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