namespace TicTacToe.WepApi.Domain.Dto
{
    public record PlayMoveResponse(
        int CurrentPlayerId,
        bool GameWon,
        bool Draw
    );
}
