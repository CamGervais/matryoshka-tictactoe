import React, { Component } from 'react';
import baseTile from "../../assets/matryoshkaTictactoe/tile.png"
import squareBig from "../../assets/matryoshkaTictactoe/square_big.png";
import "../regularTictactoe/style/RegularTile.css"

export class MatryoshkaTile extends Component {
  render() {
    let tileImage = <img src={baseTile} alt="Empty tile" className="singleTile" />
    const player = this.props.player;
    if (player != 0) {
      tileImage = <img src={squareBig} alt="Big square tile" className="singleTile" />
    }

    return (
      <div>
        {tileImage}
      </div>
    )
  }
}