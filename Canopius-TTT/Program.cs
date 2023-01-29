using TTT;
using TTT.Core.Numerics;

while (true)
{
    Console.Write("Press x to play: ");
    if (Console.ReadLine() == "x")
    {
        TicTacToe game = new TicTacToe(new num2<int>(3, 3), 3);
        Console.WriteLine(game.GetRules() ?? "");
        while (game.NextTurn())
        {
            Console.WriteLine(GetAnnouncePlayerTurnMessage(game.CurrentPlayer));
            int tileNum = GetPlayerTurnInput();
            while (game.TryMakeTurn(tileNum, out string failReason) == false)
            {
               if (failReason != null && failReason != "") { Console.WriteLine(failReason); }
               tileNum = GetPlayerTurnInput();
            }

            DisplayGrid();
        }
        if (game.TryGetWinner(out string winner))
        {
            Console.WriteLine(GetWinnerMessage(winner));
        }
        else
        {
            Console.WriteLine(GetDrawMessage());
        }
    }

}

int GetPlayerTurnInput()
{
    int tileNum = -1;
    bool selectedTile = false;
    while (selectedTile == false)
    {
        Console.Write("Input the tile you'd like to play: ");
        var tileInput = Console.ReadLine();
        selectedTile = int.TryParse(tileInput, out tileNum);
    }
    return tileNum;
}
string GetWinnerMessage(string winner)
{
    if (winner == null || winner == "") { return "No winner!"; }
    return string.Format("{0} has won the game!", winner);
}
string GetDrawMessage()
{
    return "Draw!";
}
string GetAnnouncePlayerTurnMessage(string currentPlayer)
{
    return string.Format("Player {0}'s turn!", currentPlayer);
}
void DisplayGrid()
{
    //
}