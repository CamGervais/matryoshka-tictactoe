import React, { Component } from 'react';
import baseTile from "../assets/tile.png"
import oTile from "../assets/O.png"
import oDiagonalLeft from "../assets/O_diagonal_left_win.png"
import oDiagonalRight from "../assets/O_diagonal_right_win.png" 
import oHorizontal from "../assets/O_horizontal_win.png"
import oVertical from "../assets/O_vertical_win.png"
import xTile from "../assets/X.png"
import xDiagonalLeft from "../assets/X_diagonal_left_win.png"
import xDiagonalRight from "../assets/X_diagonal_right_win.png"
import xHorizontal from "../assets/X_horizontal_win.png"
import xVertical from "../assets/X_vertical_win.png"
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
    else if (this.props.player == 3) {
      tileImage = <img src={xHorizontal} alt="X tile horizontal win" className="singleTile" />
    }
    else if (this.props.player == 4) {
      tileImage = <img src={oHorizontal} alt="O tile horizontal win" className="singleTile" />
    }
    else if (this.props.player == 5) {
      tileImage = <img src={xVertical} alt="X tile vertical win" className="singleTile" />
    }
    else if (this.props.player == 6) {
      tileImage = <img src={oVertical} alt="O tile vertical win" className="singleTile" />
    }
    else if (this.props.player == 7) {
      tileImage = <img src={xDiagonalLeft} alt="X tile diagonal left win" className="singleTile" />
    }
    else if (this.props.player == 8) {
      tileImage = <img src={oDiagonalLeft} alt="O tile diagonal left win" className="singleTile" />
    }
    else if (this.props.player == 9) {
      tileImage = <img src={xDiagonalRight} alt="X tile diagonal right win" className="singleTile" />
    }
    else if (this.props.player == 10) {
      tileImage = <img src={oDiagonalRight} alt="O tile diagonal right win" className="singleTile" />
    }

    return (
      <div>
        {tileImage}
      </div>
    )
  }
}