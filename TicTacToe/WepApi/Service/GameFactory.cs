using TicTacToe.WepApi.Domain;

namespace TicTacToe.WepApi.Service
{
    public class GameFactory
    {
        private const string BOARD_TYPE_MATRYOSHKA = "matryoshka";

        public Game CreateGame(string boardType, bool usesComputer)
        {
            Board board;
            if (boardType == BOARD_TYPE_MATRYOSHKA)
            {
                board = new MatryoshkaBoard();
            }
            else
            {
                board = new RegularBoard();
            }
            return new Game(board, usesComputer);
        }
    }
}
