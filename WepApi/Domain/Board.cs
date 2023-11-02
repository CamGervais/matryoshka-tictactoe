using TicTacToe.WepApi.Controllers.Exceptions;
using TicTacToe.WepApi.Domain.Dto;

namespace TicTacToe.WepApi.Domain
{
    public class Board
    {
        private List<int> tiles;

        public Board()
        {
            tiles = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        public PlayMoveResponse Play(int playerId, int tileIndex)
        {
            if (tiles[tileIndex] == 0)
            {
                tiles[tileIndex] = playerId;
            }
            else
            {
                throw new InvalidPlayMoveException("This tile has already been played.");
            }

            if (PlayerHasWinningMove(playerId))
            {
                return new PlayMoveResponse(playerId, true, false);
            }
            return new PlayMoveResponse(playerId, false, IsDraw());
        }

        private bool PlayerHasWinningMove(int playerId)
        {
            if (tiles[0] == playerId && tiles[1] == playerId && tiles[2] == playerId)
            {
                return true;
            }
            if (tiles[3] == playerId && tiles[4] == playerId && tiles[5] == playerId)
            {
                return true;
            }
            if (tiles[6] == playerId && tiles[7] == playerId && tiles[8] == playerId)
            {
                return true;
            }
            if (tiles[0] == playerId && tiles[3] == playerId && tiles[6] == playerId)
            {
                return true;
            }
            if (tiles[1] == playerId && tiles[4] == playerId && tiles[7] == playerId)
            {
                return true;
            }
            if (tiles[2] == playerId && tiles[5] == playerId && tiles[8] == playerId)
            {
                return true;
            }
            if (tiles[0] == playerId && tiles[4] == playerId && tiles[8] == playerId)
            {
                return true;
            }
            if (tiles[2] == playerId && tiles[4] == playerId && tiles[6] == playerId)
            {
                return true;
            }
            return false;
        }

        private bool IsDraw()
        {
            return !tiles.Contains(0);
        }
    }
}
