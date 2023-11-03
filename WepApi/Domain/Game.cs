using TicTacToe.WepApi.Domain.Dto;

namespace TicTacToe.WepApi.Domain
{
    public class Game
    {
        private Board board;
        private int currentPlayerId;

        public Game()
        {
            board = new Board();
            currentPlayerId = 1;
        }

        public GetGameStatusResponse GetGameStatus()
        {
            return new GetGameStatusResponse(board.GetTiles());
        }

        public PlayMoveResponse Play(int tileIndex)
        {
            PlayMoveResponse playMoveResponse = board.Play(currentPlayerId, tileIndex);
            SwitchCurrentPlayer();
            return playMoveResponse;
        }

        private void SwitchCurrentPlayer()
        {
            currentPlayerId = currentPlayerId == 1 ? 2 : 1;
        }
    }
}
