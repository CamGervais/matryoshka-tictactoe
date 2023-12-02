using TicTacToe.WepApi.Domain;

namespace TicTacToeTests.Domain
{
    [TestClass]
    public class MinimaxAlgorithmTest
    {
        [TestMethod]
        public void GivenNonFullBoard_WhenIsMovesLeft_ThenReturnTrue()
        {
            List<int> tiles = new List<int>() { 1, 2, 1, 1, 0, 2, 2, 2, 1 };

            bool actual = MinimaxAlgorithm.IsMovesLeft(tiles);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GivenFullBoard_WhenIsMovesLeft_ThenReturnFalse()
        {
            List<int> tiles = new List<int>() { 1, 2, 1, 1, 1, 2, 2, 2, 1 };

            bool actual = MinimaxAlgorithm.IsMovesLeft(tiles);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void GivenGameIsWonByRow_WhenEvaluate_ThenReturnPlusOrMinus100()
        {
            List<int> tiles = new List<int>() { 1, 2, 0, 1, 1, 1, 0, 2, 0 };

            int actual = MinimaxAlgorithm.Evaluate(tiles, 0);

            Assert.AreEqual(-100, actual);
        }

        [TestMethod]
        public void GivenGameIsWonByColumn_WhenEvaluate_ThenReturnPlusOrMinus100()
        {
            List<int> tiles = new List<int>() { 1, 2, 0, 1, 2, 1, 0, 2, 0 };

            int actual = MinimaxAlgorithm.Evaluate(tiles, 0);

            Assert.AreEqual(100, actual);
        }

        [TestMethod]
        public void GivenGameIsWonByLeftDiagonal_WhenEvaluate_ThenReturnPlusOrMinus100()
        {
            List<int> tiles = new List<int>() { 1, 2, 0, 0, 1, 1, 0, 2, 1 };

            int actual = MinimaxAlgorithm.Evaluate(tiles, 0);

            Assert.AreEqual(-100, actual);
        }

        [TestMethod]
        public void GivenGameIsWonByRightDiagonal_WhenEvaluate_ThenReturnPlusOrMinus100()
        {
            List<int> tiles = new List<int>() { 1, 2, 2, 1, 2, 1, 2, 0, 0 };

            int actual = MinimaxAlgorithm.Evaluate(tiles, 0);

            Assert.AreEqual(100, actual);
        }

        [TestMethod]
        public void GivenNewestMoveBlocksWinByRow_WhenEvaluate_ThenReturnPlusOrMinus10()
        {
            List<int> tiles = new List<int>() { 1, 2, 0, 2, 1, 1, 0, 2, 0 };

            int actual = MinimaxAlgorithm.Evaluate(tiles, 3);

            Assert.AreEqual(10, actual);
        }

        [TestMethod]
        public void GivenNewestMoveBlocksWinByColumn_WhenEvaluate_ThenReturnPlusOrMinus10()
        {
            List<int> tiles = new List<int>() { 2, 2, 0, 2, 0, 1, 1, 2, 0 };

            int actual = MinimaxAlgorithm.Evaluate(tiles, 6);

            Assert.AreEqual(-10, actual);
        }

        [TestMethod]
        public void GivenNewestMoveBlocksWinByLeftDiagonal_WhenEvaluate_ThenReturnPlusOrMinus10()
        {
            List<int> tiles = new List<int>() { 1, 0, 0, 0, 2, 1, 0, 0, 1 };

            int actual = MinimaxAlgorithm.Evaluate(tiles, 4);

            Assert.AreEqual(10, actual);
        }

        [TestMethod]
        public void GivenNewestMoveBlocksWinByRightDiagonal_WhenEvaluate_ThenReturnPlusOrMinus10()
        {
            List<int> tiles = new List<int>() { 1, 0, 2, 0, 2, 1, 1, 2, 0 };

            int actual = MinimaxAlgorithm.Evaluate(tiles, 6);

            Assert.AreEqual(-10, actual);
        }

        [TestMethod]
        public void GivenNoWinsOrBlocks_WhenEvaluate_ThenReturn0()
        {
            List<int> tiles = new List<int>() { 2, 2, 0, 2, 0, 1, 0, 1, 0 };

            int actual = MinimaxAlgorithm.Evaluate(tiles, 0);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenOldBlockWinByRow_WhenEvaluate_ThenReturn0()
        {
            List<int> tiles = new List<int>() { 1, 2, 0, 2, 1, 1, 0, 2, 0 };

            int actual = MinimaxAlgorithm.Evaluate(tiles, 0);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenOldBlockWinByColumn_WhenEvaluate_ThenReturn0()
        {
            List<int> tiles = new List<int>() { 2, 2, 0, 2, 0, 1, 1, 2, 0 };

            int actual = MinimaxAlgorithm.Evaluate(tiles, 7);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenOldBlockWinByLeftDiagonal_WhenEvaluate_ThenReturn0()
        {
            List<int> tiles = new List<int>() { 1, 0, 0, 0, 2, 1, 0, 0, 1 };

            int actual = MinimaxAlgorithm.Evaluate(tiles, 5);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenOldBlockWinByRightDiagonal_WhenEvaluate_ThenReturn0()
        {
            List<int> tiles = new List<int>() { 1, 0, 2, 0, 2, 1, 1, 2, 0 };

            int actual = MinimaxAlgorithm.Evaluate(tiles, 7);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenWinOrBlock_WhenMinimax_ThenReturnScore()
        {
            List<int> tiles = new List<int>() { 1, 2, 0, 1, 1, 1, 0, 2, 0 };

            int actual = MinimaxAlgorithm.Minimax(tiles, true, 0);

            Assert.AreEqual(-100, actual);
        }
    }
}
