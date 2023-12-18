namespace TicTacToe.WepApi.Domain
{
    public class MinimaxAlgorithm
    {
        private static Random random = new Random();
        
        public static bool IsMovesLeft(List<int> tiles)
        {
            return tiles.Contains(0);
        }

        public static int Evaluate(List<int> tiles, int playedTileIndex)
        {
            int humanPlayerId = 1;
            int computerPlayerId = 2;
            int player1BlockSum = (computerPlayerId * 2) + humanPlayerId;
            int player2BlockSum = (humanPlayerId * 2) + computerPlayerId;

            int[] rows = { 0, 3, 6 };
            foreach (int row in rows)
            {
                if (tiles[row] == tiles[row + 1] && tiles[row + 1] == tiles[row + 2])
                {
                    if (tiles[row] == computerPlayerId)
                    {
                        return +100;
                    }
                    else if (tiles[row] == humanPlayerId)
                    {
                        return -100;
                    }
                }
            }

            int[] columns = {0, 1, 2};
            foreach (int col in columns)
            {
                if (tiles[col] == tiles[col + 3] && tiles[col + 3] == tiles[col + 6])
                {
                    if (tiles[col] == computerPlayerId)
                    {
                        return +100;
                    }
                    else if (tiles[col] == humanPlayerId)
                    {
                        return -100;
                    }
                }
            }
            
            if ((tiles[0] == tiles[4] && tiles[4] == tiles[8]) || (tiles[2] == tiles[4] && tiles[4] == tiles[6]))
            {
                if (tiles[4] == computerPlayerId)
                {
                    return +100;
                }
                else if (tiles[4] == humanPlayerId)
                {
                    return -100;
                }
            }

            foreach (int row in rows)
            {
                if (
                    ((tiles[row] == tiles[row + 1] && tiles[row + 1] != tiles[row + 2]) ||
                    (tiles[row + 1] == tiles[row + 2] && tiles[row + 1] != tiles[row]) ||
                    (tiles[row] == tiles[row + 2] && tiles[row + 1] != tiles[row + 2])) &&
                    tiles[row] != 0 && tiles[row + 1] != 0 && tiles[row + 2] != 0 &&
                    (playedTileIndex == row || playedTileIndex == row + 1 || playedTileIndex == row + 2)
                    )
                {
                    int rowSum = tiles[row] + tiles[row + 1] + tiles[row + 2];
                    if (rowSum == player2BlockSum)
                    {
                        return +10;
                    }
                    else if (rowSum == player1BlockSum)
                    {
                        return -10;
                    }
                }
            }

            foreach (int col in columns)
            {
                if (
                    ((tiles[col] == tiles[col + 3] && tiles[col + 3] != tiles[col + 6]) ||
                    (tiles[col + 3] == tiles[col + 6] && tiles[col + 3] != tiles[col]) ||
                    (tiles[col] == tiles[col + 6] && tiles[col + 3] != tiles[col + 6])) &&
                    tiles[col] != 0 && tiles[col + 3] != 0 && tiles[col + 6] != 0 &&
                    (playedTileIndex == col || playedTileIndex == col + 3 || playedTileIndex == col + 6)
                    )
                {
                    int colSum = tiles[col] + tiles[col + 3] + tiles[col + 6];
                    if (colSum == player2BlockSum)
                    {
                        return +10;
                    }
                    else if (colSum == player1BlockSum)
                    {
                        return -10;
                    }
                }
            }

            if (
                ((tiles[0] == tiles[4] && tiles[4] != tiles[8]) ||
                (tiles[4] == tiles[8] && tiles[4] != tiles[0]) ||
                (tiles[0] == tiles[8] && tiles[4] != tiles[8])) &&
                tiles[0] != 0 && tiles[4] != 0 && tiles[8] != 0 &&
                playedTileIndex is 0 or 4 or 8
                )
            {
                int diagSum = tiles[0] + tiles[4] + tiles[8];
                if (diagSum == player2BlockSum)
                {
                    return +10;
                }
                else if (diagSum == player2BlockSum)
                {
                    return -10;
                }
            }
            if (
                ((tiles[2] == tiles[4] && tiles[4] != tiles[6]) ||
                (tiles[4] == tiles[6] && tiles[4] != tiles[2]) ||
                (tiles[2] == tiles[6] && tiles[4] != tiles[6])) &&
                tiles[2] != 0 && tiles[4] != 0 && tiles[6] != 0 &&
                playedTileIndex is 2 or 4 or 6
                )
            {
                int diagSum = tiles[2] + tiles[4] + tiles[6];
                if (diagSum == player2BlockSum)
                {
                    return +10;
                }
                else if (diagSum == player1BlockSum)
                {
                    return -10;
                }
            }

            return 0;
        }

        public static int Minimax(List<int> tiles, bool isMax, int playedTileIndex)
        {
            int score = Evaluate(tiles, playedTileIndex);
            
            if (score != 0)
            {
                return score;
            }

            if (!IsMovesLeft(tiles))
            {
                return 0;
            }

            if (isMax)
            {
                int best = -1000;
                for (int i = 0; i < 9; i++)
                {
                    if (tiles[i] == 0)
                    {
                        tiles[i] = 2;
                        best = Math.Max(best, Minimax(tiles, !isMax, i));
                        tiles[i] = 0;
                    }
                }
                return best;
            }

            else
            {
                int best = 1000;
                for (int i = 0; i < 9; i++)
                {
                    if (tiles[i] == 0)
                    {
                        tiles[i] = 1;
                        best = Math.Min(best, Minimax(tiles, !isMax, i));
                        tiles[i] = 0;
                    }
                }
                return best;
            }
        }

        public static int FindBestMove(List<int> tiles)
        {
            int bestVal = -1000;
            List<int> choices = new List<int>
            {
                -1
            };

            for (int i = 0; i < 9; i++)
            {
                if (tiles[i] == 0)
                {
                    tiles[i] = 2;
                    int moveVal = Minimax(tiles, false, i);
                    tiles[i] = 0;

                    if (moveVal == bestVal)
                    {
                        choices.Add(i);
                    }
                    if (moveVal > bestVal)
                    {
                        bestVal = moveVal;
                        choices.Clear();
                        choices.Add(i);
                    }
                }
            }

            int randomIndex = random.Next(choices.Count);
            return choices[randomIndex];
        }
    }
}
