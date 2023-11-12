namespace TicTacToe.WepApi.Domain.Dto
{
    public record PlayMoveResponse(
        List<int> currentBoard,
        int gameWinner,
        bool draw
    );
}
