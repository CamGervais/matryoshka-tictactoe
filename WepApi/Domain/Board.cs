using TicTacToe.WepApi.Domain.Dto;

namespace TicTacToe.WepApi.Domain
{
    public interface Board
    {
        List<int> GetTiles();
        void Play(int playerId, int tileIndex, ref GameStatus currentGameStatus, int playedElement = 0);
    }
}
