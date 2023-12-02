using TicTacToe.WepApi.Domain;
using TicTacToe.WepApi.Domain.Exceptions;

namespace TicTacToeTests.Domain
{
    [TestClass]
    public class RegularBoardTest
    {
        private Board board;
        private GameStatus gameStatus;

        public RegularBoardTest()
        {
            board = new RegularBoard();
            gameStatus = GameStatus.Ongoing;
        }

        [TestMethod]
        public void GivenOngoingGame_WhenPlayNonWinningMove_ThenStatusIsOngoing()
        {
            board.Play(1, 0, ref gameStatus);

            Assert.AreEqual(GameStatus.Ongoing, gameStatus);
        }

        [TestMethod]
        public void GivenOngoingGame_WhenPlay_ThenTilesAreUpdated()
        {
            board.Play(1, 2, ref gameStatus);

            List<int> expected = new List<int>() { 0, 0, 1, 0, 0, 0, 0, 0, 0 };
            List<int> actual = board.GetTiles();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlayMoveException))]
        public void GivenPlayedTileIndexLowerThan0_WhenPlay_ThenError()
        {
            board.Play(1, -1, ref gameStatus);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlayMoveException))]
        public void GivenPlayedTileIndexHigherThan8_WhenPlay_ThenError()
        {
            board.Play(1, 9, ref gameStatus);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlayMoveException))]
        public void GivenCompletedGame_WhenPlay_ThenError()
        {
            gameStatus = GameStatus.Player1Win;

            board.Play(1, 0, ref gameStatus);
        }

        [TestMethod]
        public void GivenOngoingGame_WhenPlayer1PlaysWinningMove_ThenStatusIsPlayer1Win()
        {
            board.Play(1, 0, ref gameStatus);
            board.Play(1, 1, ref gameStatus);

            board.Play(1, 2, ref gameStatus);

            Assert.AreEqual(GameStatus.Player1Win, gameStatus);
        }

        [TestMethod]
        public void GivenOngoingGame_WhenPlayer2PlaysWinningMove_ThenStatusIsPlayer2Win()
        {
            board.Play(2, 0, ref gameStatus);
            board.Play(2, 4, ref gameStatus);

            board.Play(2, 8, ref gameStatus);

            Assert.AreEqual(GameStatus.Player2Win, gameStatus);
        }

        [TestMethod]
        public void GivenOngoingGame_WhenBoardIsFilled_ThenStatusIsDraw()
        {
            board.Play(2, 0, ref gameStatus);
            board.Play(1, 1, ref gameStatus);
            board.Play(2, 2, ref gameStatus);
            board.Play(1, 3, ref gameStatus);
            board.Play(1, 4, ref gameStatus);
            board.Play(2, 5, ref gameStatus);
            board.Play(1, 6, ref gameStatus);
            board.Play(2, 7, ref gameStatus);

            board.Play(1, 8, ref gameStatus);

            Assert.AreEqual(GameStatus.Draw, gameStatus);
        }

        [TestMethod]
        public void WhenWinningGameByRow_ThenWinningTilesAreUpdatedWithPlus2()
        {
            board.Play(1, 2, ref gameStatus);
            board.Play(2, 4, ref gameStatus);
            board.Play(1, 6, ref gameStatus);
            board.Play(1, 7, ref gameStatus);

            board.Play(1, 8, ref gameStatus);

            List<int> expected = new List<int>() { 0, 0, 1, 0, 2, 0, 3, 3, 3 };
            List<int> actual = board.GetTiles();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenWinningGameByColumn_ThenWinningTilesAreUpdatedWithPlus4()
        {
            board.Play(2, 2, ref gameStatus);
            board.Play(2, 4, ref gameStatus);
            board.Play(2, 5, ref gameStatus);
            board.Play(1, 6, ref gameStatus);
            board.Play(1, 7, ref gameStatus);

            board.Play(2, 8, ref gameStatus);

            List<int> expected = new List<int>() { 0, 0, 6, 0, 2, 6, 1, 1, 6 };
            List<int> actual = board.GetTiles();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenWinningGameByLeftDiagonal_ThenWinningTilesAreUpdatedWithPlus6()
        {
            board.Play(1, 0, ref gameStatus);
            board.Play(1, 2, ref gameStatus);
            board.Play(2, 3, ref gameStatus);
            board.Play(1, 4, ref gameStatus);
            board.Play(2, 5, ref gameStatus);

            board.Play(1, 8, ref gameStatus);

            List<int> expected = new List<int>() { 7, 0, 1, 2, 7, 2, 0, 0, 7 };
            List<int> actual = board.GetTiles();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenWinningGameByRightDiagonal_ThenWinningTilesAreUpdatedWithPlus8()
        {
            board.Play(2, 0, ref gameStatus);
            board.Play(1, 1, ref gameStatus);
            board.Play(2, 2, ref gameStatus);
            board.Play(2, 4, ref gameStatus);
            board.Play(1, 8, ref gameStatus);

            board.Play(2, 6, ref gameStatus);

            List<int> expected = new List<int>() { 2, 1, 10, 0, 10, 0, 10, 0, 1 };
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
