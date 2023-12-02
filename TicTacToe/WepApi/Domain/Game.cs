using TicTacToe.WepApi.Domain.Dto;
using TicTacToe.WepApi.Domain.Exceptions;

namespace TicTacToe.WepApi.Domain
{
    public class Game
    {
        private Board board;
        private GameStatus status;
        private int currentPlayerId;
        private bool usesComputer;

        public Game(Board board, bool usesComputer)
        {
            this.board = board;
            this.usesComputer = usesComputer;
            currentPlayerId = 1;
            status = GameStatus.Ongoing;
        }

        public PlayMoveResponse HumanPlay(int tileIndex, int playedElement = 0)
        {
            board.Play(currentPlayerId, tileIndex, ref status, playedElement);
            SwitchCurrentPlayer();
            return new PlayMoveResponse(board.GetTiles(), status.ToString());
        }

        public PlayMoveResponse ComputerPlay()
        {
            if (!usesComputer)
            {
                throw new InvalidPlayMoveException("Computer was asked to play even though current game isn't against CPU.");
            }
            board.PlayBestNextMove(currentPlayerId, ref status);
            SwitchCurrentPlayer();
            return new PlayMoveResponse(board.GetTiles(), status.ToString());
        }

        private void SwitchCurrentPlayer()
        {
            currentPlayerId = currentPlayerId == 1 ? 2 : 1;
        }
    }
}
