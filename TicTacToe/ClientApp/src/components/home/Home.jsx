import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import matryoshkaIcon from "../../assets/home/matryoshkaTictactoeIcon.png"
import regularIcon from "../../assets/home/regularTictactoeIcon.png"
import "./style/Home.css"

export class Home extends Component {
  render() {
    return (
      <div className="links">
        <Link to="/regular-tic-tac-toe" > 
          <figure>
            <img src={regularIcon} className="icons" alt="Start regular Tic-tac-toe game" />
            <figcaption className="textLines">Play regular tic-tac-toe game</figcaption>
          </figure>
        </Link>
        <Link to="/matryoshka-tic-tac-toe">
          <figure>
            <img src={matryoshkaIcon} className="icons" alt="Start matryoshka Tic-tac-toe game" />
            <figcaption className="textLines">Play matryoshka tic-tac-toe game</figcaption>
          </figure>
        </Link>
      </div>
    )
  }
}