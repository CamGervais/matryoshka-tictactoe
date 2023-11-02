import React, { Component } from 'react';
import baseTile from "../assets/tile.png"
import xTile from "../assets/X.png"
import oTile from "../assets/O.png"
import "./Tile.css"

export class Tile extends Component {
  render() {
    let tileImage = <img src={baseTile} alt="Empty tile" className="singleTile" />
    if (this.props.player == 1) {
      tileImage = <img src={xTile} alt="X tile" className="singleTile" />
    }
    else if (this.props.player == 2) {
      tileImage = <img src={oTile} alt="O tile" className="singleTile" />
    }

    return (
      <div>
        {tileImage}
      </div>
    )
  }
}