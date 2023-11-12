using TicTacToe.WepApi.Domain.Dto;

namespace TicTacToe.WepApi.Domain
{
    public class Game
    {
        private Board board;
        private int currentPlayerId;
        private int winner;
        private bool isDraw;

        public Game()
        {
            board = new Board();
            currentPlayerId = 1;
            winner = 0;
            isDraw = false;
        }

        public GetGameStatusResponse GetGameStatus()
        {
            return new GetGameStatusResponse(board.GetTiles(), winner, isDraw);
        }

        public PlayMoveResponse Play(int tileIndex)
        {
            PlayMoveResponse playMoveResponse = board.Play(currentPlayerId, tileIndex);
            if (playMoveResponse.gameWinner != 0)
            {
                winner = currentPlayerId;
            }
            if (playMoveResponse.draw)
            {
                isDraw = true;
            }

            SwitchCurrentPlayer();
            return playMoveResponse;
        }

        private void SwitchCurrentPlayer()
        {
            currentPlayerId = currentPlayerId == 1 ? 2 : 1;
        }
    }
}
