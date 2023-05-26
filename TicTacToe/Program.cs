using System;

while (true)
{
    Game();
}

static void Game()
{
    // Initialize the game and the game field.
    bool gameOver = false;
    string[,] gamefield = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
    string used = string.Empty;

    // Initialize the game as player one with the X symbol and switch at the end of each go.
    string go = "Player 1";
    string symbol = "X";

    Console.WriteLine("     |     |     ");
    Console.WriteLine("  {0}  |  {1}  |  {2}  ", gamefield[0, 0], gamefield[0, 1], gamefield[0, 2]);
    Console.WriteLine("_____|_____|_____");
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  {0}  |  {1}  |  {2}  ", gamefield[1, 0], gamefield[1, 1], gamefield[1, 2]);
    Console.WriteLine("_____|_____|_____");
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  {0}  |  {1}  |  {2}  ", gamefield[2, 0], gamefield[2, 1], gamefield[2, 2]);
    Console.WriteLine("     |     |     ");
    Console.WriteLine("");

    while (!gameOver)
    {
        // the variable input will be used in the switch to update the game field
        // the userInput comes from the console and is also used to update the list of used fields
        int input;
         
        Console.WriteLine("\n{0}: Choose your field!", go);
        string userInput = Console.ReadLine();

        if (!int.TryParse(userInput, out input) || input < 1 || input > 9)
        {
            Console.WriteLine("\nPlease enter a valid number!");
            continue;
        }

        if (used.Contains(userInput))
        {
            Console.WriteLine("\nField already taken, please pick again!");
            continue;
        }

        // Add the current input to the used inputs and update the game field from the input
        used += userInput;

        switch (input)
        {
            case 1:
                gamefield[0, 0] = symbol; break;
            case 2:
                gamefield[0, 1] = symbol; break;
            case 3:
                gamefield[0, 2] = symbol; break;
            case 4:
                gamefield[1, 0] = symbol; break;
            case 5:
                gamefield[1, 1] = symbol; break;
            case 6:
                gamefield[1, 2] = symbol; break;
            case 7:
                gamefield[2, 0] = symbol; break;
            case 8:
                gamefield[2, 1] = symbol; break;
            case 9:
                gamefield[2, 2] = symbol; break;
        }

        // Clear the console and draw the updated game field
        Console.Clear();
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", gamefield[0, 0], gamefield[0, 1], gamefield[0, 2]);
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", gamefield[1, 0], gamefield[1, 1], gamefield[1, 2]);
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", gamefield[2, 0], gamefield[2, 1], gamefield[2, 2]);
        Console.WriteLine("     |     |     ");

        // Check for winner
        gameOver = Checker(gamefield);

        // Player wins logic
        if (gameOver)
        {
            Console.WriteLine("\n{0} wins!", go);
            Console.WriteLine("Press any key to reset the game.");
            Console.ReadKey();
            Console.Clear();
            break;
        }

        // If there's no winner check for a draw
        // Draw logic
        if (used.Length == 9)
        {
            Console.WriteLine("\nIt's a draw!");
            Console.WriteLine("Press any key to reset the game.");
            Console.ReadKey();
            Console.Clear();
            break;
        }

        // Otherwise we go into the next round
        // Switch turn logic
        if (go == "Player 1")
        {
            go = "Player 2";
            symbol = "O";
        }
        else
        {
            go = "Player 1";
            symbol = "X";
        }
    }
}

static bool Checker(string[,] board)
{
    // This function takes the board multidimensional array as an argument and checks if there's a winner

    // Check for columns and rows
    for (int i = 0; i < board.GetLength(0); i++)
    {
        if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
            return true;
        if (board[0, i] == board[1, i] && board[0, i] == board[2, i])
            return true;
    }
    // Check for diagonals
    if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2])
        return true;
    if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0])
        return true;
    return false;
}