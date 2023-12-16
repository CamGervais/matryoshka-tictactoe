using TicTacToe.WepApi.Domain;

namespace TicTacToe.WepApi.Service
{
    public class GameFactory
    {
        private const string BOARD_TYPE_MATRYOSHKA = "matryoshka";

        public Game CreateGame(string boardType, bool usesComputer)
        {
            Board board;
            int maxNumberOfTurns;
            if (boardType == BOARD_TYPE_MATRYOSHKA)
            {
                board = new MatryoshkaBoard();
                maxNumberOfTurns = 12;
            }
            else
            {
                board = new RegularBoard();
                maxNumberOfTurns = 9;
            }
            return new Game(board, usesComputer, maxNumberOfTurns);
        }
    }
}
