import React, { Component } from 'react';
import squareBig from "../../assets/matryoshkaTictactoe/square_big.png";
import squareMiddle from "../../assets/matryoshkaTictactoe/square_middle.png";
import squareSmall from "../../assets/matryoshkaTictactoe/square_small.png";
import circleBig from "../../assets/matryoshkaTictactoe/circle_big.png";
import circleMiddle from "../../assets/matryoshkaTictactoe/circle_middle.png";
import circleSmall from "../../assets/matryoshkaTictactoe/circle_small.png";
import squareBigGrey from "../../assets/matryoshkaTictactoe/square_big_grey.png";
import squareMiddleGrey from "../../assets/matryoshkaTictactoe/square_middle_grey.png";
import squareSmallGrey from "../../assets/matryoshkaTictactoe/square_small_grey.png";
import circleBigGrey from "../../assets/matryoshkaTictactoe/circle_big_grey.png";
import circleMiddleGrey from "../../assets/matryoshkaTictactoe/circle_middle_grey.png";
import circleSmallGrey from "../../assets/matryoshkaTictactoe/circle_small_grey.png";
import "./style/MatryoshkaPieces.css"

export class MatryoshkaPieces extends Component {
  handleDragStart(e, pieceSize, pieceIndex) {
    e.dataTransfer.setData("pieceSize", pieceSize);
    e.dataTransfer.setData("pieceIndex", pieceIndex);
    e.dataTransfer.setData("pieceShape", this.props.shape);
  }

  render() {
    if (this.props.shape == "square") {
      return (
        <div>
          <img draggable={this.props.draggablePieces[0] == 0} onDragStart={(e) => this.handleDragStart(e, 3, 0)}
            src={this.props.draggablePieces[0] == 0 ? squareBig : squareBigGrey}
            alt="Big square playable piece" className="piece" />
          <img draggable={this.props.draggablePieces[1] == 0} onDragStart={(e) => this.handleDragStart(e, 3, 1)}
            src={this.props.draggablePieces[1] == 0 ? squareBig : squareBigGrey}
            alt="Big square playable piece" className="piece" />
          <img draggable={this.props.draggablePieces[2] == 0} onDragStart={(e) => this.handleDragStart(e, 2, 2)}
            src={this.props.draggablePieces[2] == 0 ? squareMiddle : squareMiddleGrey}
            alt="Middle square playable piece" className="piece" />
          <img draggable={this.props.draggablePieces[3] == 0} onDragStart={(e) => this.handleDragStart(e, 2, 3)}
            src={this.props.draggablePieces[3] == 0 ? squareMiddle : squareMiddleGrey}
            alt="Middle square playable piece" className="piece" />
          <img draggable={this.props.draggablePieces[4] == 0} onDragStart={(e) => this.handleDragStart(e, 1, 4)}
            src={this.props.draggablePieces[4] == 0 ? squareSmall : squareSmallGrey}
            alt="Small square playable piece" className="piece" />
          <img draggable={this.props.draggablePieces[5] == 0} onDragStart={(e) => this.handleDragStart(e, 1, 5)}
            src={this.props.draggablePieces[5] == 0 ? squareSmall : squareSmallGrey}
            alt="Small square playable piece" className="piece" />
        </div>
      )
    }

    else if (this.props.shape == "circle") {
      return (
        <div>
          <img draggable={this.props.draggablePieces[0] == 0} onDragStart={(e) => this.handleDragStart(e, 3, 0)}
            src={this.props.draggablePieces[0] == 0 ? circleBig : circleBigGrey}
            alt="Big circle playable piece" className="piece" />
          <img draggable={this.props.draggablePieces[1] == 0} onDragStart={(e) => this.handleDragStart(e, 3, 1)}
            src={this.props.draggablePieces[1] == 0 ? circleBig : circleBigGrey}
            alt="Big circle playable piece" className="piece" />
          <img draggable={this.props.draggablePieces[2] == 0} onDragStart={(e) => this.handleDragStart(e, 2, 2)}
            src={this.props.draggablePieces[2] == 0 ? circleMiddle : circleMiddleGrey}
            alt="Middle circle playable piece" className="piece" />
          <img draggable={this.props.draggablePieces[3] == 0} onDragStart={(e) => this.handleDragStart(e, 2, 3)}
            src={this.props.draggablePieces[3] == 0 ? circleMiddle : circleMiddleGrey}
            alt="Middle circle playable piece" className="piece" />
          <img draggable={this.props.draggablePieces[4] == 0} onDragStart={(e) => this.handleDragStart(e, 1, 4)}
            src={this.props.draggablePieces[4] == 0 ? circleSmall : circleSmallGrey}
            alt="Small circle playable piece" className="piece" />
          <img draggable={this.props.draggablePieces[5] == 0} onDragStart={(e) => this.handleDragStart(e, 1, 5)}
            src={this.props.draggablePieces[5] == 0 ? circleSmall : circleSmallGrey}
            alt="Small circle playable piece" className="piece" />
        </div>
      )
    }
  }
}