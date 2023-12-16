using Microsoft.AspNetCore.Mvc;
using TicTacToe.WepApi.Controllers;
using TicTacToe.WepApi.Controllers.Dto;
using TicTacToe.WepApi.Service;

namespace TicTacToeTests.Controllers
{
    [TestClass]
    public class GameControllerTest
    {
        private GameController gameController;
        private GameService gameService;
        private PlayMoveRequest playMoveRequest;
        private CreateGameRequest createGameRequest;

        public GameControllerTest()
        {
            gameService = new GameService();
            gameController = new GameController(gameService);
            playMoveRequest = new PlayMoveRequest(0, 0);
            createGameRequest = new CreateGameRequest("regular", true);
        }

        [TestMethod]
        public void GivenCreateGameRequest_WhenCreate_ThenOk()
        {
            IActionResult result = gameController.Create(createGameRequest);
            OkResult? okResult = result as OkResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public void GivenExistingGameAndPlayMoveRequest_WhenHumanPlay_ThenOk()
        {
            gameController.Create(createGameRequest);

            IActionResult result = gameController.HumanPlay(playMoveRequest);
            OkObjectResult? okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public void GivenExistingGame_WhenComputerPlay_ThenOk()
        {
            gameController.Create(createGameRequest);

            IActionResult result = gameController.ComputerPlay();
            OkObjectResult? okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public void GivenCreateGameRequest_WhenRestart_ThenOk()
        {
            IActionResult result = gameController.Restart(createGameRequest);
            OkResult? okResult = result as OkResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
