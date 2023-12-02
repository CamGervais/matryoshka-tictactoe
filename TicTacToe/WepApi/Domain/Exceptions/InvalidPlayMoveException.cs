namespace TicTacToe.WepApi.Domain.Exceptions
{
    public class InvalidPlayMoveException : Exception
    {
        public InvalidPlayMoveException() { }

        public InvalidPlayMoveException(string message)
            : base(message) { }

        public InvalidPlayMoveException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
