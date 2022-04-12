using CSharpMasterclass90;

Board Game = new Board(5); // 3, 5, 7, 9, 11 etc so (size - 1) is divisible by 2

bool playAgain = true;
while(playAgain)
{
    bool gameOver = false;
    char player = 'O';
    while (!gameOver)
    {
        Console.Clear();
        Game.PrintBoard();

        if (player == 'O')
            player = 'X';
        else
            player = 'O';

        while (!Game.SetField(player))
            ;

        gameOver = Game.GameOver(ref player);
    }

    Console.Clear();
    Game.PrintBoard();

    if(player != '?')
        Console.WriteLine("Player {0} wins", player);
    else
        Console.WriteLine("Draw");

    string? input = null;
    while (input == null || input.ToLower() != "n" && input.ToLower() != "y")
    {
        Console.Write("Try again? (y)es or (n)o > ");
        input = Console.ReadLine();
    }

    if (input.ToLower() == "n")
        playAgain = false;
    else
        Game.ResetGame();
}
