namespace TicTacToe.WepApi.Domain.Dto
{
    public record GetGameStatusResponse(
        List<int> tiles,
        int winner,
        bool draw
    );
}
