import React, { Component } from 'react';
import baseTile from "../../assets/matryoshkaTictactoe/tile.png"
import squareBig from "../../assets/matryoshkaTictactoe/square_big_tile.png";
import squareMiddle from "../../assets/matryoshkaTictactoe/square_middle_tile.png";
import squareSmall from "../../assets/matryoshkaTictactoe/square_small_tile.png";
import squareBigDiagonalLeft from "../../assets/matryoshkaTictactoe/square_big_diagonal_left_win.png";
import squareBigDiagonalRight from "../../assets/matryoshkaTictactoe/square_big_diagonal_right_win.png";
import squareBigHorizontal from "../../assets/matryoshkaTictactoe/square_big_horizontal_win.png";
import squareBigVertical from "../../assets/matryoshkaTictactoe/square_big_vertical_win.png";
import squareMiddleDiagonalLeft from "../../assets/matryoshkaTictactoe/square_middle_diagonal_left_win.png";
import squareMiddleDiagonalRight from "../../assets/matryoshkaTictactoe/square_middle_diagonal_right_win.png";
import squareMiddleHorizontal from "../../assets/matryoshkaTictactoe/square_middle_horizontal_win.png";
import squareMiddleVertical from "../../assets/matryoshkaTictactoe/square_middle_vertical_win.png";
import squareSmallDiagonalLeft from "../../assets/matryoshkaTictactoe/square_small_diagonal_left_win.png";
import squareSmallDiagonalRight from "../../assets/matryoshkaTictactoe/square_small_diagonal_right_win.png";
import squareSmallHorizontal from "../../assets/matryoshkaTictactoe/square_small_horizontal_win.png";
import squareSmallVertical from "../../assets/matryoshkaTictactoe/square_small_vertical_win.png";
import circleBig from "../../assets/matryoshkaTictactoe/circle_big_tile.png";
import circleMiddle from "../../assets/matryoshkaTictactoe/circle_middle_tile.png";
import circleSmall from "../../assets/matryoshkaTictactoe/circle_small_tile.png";
import circleBigDiagonalLeft from "../../assets/matryoshkaTictactoe/circle_big_diagonal_left_win.png";
import circleBigDiagonalRight from "../../assets/matryoshkaTictactoe/circle_big_diagonal_right_win.png";
import circleBigHorizontal from "../../assets/matryoshkaTictactoe/circle_big_horizontal_win.png";
import circleBigVertical from "../../assets/matryoshkaTictactoe/circle_big_vertical_win.png";
import circleMiddleDiagonalLeft from "../../assets/matryoshkaTictactoe/circle_middle_diagonal_left_win.png";
import circleMiddleDiagonalRight from "../../assets/matryoshkaTictactoe/circle_middle_diagonal_right_win.png";
import circleMiddleHorizontal from "../../assets/matryoshkaTictactoe/circle_middle_horizontal_win.png";
import circleMiddleVertical from "../../assets/matryoshkaTictactoe/circle_middle_vertical_win.png";
import circleSmallDiagonalLeft from "../../assets/matryoshkaTictactoe/circle_small_diagonal_left_win.png";
import circleSmallDiagonalRight from "../../assets/matryoshkaTictactoe/circle_small_diagonal_right_win.png";
import circleSmallHorizontal from "../../assets/matryoshkaTictactoe/circle_small_horizontal_win.png";
import circleSmallVertical from "../../assets/matryoshkaTictactoe/circle_small_vertical_win.png";
import "../regularTictactoe/style/RegularTile.css"

