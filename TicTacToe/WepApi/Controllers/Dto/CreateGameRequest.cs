namespace TicTacToe.WepApi.Controllers.Dto
{
    public record CreateGameRequest(
        string boardType,
        bool usesComputer
    );
}
