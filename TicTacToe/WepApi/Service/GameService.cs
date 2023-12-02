using TicTacToe.WepApi.Controllers.Dto;
using TicTacToe.WepApi.Domain;
using TicTacToe.WepApi.Domain.Dto;
using TicTacToe.WepApi.Infrastructure;

namespace TicTacToe.WepApi.Service
{
    public class GameService
    {
        private GameFactory gameFactory;
        private GameRepository gameRepository;

        public GameService()
        {
            gameFactory = new GameFactory();
            gameRepository = new GameRepository();
        }

        public void CreateGame(CreateGameRequest createGameRequest)
        {
            Game newGame = gameFactory.CreateGame(createGameRequest.boardType, createGameRequest.usesComputer);
            gameRepository.AddGame(newGame);
        }

        public PlayMoveResponse HumanPlay(PlayMoveRequest playMoveRequest)
        {
            Game game = gameRepository.GetNewestGame();
            PlayMoveResponse playMoveResponse = game.HumanPlay(playMoveRequest.tileIndex);
            gameRepository.UpdateNewestGame(game);
            return playMoveResponse;
        }

        public PlayMoveResponse ComputerPlay()
        {
            Game game = gameRepository.GetNewestGame();
            PlayMoveResponse playMoveResponse = game.ComputerPlay();
            gameRepository.UpdateNewestGame(game);
            return playMoveResponse;
        }
    }
}
