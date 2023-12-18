using TicTacToe.WepApi.Domain.Exceptions;

namespace TicTacToe.WepApi.Domain
{
    public class MatryoshkaBoard : Board
    {
        private List<(int, int, int)> tiles;
        private List<int> unusedPlayer1Pieces;
        private List<int> unusedPlayer2Pieces;

        public MatryoshkaBoard() 
        { 
            tiles = new List<(int, int, int)>()
            {
                (0, 0, 0), (0, 0, 0), (0, 0, 0), (0, 0, 0), (0, 0, 0), (0, 0, 0), (0, 0, 0), (0, 0, 0), (0, 0, 0)
            };
            unusedPlayer1Pieces = new List<int>()
            {
                1, 1, 2, 2, 3, 3
            };
            unusedPlayer2Pieces = new List<int>()
            {
                1, 1, 2, 2, 3, 3
            };
        }

        public List<int> GetTiles()
        {
            return tiles.Select(i => i.Item3).ToList();
        }

        public void Play(int playerId, int tileIndex, ref GameStatus currentGameStatus, int playedElement = 0)
        {
            if (tileIndex < 0 || tileIndex >= tiles.Count)
            {
                throw new InvalidPlayMoveException("Played tile index is out of range.");
            }
            if (currentGameStatus != GameStatus.Ongoing)
            {
                throw new InvalidPlayMoveException("The game is completed.");
            }
            if ((playerId == 1 && !unusedPlayer1Pieces.Contains(playedElement)) ||
                (playerId == 2 && !unusedPlayer2Pieces.Contains(playedElement)))
            {
                throw new InvalidPlayMoveException("There are no of the played element left to be played.");
            }

            if (playedElement > tiles[tileIndex].Item2)
            {
                int addedNumber = playerId == 1 ? 0 : 3;
                tiles[tileIndex] = (playerId, playedElement, playedElement + addedNumber);
                if (playerId == 1)
                {
                    unusedPlayer1Pieces.Remove(playedElement);
                }
                else
                {
                    unusedPlayer2Pieces.Remove(playedElement);
                }
            }
            else
            {
                throw new InvalidPlayMoveException("Cannot play a piece smaller or equal than the one currently down.");
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
            List<(int, int)> tilesElements = tiles.Select(i => (i.Item1, i.Item2)).ToList();
            (int, int) play = MatryoshkaMinimaxAlgorithm.FindBestMove(tilesElements, unusedPlayer1Pieces, unusedPlayer2Pieces);
            Play(playerId, play.Item1, ref currentGameStatus, play.Item2);
        }

        private bool PlayerHasWinningMove(int playerId)
        {
            int[] rows = { 0, 3, 6 };
            foreach (int row in rows)
            {
                if (tiles[row].Item1 == playerId && tiles[row + 1].Item1 == playerId && tiles[row + 2].Item1 == playerId)
                {
                    tiles[row] = (tiles[row].Item1, tiles[row].Item2, tiles[row].Item3 + 6);
                    tiles[row + 1] = (tiles[row + 1].Item1, tiles[row + 1].Item2, tiles[row + 1].Item3 + 6);
                    tiles[row + 2] = (tiles[row + 2].Item1, tiles[row + 2].Item2, tiles[row + 2].Item3 + 6);
                    return true;
                }
            }

            int[] columns = { 0, 1, 2 };
            foreach (int col in columns)
            {
                if (tiles[col].Item1 == playerId && tiles[col + 3].Item1 == playerId && tiles[col + 6].Item1 == playerId)
                {
                    tiles[col] = (tiles[col].Item1, tiles[col].Item2, tiles[col].Item3 + 12);
                    tiles[col + 3] = (tiles[col + 3].Item1, tiles[col + 3].Item2, tiles[col + 3].Item3 + 12);
                    tiles[col + 6] = (tiles[col + 6].Item1, tiles[col + 6].Item2, tiles[col + 6].Item3 + 12);
                    return true;
                }
            }

            if (tiles[0].Item1 == playerId && tiles[4].Item1 == playerId && tiles[8].Item1 == playerId)
            {
                tiles[0] = (tiles[0].Item1, tiles[0].Item2, tiles[0].Item3 + 18);
                tiles[4] = (tiles[4].Item1, tiles[4].Item2, tiles[4].Item3 + 18);
                tiles[8] = (tiles[8].Item1, tiles[8].Item2, tiles[8].Item3 + 18);
                return true;
            }

            if (tiles[2].Item1 == playerId && tiles[4].Item1 == playerId && tiles[6].Item1 == playerId)
            {
                tiles[2] = (tiles[2].Item1, tiles[2].Item2, tiles[2].Item3 + 24);
                tiles[4] = (tiles[4].Item1, tiles[4].Item2, tiles[4].Item3 + 24);
                tiles[6] = (tiles[6].Item1, tiles[6].Item2, tiles[6].Item3 + 24);
                return true;
            }

            return false;
        }

        private bool IsDraw()
        {
            return !tiles.Select(i => i.Item1).Contains(0);
        }
    }
}
