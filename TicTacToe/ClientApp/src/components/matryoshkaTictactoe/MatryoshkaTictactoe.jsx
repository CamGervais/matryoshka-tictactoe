import React from 'react';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';
import { RegularTictactoe } from '../regularTictactoe/RegularTictactoe';
import { MatryoshkaBoard } from './MatryoshkaBoard';
import helpGifPlace from "../../assets/matryoshkaTictactoe/help_1.gif";
import helpGifCover from "../../assets/matryoshkaTictactoe/help_2.gif";
import helpGifWin from "../../assets/matryoshkaTictactoe/help_3.gif";
import "./style/MatryoshkaTictactoe.css"

export class MatryoshkaTictactoe extends RegularTictactoe {
  constructor(props) {
    super(props);
    this.state = {
      tilesPlayers: [0, 0, 0, 0, 0, 0, 0, 0, 0],
      draggableSquarePieces: [0, 0, 0, 0, 0, 0],
      draggableCirclePieces: [1, 1, 1, 1, 1, 1],
      status: "",
      boardType: "matryoshka",
      usesComputer: false,
      gameStarted: false,
      currentPlayer: 1
    }
    this.setStatus = this.setStatus.bind(this);
    this.setTiles = this.setTiles.bind(this);
    this.setDraggableSquarePieces = this.setDraggableSquarePieces.bind(this);
    this.setDraggableCirclePieces = this.setDraggableCirclePieces.bind(this);
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
        draggableSquarePieces: [0, 0, 0, 0, 0, 0],
        draggableCirclePieces: [1, 1, 1, 1, 1, 1],
        status: "Ongoing"
      })
    })
  }

  setDraggableSquarePieces(newDraggableSquarePieces) {
    this.setState({
      draggableSquarePieces: newDraggableSquarePieces
    })
  }

  setDraggableCirclePieces(newDraggableCirclePieces) {
    this.setState({
      draggableCirclePieces: newDraggableCirclePieces
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
          <MatryoshkaBoard setStatus={this.setStatus} setTiles={this.setTiles}
            setDraggableSquarePieces={this.setDraggableSquarePieces} setDraggableCirclePieces={this.setDraggableCirclePieces}
            status={this.state.status} tilesPlayers={this.state.tilesPlayers} usesComputer={this.state.usesComputer}
            draggableSquarePieces={this.state.draggableSquarePieces} draggableCirclePieces={this.state.draggableCirclePieces}>
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
              <Input type="checkbox" className="checkboxes" onChange={e => this.setUsesComputerValue(e)} />
              <Label check className="textLines">
                Play against computer
              </Label>
            </FormGroup>
          </Form>
          <Button color="primary" className="buttons" onClick={() => this.startGame()}>Start game</Button>
          <div className="helpText">
            <div className="helpTitle">How to play</div>
            <div className="helpElement">Drag and drop the piece you want to play onto the board tile of your choice.</div>
            <img src={helpGifPlace} alt="Place piece gif" className="helpElement" />
            <div className="helpElement">Like you would with matryoshka dolls, you can cover one of the other player's pieces by one of yours by placing a piece that is bigger than theirs over it.</div>
            <img src={helpGifCover} alt="Cover piece gif" className="helpElement" />
            <div className="helpElement">Win by getting three of your pieces in a row, just like regular Tic-tac-toe!</div>
            <img src={helpGifWin} alt="Win game gif" className="helpElement" />
          </div>
        </div>
      )
    }
  }
}