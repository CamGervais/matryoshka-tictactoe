using Microsoft.AspNetCore.Mvc;
using TicTacToe.WepApi.Controllers.Dto;
using TicTacToe.WepApi.Domain;
using TicTacToe.WepApi.Domain.Dto;

namespace TicTacToe.WepApi.Controllers
{
    [ApiController]
    [Route("/game")]
    public class GameController : ControllerBase
    {
        private static Game game;

        private const string BOARD_TYPE_MATRYOSHKA = "matryoshka";

        [HttpPost("/game")]
        public IActionResult Create(CreateGameRequest createGameRequest)
        {
            Board board;
            if (createGameRequest.boardType == BOARD_TYPE_MATRYOSHKA)
            {
                board = new MatryoshkaBoard();
            }
            else
            {
                board = new RegularBoard();
            }
            game = new Game(board, createGameRequest.usesComputer);

            return Ok();
        }

        [HttpPut("/game/human")]
        public IActionResult HumanPlay(PlayMoveRequest playMoveRequest)
        {
            PlayMoveResponse playMoveResponse = game.HumanPlay(playMoveRequest.tileIndex);
            return Ok(playMoveResponse);
        }

        [HttpPut("/game/computer")]
        public IActionResult ComputerPlay()
        {
            PlayMoveResponse playMoveResponse = game.ComputerPlay();
            return Ok(playMoveResponse);
        }

        [HttpDelete("/game")]
        public IActionResult RestartGame(CreateGameRequest createGameRequest)
        {
            return Create(createGameRequest);
        }
    }
}
