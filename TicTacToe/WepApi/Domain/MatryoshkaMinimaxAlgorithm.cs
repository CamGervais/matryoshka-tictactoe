namespace TicTacToe.WepApi.Domain
{
    public class MatryoshkaMinimaxAlgorithm
    {
        private static Random random = new Random();

        public static bool IsMovesLeft(List<(int, int)> tiles)
        {
            return tiles.Select(i => i.Item1).Contains(0);
        }

        public static int Minimax(List<(int, int)> tiles, bool isMax, int playedTileIndex, int depth, List<int> unusedPlayer1Pieces, List<int> unusedPlayer2Pieces)
        {
            List<int> tilesPlayers = tiles.Select(i => i.Item1).ToList();
            int score = MinimaxAlgorithm.Evaluate(tilesPlayers, playedTileIndex);
            
            if (score != 0)
            {
                int addedElement = isMax ? +tiles[playedTileIndex].Item2 : -tiles[playedTileIndex].Item2;
                return score + addedElement;
            }

            if (!IsMovesLeft(tiles))
            {
                return 0;
            }

            if (depth == 6)
            {
                return 0;
            }

            if (isMax)
            {
                int best = -1000;
                for (int i = 0; i < 9; i++)
                {
                    (int, int) originalTile = tiles[i];
                    for (int u = 1; u <= 3; u++)
                    {
                        if (tiles[i].Item2 < u && unusedPlayer2Pieces.Contains(u))
                        {
                            tiles[i] = (2, u);
                            unusedPlayer2Pieces.Remove(u);
                            best = Math.Max(best, Minimax(tiles, !isMax, i, depth + 1, unusedPlayer1Pieces, unusedPlayer2Pieces));
                            tiles[i] = originalTile;
                            unusedPlayer2Pieces.Add(u);
                        }
                    }
                }
                return best;
            }

            else
            {
                int best = 1000;
                for (int i = 0; i < 9; i++)
                {
                    (int, int) originalTile = tiles[i];
                    for (int u = 1; u <= 3; u++)
                    {
                        if (tiles[i].Item2 < u && unusedPlayer1Pieces.Contains(u))
                        { 
                            tiles[i] = (1, u);
                            unusedPlayer1Pieces.Remove(u);
                            best = Math.Min(best, Minimax(tiles, !isMax, i, depth + 1, unusedPlayer1Pieces, unusedPlayer2Pieces));
                            tiles[i] = originalTile;
                            unusedPlayer1Pieces.Add(u);
                        }
                    }
                }
                return best;
            }
        }

        public static (int, int) FindBestMove(List<(int, int)> tiles, List<int> unusedPlayer1Pieces, List<int> unusedPlayer2Pieces)
        {
            int bestVal = -1000;
            List<(int, int)> choices = new List<(int, int)>
            {
                (-1, 0)
            };

            for (int i = 0; i < 9; i++)
            {
                (int, int) originalTile = tiles[i];
                for (int u = 1; u <= 3; u++)
                {
                    if (tiles[i].Item2 < u && unusedPlayer2Pieces.Contains(u))
                    {
                        tiles[i] = (2, u);
                        unusedPlayer2Pieces.Remove(u);
                        int moveVal = Minimax(tiles, false, i, 1, unusedPlayer1Pieces, unusedPlayer2Pieces);
                        tiles[i] = originalTile;
                        unusedPlayer2Pieces.Add(u);

                        if (moveVal == bestVal)
                        {
                            choices.Add((i, u));
                        }
                        if (moveVal > bestVal)
                        {
                            bestVal = moveVal;
                            choices.Clear();
                            choices.Add((i, u));
                        }
                    }
                }
            }
            Console.WriteLine(String.Join(", ", choices));

            int randomIndex = random.Next(choices.Count);
            return choices[randomIndex];
        }
    }
}
