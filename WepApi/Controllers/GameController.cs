﻿using Microsoft.AspNetCore.Mvc;
using TicTacToe.WepApi.Controllers.Dto;
using TicTacToe.WepApi.Domain;
using TicTacToe.WepApi.Domain.Dto;

namespace TicTacToe.WepApi.Controllers
{
    [ApiController]
    [Route("/game")]
    public class GameController : ControllerBase
    {
        private static Game game = new Game();

        [HttpPost("/game/play")]
        public IActionResult Play(PlayMoveRequest playMoveRequest)
        {
            PlayMoveResponse playMoveResponse = game.Play(playMoveRequest.TileIndex);
            return Ok(playMoveResponse);
        }
    }
}