export class MatryoshkaTile extends Component {
  render() {
    let tileImage = <img src={baseTile} alt="Empty tile" className="singleTile" />
    const player = this.props.player;
    if (player == 1) {
      tileImage = <img src={squareSmall} alt="Small square tile" className="singleTile" />
    }
    if (player == 2) {
      tileImage = <img src={squareMiddle} alt="Middle square tile" className="singleTile" />
    }
    if (player == 3) {
      tileImage = <img src={squareBig} alt="Big square tile" className="singleTile" />
    }
    if (player == 4) {
      tileImage = <img src={circleSmall} alt="Small circle tile" className="singleTile" />
    }
    if (player == 5) {
      tileImage = <img src={circleMiddle} alt="Middle circle tile" className="singleTile" />
    }
    if (player == 6) {
      tileImage = <img src={circleBig} alt="Big circle tile" className="singleTile" />
    }
    if (player == 7) {
      tileImage = <img src={squareSmallHorizontal} alt="Small square tile horizontal win" className="singleTile" />
    }
    if (player == 8) {
      tileImage = <img src={squareMiddleHorizontal} alt="Middle square tile horizontal win" className="singleTile" />
    }
    if (player == 9) {
      tileImage = <img src={squareBigHorizontal} alt="Big square tile horizontal win" className="singleTile" />
    }
    if (player == 10) {
      tileImage = <img src={circleSmallHorizontal} alt="Small circle tile horizontal win" className="singleTile" />
    }
    if (player == 11) {
      tileImage = <img src={circleMiddleHorizontal} alt="Middle circle tile horizontal win" className="singleTile" />
    }
    if (player == 12) {
      tileImage = <img src={circleBigHorizontal} alt="Big circle tile horizontal win" className="singleTile" />
    }
    if (player == 13) {
      tileImage = <img src={squareSmallVertical} alt="Small square tile vertical win" className="singleTile" />
    }
    if (player == 14) {
      tileImage = <img src={squareMiddleVertical} alt="Middle square tile vertical win" className="singleTile" />
    }
    if (player == 15) {
      tileImage = <img src={squareBigVertical} alt="Big square tile vertical win" className="singleTile" />
    }
    if (player == 16) {
      tileImage = <img src={circleSmallVertical} alt="Small circle tile vertical win" className="singleTile" />
    }
    if (player == 17) {
      tileImage = <img src={circleMiddleVertical} alt="Middle circle tile vertical win" className="singleTile" />
    }
    if (player == 18) {
      tileImage = <img src={circleBigVertical} alt="Big circle tile vertical win" className="singleTile" />
    }
    if (player == 19) {
      tileImage = <img src={squareSmallDiagonalLeft} alt="Small square tile diagonal left win" className="singleTile" />
    }
    if (player == 20) {
      tileImage = <img src={squareMiddleDiagonalLeft} alt="Middle square tile diagonal left win" className="singleTile" />
    }
    if (player == 21) {
      tileImage = <img src={squareBigDiagonalLeft} alt="Big square tile diagonal left win" className="singleTile" />
    }
    if (player == 22) {
      tileImage = <img src={circleSmallDiagonalLeft} alt="Small circle tile diagonal left win" className="singleTile" />
    }
    if (player == 23) {
      tileImage = <img src={circleMiddleDiagonalLeft} alt="Middle circle tile diagonal left win" className="singleTile" />
    }
    if (player == 24) {
      tileImage = <img src={circleBigDiagonalLeft} alt="Big circle tile diagonal left win" className="singleTile" />
    }
    if (player == 25) {
      tileImage = <img src={squareSmallDiagonalRight} alt="Small square tile diagonal right win" className="singleTile" />
    }
    if (player == 26) {
      tileImage = <img src={squareMiddleDiagonalRight} alt="Middle square tile diagonal right win" className="singleTile" />
    }
    if (player == 27) {
      tileImage = <img src={squareBigDiagonalRight} alt="Big square tile diagonal right win" className="singleTile" />
    }
    if (player == 28) {
      tileImage = <img src={circleSmallDiagonalRight} alt="Small circle tile diagonal right win" className="singleTile" />
    }
    if (player == 29) {
      tileImage = <img src={circleMiddleDiagonalRight} alt="Middle circle tile diagonal right win" className="singleTile" />
    }
    if (player == 30) {
      tileImage = <img src={circleBigDiagonalRight} alt="Big circle tile diagonal right win" className="singleTile" />
    }

    return (
      <div>
        {tileImage}
      </div>
    )
  }
}