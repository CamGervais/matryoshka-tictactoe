using TicTacToe.Infrastructure.Exceptions;
using TicTacToe.WepApi.Domain;
using TicTacToe.WepApi.Domain.Exceptions;
using TicTacToe.WepApi.Infrastructure;

namespace TicTacToeTests.Infrastructure
{
    [TestClass]
    public class GameRepositoryTest
    {
        private GameRepository gameRepository;
        private Game firstGame;
        private Game secondGame;

        public GameRepositoryTest()
        {
            gameRepository = new GameRepository();
            firstGame = new Game(new RegularBoard(), true);
            secondGame = new Game(new RegularBoard(), false);
        }

        [TestMethod]
        public void WhenAddGame_ThenGameIsAddedToRepository()
        {
            gameRepository.AddGame(firstGame);

            Game actual = gameRepository.GetNewestGame();
            Assert.AreEqual(firstGame, actual);
        }

        [TestMethod]
        public void GivenMultipleGames_WhenGetNewestGame_ThenCorrectGameIsReturned()
        {
            gameRepository.AddGame(firstGame);
            gameRepository.AddGame(secondGame);

            Game actual = gameRepository.GetNewestGame();

            Assert.AreEqual(secondGame, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(GameNotFoundException))]
        public void GivenNoGames_WhenGetNewestGame_ThenError()
        {
            gameRepository.GetNewestGame();
        }

        [TestMethod]
        public void WhenUpdateNewestGame_ThenGameIsUpdated()
        {
            gameRepository.AddGame(firstGame);

            gameRepository.UpdateNewestGame(secondGame);

            Game actual = gameRepository.GetNewestGame();
            Assert.AreEqual(secondGame, actual);
        }
    }
}
