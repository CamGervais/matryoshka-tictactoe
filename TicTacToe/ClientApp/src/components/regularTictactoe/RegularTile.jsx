import React, { Component } from 'react';
import baseTile from "../../assets/regularTictactoe/tile.png"
import oTile from "../../assets/regularTictactoe/O.png"
import oDiagonalLeft from "../../assets/regularTictactoe/O_diagonal_left_win.png"
import oDiagonalRight from "../../assets/regularTictactoe/O_diagonal_right_win.png" 
import oHorizontal from "../../assets/regularTictactoe/O_horizontal_win.png"
import oVertical from "../../assets/regularTictactoe/O_vertical_win.png"
import xTile from "../../assets/regularTictactoe/X.png"
import xDiagonalLeft from "../../assets/regularTictactoe/X_diagonal_left_win.png"
import xDiagonalRight from "../../assets/regularTictactoe/X_diagonal_right_win.png"
import xHorizontal from "../../assets/regularTictactoe/X_horizontal_win.png"
import xVertical from "../../assets/regularTictactoe/X_vertical_win.png"
import "./style/RegularTile.css"

export class RegularTile extends Component {
  render() {
    let tileImage = <img src={baseTile} alt="Empty tile" className="singleTile" />
    const player = this.props.player;
    if (player == 1) {
      tileImage = <img src={xTile} alt="X tile" className="singleTile" />
    }
    else if (player == 2) {
      tileImage = <img src={oTile} alt="O tile" className="singleTile" />
    }
    else if (player == 3) {
      tileImage = <img src={xHorizontal} alt="X tile horizontal win" className="singleTile" />
    }
    else if (player == 4) {
      tileImage = <img src={oHorizontal} alt="O tile horizontal win" className="singleTile" />
    }
    else if (player == 5) {
      tileImage = <img src={xVertical} alt="X tile vertical win" className="singleTile" />
    }
    else if (player == 6) {
      tileImage = <img src={oVertical} alt="O tile vertical win" className="singleTile" />
    }
    else if (player == 7) {
      tileImage = <img src={xDiagonalLeft} alt="X tile diagonal left win" className="singleTile" />
    }
    else if (player == 8) {
      tileImage = <img src={oDiagonalLeft} alt="O tile diagonal left win" className="singleTile" />
    }
    else if (player == 9) {
      tileImage = <img src={xDiagonalRight} alt="X tile diagonal right win" className="singleTile" />
    }
    else if (player == 10) {
      tileImage = <img src={oDiagonalRight} alt="O tile diagonal right win" className="singleTile" />
    }

    return (
      <div>
        {tileImage}
      </div>
    )
  }
}