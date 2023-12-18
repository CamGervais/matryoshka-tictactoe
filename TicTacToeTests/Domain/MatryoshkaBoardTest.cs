using TicTacToe.WepApi.Domain;
using TicTacToe.WepApi.Domain.Exceptions;

namespace TicTacToeTests.Domain
{
    [TestClass]
    public class MatryoshkaBoardTest
    {
        private Board board;
        private GameStatus gameStatus;

        public MatryoshkaBoardTest()
        {
            board = new MatryoshkaBoard();
            gameStatus = GameStatus.Ongoing;
        }

        [TestMethod]
        public void GivenOngoingGame_WhenPlayNonWinningMove_ThenStatusIsOngoing()
        {
            board.Play(1, 0, ref gameStatus, 1);

            Assert.AreEqual(GameStatus.Ongoing, gameStatus);
        }

        [TestMethod]
        public void GivenOngoingGame_WhenPlay_ThenTilesAreUpdated()
        {
            board.Play(1, 0, ref gameStatus, 1);
            board.Play(2, 1, ref gameStatus, 1);
            board.Play(1, 2, ref gameStatus, 2);
            board.Play(2, 3, ref gameStatus, 2);
            board.Play(1, 4, ref gameStatus, 3);
            board.Play(2, 5, ref gameStatus, 3);

            List<int> expected = new List<int>() { 1, 4, 2, 5, 3, 6, 0, 0, 0 };
            List<int> actual = board.GetTiles();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlayMoveException))]
        public void GivenPlayedTileIndexLowerThan0_WhenPlay_ThenError()
        {
            board.Play(1, -1, ref gameStatus, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlayMoveException))]
        public void GivenPlayedTileIndexHigherThan8_WhenPlay_ThenError()
        {
            board.Play(1, 9, ref gameStatus, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlayMoveException))]
        public void GivenCompletedGame_WhenPlay_ThenError()
        {
            gameStatus = GameStatus.Player1Win;

            board.Play(1, 0, ref gameStatus, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlayMoveException))]
        public void GivenExistingPlay_WhenPlayOnSameTileWithEqualOrSmallerPiece_ThenError()
        {
            board.Play(1, 0, ref gameStatus, 2);

            board.Play(1, 0, ref gameStatus, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlayMoveException))]
        public void GivenPlayer1PlayedAllItemsOfAnElement_WhenPlayElement_ThenError()
        {
            board.Play(1, 0, ref gameStatus, 1);
            board.Play(1, 1, ref gameStatus, 1);

            board.Play(1, 2, ref gameStatus, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlayMoveException))]
        public void GivenPlayer2PlayedAllItemsOfAnElement_WhenPlayElement_ThenError()
        {
            board.Play(2, 0, ref gameStatus, 1);
            board.Play(2, 1, ref gameStatus, 1);

            board.Play(2, 2, ref gameStatus, 1);
        }

        [TestMethod]
        public void GivenOngoingGame_WhenPlayer1PlaysWinningMove_ThenStatusIsPlayer1Win()
        {
            board.Play(1, 0, ref gameStatus, 1);
            board.Play(1, 1, ref gameStatus, 2);

            board.Play(1, 2, ref gameStatus, 3);

            Assert.AreEqual(GameStatus.Player1Win, gameStatus);
        }

        [TestMethod]
        public void GivenOngoingGame_WhenPlayer2PlaysWinningMove_ThenStatusIsPlayer2Win()
        {
            board.Play(2, 0, ref gameStatus, 1);
            board.Play(2, 4, ref gameStatus, 2);

            board.Play(2, 8, ref gameStatus, 3);

            Assert.AreEqual(GameStatus.Player2Win, gameStatus);
        }

        [TestMethod]
        public void GivenOngoingGame_WhenBoardIsFilled_ThenStatusIsDraw()
        {
            board.Play(2, 0, ref gameStatus, 1);
            board.Play(1, 1, ref gameStatus, 1);
            board.Play(2, 2, ref gameStatus, 1);
            board.Play(1, 3, ref gameStatus, 2);
            board.Play(1, 4, ref gameStatus, 2);
            board.Play(2, 5, ref gameStatus, 2);
            board.Play(1, 6, ref gameStatus, 3);
            board.Play(2, 7, ref gameStatus, 3);

            board.Play(1, 8, ref gameStatus, 3);

            Assert.AreEqual(GameStatus.Draw, gameStatus);
        }

        [TestMethod]
        public void WhenWinningGameByRow_ThenWinningTilesAreUpdatedWithPlus6()
        {
            board.Play(1, 2, ref gameStatus, 3);
            board.Play(2, 4, ref gameStatus, 1);
            board.Play(1, 6, ref gameStatus, 1);
            board.Play(1, 7, ref gameStatus, 2);

            board.Play(1, 8, ref gameStatus, 3);

            List<int> expected = new List<int>() { 0, 0, 3, 0, 4, 0, 7, 8, 9 };
            List<int> actual = board.GetTiles();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenWinningGameByColumn_ThenWinningTilesAreUpdatedWithPlus12()
        {
            board.Play(2, 2, ref gameStatus, 1);
            board.Play(2, 4, ref gameStatus, 1);
            board.Play(2, 5, ref gameStatus, 2);
            board.Play(1, 6, ref gameStatus, 1);
            board.Play(1, 7, ref gameStatus, 2);

            board.Play(2, 8, ref gameStatus, 3);

            List<int> expected = new List<int>() { 0, 0, 16, 0, 4, 17, 1, 2, 18 };
            List<int> actual = board.GetTiles();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenWinningGameByLeftDiagonal_ThenWinningTilesAreUpdatedWithPlus18()
        {
            board.Play(1, 0, ref gameStatus, 1);
            board.Play(1, 2, ref gameStatus, 3);
            board.Play(2, 3, ref gameStatus, 3);
            board.Play(1, 4, ref gameStatus, 2);
            board.Play(2, 5, ref gameStatus, 2);

            board.Play(1, 8, ref gameStatus, 3);

            List<int> expected = new List<int>() { 19, 0, 3, 6, 20, 5, 0, 0, 21 };
            List<int> actual = board.GetTiles();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenWinningGameByRightDiagonal_ThenWinningTilesAreUpdatedWithPlus24()
        {
            board.Play(2, 0, ref gameStatus, 1);
            board.Play(1, 1, ref gameStatus, 1);
            board.Play(2, 2, ref gameStatus, 1);
            board.Play(2, 4, ref gameStatus, 2);
            board.Play(1, 8, ref gameStatus, 2);

            board.Play(2, 6, ref gameStatus, 3);

            List<int> expected = new List<int>() { 4, 1, 28, 0, 29, 0, 30, 0, 2 };
            List<int> actual = board.GetTiles();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenOngoingGame_WhenPlayBestNextMove_ThenTilesAreUpdated()
        {
            board.PlayBestNextMove(1, ref gameStatus);

            List<int> notExpected = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            List<int> actual = board.GetTiles();
            CollectionAssert.AreNotEqual(notExpected, actual);
        }
    }
}
