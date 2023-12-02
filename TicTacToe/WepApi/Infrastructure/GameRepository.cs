using TicTacToe.Infrastructure.Exceptions;
using TicTacToe.WepApi.Domain;

namespace TicTacToe.WepApi.Infrastructure
{
    public class GameRepository
    {
        LinkedList<Game> games = new LinkedList<Game>();

        public void AddGame(Game game)
        {
            games.AddLast(game);
        }

        public Game GetNewestGame()
        {
            if (games.Count == 0)
            {
                throw new GameNotFoundException("No games saved.");
            }
            return games.Last();
        }

        public void UpdateNewestGame(Game game)
        {
            games.RemoveLast();
            AddGame(game);
        } 
    }
}
