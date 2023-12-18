using TicTacToe.WepApi.Domain;

namespace TicTacToeTests.Domain
{
    [TestClass]
    public class MatryoshkaMinimaxAlgorithmTest
    {
        [TestMethod]
        public void GivenNonFullBoard_WhenIsMovesLeft_ThenReturnTrue()
        {
            List<(int, int)> tiles = new List<(int, int)>() { 
                (1, 1), (2, 2), (1, 3), (1, 3), (0, 0), (2, 1), (3, 2), (3, 3), (3, 3)
            };

            bool actual = MatryoshkaMinimaxAlgorithm.IsMovesLeft(tiles);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenFullBoard_WhenIsMovesLeft_ThenReturnFalse()
        {
            List<(int, int)> tiles = new List<(int, int)>() {
                (1, 1), (2, 2), (1, 3), (1, 3), (1, 3), (2, 1), (3, 2), (3, 3), (3, 3)
            };

            bool actual = MatryoshkaMinimaxAlgorithm.IsMovesLeft(tiles);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void GivenWinOrBlock_WhenMinimax_ThenReturnScorePlusOrMinusElementSize()
        {
            List<(int, int)> tiles = new List<(int, int)>() { 
                (1, 1), (2, 3), (0, 0), (1, 1), (1, 2), (1, 3), (0, 0), (2, 2), (0, 0) 
            };
            List<int> unusedPlayer1Pieces = new List<int>() { 2, 3 };
            List<int> unusedPlayer2Pieces = new List<int>() { 1, 1, 2, 3 };

            int actual = MatryoshkaMinimaxAlgorithm.Minimax(tiles, false, 5, 3, unusedPlayer1Pieces, unusedPlayer2Pieces);

            Assert.AreEqual(-103, actual);
        }
    }
}
