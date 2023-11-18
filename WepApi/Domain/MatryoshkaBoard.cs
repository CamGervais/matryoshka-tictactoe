namespace TicTacToe.WepApi.Domain
{
    public class MatryoshkaBoard : Board
    {
        private List<(int, int)> tiles;

        public MatryoshkaBoard() 
        { 
            tiles = new List<(int, int)>()
            {
                (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0)
            };
        }

        public List<int> GetTiles()
        {
            throw new NotImplementedException();
        }

        public void Play(int playerId, int tileIndex, ref GameStatus currentGameStatus, int playedElement = 0)
        {
            throw new NotImplementedException();
        }

        public void PlayBestNextMove(int playerId, ref GameStatus currentGameStatus)
        {
            throw new NotImplementedException();
        }
    }
}
