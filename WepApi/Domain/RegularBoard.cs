using TicTacToe.WepApi.Controllers.Exceptions;

namespace TicTacToe.WepApi.Domain
{
    public class RegularBoard : Board
    {
        private List<int> tiles;

        public RegularBoard()
        {
            tiles = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        public List<int> GetTiles() { return tiles; }

        public void Play(int playerId, int tileIndex, ref GameStatus currentGameStatus, int playedElement = 0)
        {
            if (tileIndex >= 0 && tileIndex < tiles.Count && tiles[tileIndex] == 0)
            {
                tiles[tileIndex] = playerId;
            }
            else
            {
                throw new InvalidPlayMoveException("This tile has already been played.");
            }

            if (PlayerHasWinningMove(playerId))
            {
                if (playerId == 1)
                {
                    currentGameStatus = GameStatus.Player1Win;
                }
                else if (playerId == 2)
                {
                    currentGameStatus = GameStatus.Player2Win;
                }
            }
            else if (IsDraw())
            {
                currentGameStatus = GameStatus.Draw;
            }
        }

        public void PlayBestNextMove(int playerId, ref GameStatus currentGameStatus)
        {
            int play = MinimaxAlgorithm.FindBestMove(tiles);
            Play(playerId, play, ref currentGameStatus);
        }

        private bool PlayerHasWinningMove(int playerId)
        {
            if (tiles[0] == playerId && tiles[1] == playerId && tiles[2] == playerId)
            {
                tiles[0] = playerId + 2;
                tiles[1] = playerId + 2;
                tiles[2] = playerId + 2;
                return true;
            }
            if (tiles[3] == playerId && tiles[4] == playerId && tiles[5] == playerId)
            {
                tiles[3] = playerId + 2;
                tiles[4] = playerId + 2;
                tiles[5] = playerId + 2;
                return true;
            }
            if (tiles[6] == playerId && tiles[7] == playerId && tiles[8] == playerId)
            {
                tiles[6] = playerId + 2;
                tiles[7] = playerId + 2;
                tiles[8] = playerId + 2;
                return true;
            }
            if (tiles[0] == playerId && tiles[3] == playerId && tiles[6] == playerId)
            {
                tiles[0] = playerId + 4;
                tiles[3] = playerId + 4;
                tiles[6] = playerId + 4;
                return true;
            }
            if (tiles[1] == playerId && tiles[4] == playerId && tiles[7] == playerId)
            {
                tiles[1] = playerId + 4;
                tiles[4] = playerId + 4;
                tiles[7] = playerId + 4;
                return true;
            }
            if (tiles[2] == playerId && tiles[5] == playerId && tiles[8] == playerId)
            {
                tiles[2] = playerId + 4;
                tiles[5] = playerId + 4;
                tiles[8] = playerId + 4;
                return true;
            }
            if (tiles[0] == playerId && tiles[4] == playerId && tiles[8] == playerId)
            {
                tiles[0] = playerId + 6;
                tiles[4] = playerId + 6;
                tiles[8] = playerId + 6;
                return true;
            }
            if (tiles[2] == playerId && tiles[4] == playerId && tiles[6] == playerId)
            {
                tiles[2] = playerId + 8;
                tiles[4] = playerId + 8;
                tiles[6] = playerId + 8;
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
