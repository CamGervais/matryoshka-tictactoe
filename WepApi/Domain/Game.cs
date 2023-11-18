using TicTacToe.WepApi.Domain.Dto;

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
            board.Play(currentPlayerId, tileIndex, ref status);
            PlayMoveResponse playMoveResponse = new PlayMoveResponse(board.GetTiles(), status.ToString());
            SwitchCurrentPlayer();
            return playMoveResponse;
        }

        public PlayMoveResponse ComputerPlay()
        {

        }

        private void SwitchCurrentPlayer()
        {
            currentPlayerId = currentPlayerId == 1 ? 2 : 1;
        }
    }
}
