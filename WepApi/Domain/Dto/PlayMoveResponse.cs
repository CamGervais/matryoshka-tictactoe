namespace TicTacToe.WepApi.Domain.Dto
{
    public record PlayMoveResponse(
        int currentPlayerId,
        bool gameWon,
        bool draw
    );
}
