using Microsoft.AspNetCore.Mvc;
using TicTacToe.WepApi.Controllers.Dto;
using TicTacToe.WepApi.Domain.Dto;
using TicTacToe.WepApi.Service;

namespace TicTacToe.WepApi.Controllers
{
    [ApiController]
    [Route("/game")]
    public class GameController : ControllerBase
    {
        private GameService gameService;

        public GameController(GameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpPost("/game")]
        public IActionResult Create(CreateGameRequest createGameRequest)
        {
            gameService.CreateGame(createGameRequest);
            return Ok();
        }

        [HttpPut("/game/human")]
        public IActionResult HumanPlay(PlayMoveRequest playMoveRequest)
        {
            PlayMoveResponse playMoveResponse = gameService.HumanPlay(playMoveRequest);
            return Ok(playMoveResponse);
        }

        [HttpPut("/game/computer")]
        public IActionResult ComputerPlay()
        {
            PlayMoveResponse playMoveResponse = gameService.ComputerPlay();
            return Ok(playMoveResponse);
        }

        [HttpDelete("/game")]
        public IActionResult Restart(CreateGameRequest createGameRequest)
        {
            return Create(createGameRequest);
        }
    }
}
