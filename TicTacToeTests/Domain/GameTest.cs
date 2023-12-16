using TicTacToe.WepApi.Domain;
using TicTacToe.WepApi.Domain.Dto;
using TicTacToe.WepApi.Domain.Exceptions;

namespace TicTacToeTests.Domain
{
    [TestClass]
    public class GameTest
    {
        private Game game;
        private Board board;

        public GameTest()
        {
            board = new RegularBoard();
            game = new Game(board, true, 5);
        }

        [TestMethod]
        public void GivenOngoingGame_WhenHumanPlay_ThenReturnedPlayMoveResponseHasCorrectAttributes()
        {
            PlayMoveResponse actual = game.HumanPlay(0);

            List<int> expected = new List<int>() { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
            CollectionAssert.AreEqual(expected, actual.currentBoard);
            Assert.AreEqual(GameStatus.Ongoing.ToString(), actual.gameStatus);
        }

        [TestMethod]
        public void GivenExistingPreviousMove_WhenHumanPlay_ThenPlayerIsSwitched()
        {
            game.HumanPlay(0);
            
            PlayMoveResponse actual = game.HumanPlay(1);

            List<int> expected = new List<int>() { 1, 2, 0, 0, 0, 0, 0, 0, 0 };
            CollectionAssert.AreEqual(expected, actual.currentBoard);
        }

        [TestMethod]
        public void GivenOngoingGameAndMaxTurnsHit_WhenHumanPlay_ThenGameIsDraw()
        {
            game.HumanPlay(0);
            game.HumanPlay(1);
            game.HumanPlay(2);
            game.HumanPlay(3);

            PlayMoveResponse actual = game.HumanPlay(4);

            Assert.AreEqual(GameStatus.Draw.ToString(), actual.gameStatus);
        }

        [TestMethod]
        public void GivenCompletedGameAndMaxTurnsHit_WhenHumanPlay_ThenGameIsNotReplacedByDraw()
        {
            game.HumanPlay(0);
            game.HumanPlay(3);
            game.HumanPlay(1);
            game.HumanPlay(4);

            PlayMoveResponse actual = game.HumanPlay(2);

            Assert.AreEqual(GameStatus.Player1Win.ToString(), actual.gameStatus);
        }

        [TestMethod]
        public void GivenOngoingGame_WhenComputerPlay_ThenReturnedPlayMoveResponseHasCorrectAttributes()
        {
            PlayMoveResponse actual = game.ComputerPlay();

            List<int> notExpected = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            CollectionAssert.AreNotEqual(notExpected, actual.currentBoard);
            Assert.AreEqual(GameStatus.Ongoing.ToString(), actual.gameStatus);
        }

        [TestMethod]
        public void GivenExistingPreviousMove_WhenComputerPlay_ThenPlayerIsSwitched()
        {
            game.HumanPlay(0);

            PlayMoveResponse actual = game.ComputerPlay();

            CollectionAssert.Contains(actual.currentBoard, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlayMoveException))]
        public void GivenGameNotUsingComputer_WhenComputerPlay_ThenError()
        {
            game = new Game(board, false, 5);

            game.ComputerPlay();
        }

        [TestMethod]
        public void GivenOngoingGameAndMaxTurnsHit_WhenComputerPlay_ThenGameIsDraw()
        {
            game.HumanPlay(0);
            game.HumanPlay(1);
            game.HumanPlay(2);
            game.HumanPlay(4);

            PlayMoveResponse actual = game.ComputerPlay();

            Assert.AreEqual(GameStatus.Draw.ToString(), actual.gameStatus);
        }

        [TestMethod]
        public void GivenCompletedGameAndMaxTurnsHit_WhenComputerPlay_ThenGameIsNotReplacedByDraw()
        {
            game = new Game(board, true, 9);
            game.HumanPlay(0);
            game.HumanPlay(1);
            game.HumanPlay(4);
            game.HumanPlay(2);
            game.HumanPlay(5);
            game.HumanPlay(3);
            game.HumanPlay(6);
            game.HumanPlay(7);

            PlayMoveResponse actual = game.ComputerPlay();

            Assert.AreEqual(GameStatus.Player1Win.ToString(), actual.gameStatus);
        }
    }
}
