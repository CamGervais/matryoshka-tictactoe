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
        private int maxNumberOfTurns;
        private int turnCount;

        public Game(Board board, bool usesComputer, int maxNumberOfTurns)
        {
            this.board = board;
            this.usesComputer = usesComputer;
            this.maxNumberOfTurns = maxNumberOfTurns;
            currentPlayerId = 1;
            status = GameStatus.Ongoing;
            turnCount = 0;
        }

        public PlayMoveResponse HumanPlay(int tileIndex, int playedElement = 0)
        {
            board.Play(currentPlayerId, tileIndex, ref status, playedElement);
            turnCount++;
            CheckIfMaxTurnHit();
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
            turnCount++;
            CheckIfMaxTurnHit();
            SwitchCurrentPlayer();
            return new PlayMoveResponse(board.GetTiles(), status.ToString());
        }

        private void SwitchCurrentPlayer()
        {
            currentPlayerId = currentPlayerId == 1 ? 2 : 1;
        }

        private void CheckIfMaxTurnHit()
        {
            if (status == GameStatus.Ongoing && turnCount >= maxNumberOfTurns)
            {
                status = GameStatus.Draw;
            }
        }
    }
}
