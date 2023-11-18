import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import oTile from "../../assets/regularTictactoe/O.png"

export class Home extends Component {
  render() {
    let usesComputer = true;
    return (
      <div>
        <Link to="/regular-tic-tac-toe"> 
          <img src={oTile} alt="Start regular Tic-tac-toe game" />
        </Link>
        <Link to="/matryoshka-tic-tac-toe">
          <img src={oTile} alt="Start matryoshka Tic-tac-toe game" />
        </Link>
      </div>
    )
  }
}