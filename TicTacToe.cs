using System;
using System.Linq;

namespace TicTacToe
{
    internal class TicTacToe
    {
        // This is my grid represented as a 1d array
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        // This is to indicate palyer turn
        static int player = 1;

        // Dispaly method shows the board in the console
        private static void Display()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[0], board[1], board[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[3], board[4], board[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[6], board[7], board[8]);
            Console.WriteLine("     |     |      ");
        }

        private static bool CheckWin(char[] board) 
        {
            //First check for horizontal wins
            for (int i = 0; i < 7; i += 3) 
            {
                if (board[i] == board[i + 1] && board[i + 1] == board[i + 2]) 
                {
                    if (board[i] == 'O')
                    {
                        Console.WriteLine("Horizontal win for {0}. Player 1 is the winnner!", board[i]);
                        return true;
                    }
                    else 
                    {
                        Console.WriteLine("Horizontal win for {0}. Player 2 is the winner!", board[i]);
                        return true;
                    }
                    
                }
            }

            // Second check for vertical wins
            for (int i = 0; i < 4; i += 3) 
            {
                if (board[i] == board[i + 3] && board[i + 3] == board[i + 6]) 
                {
                    if (board[i] == 'O')
                    {
                        Console.WriteLine("Vertical win for {0}. Player 1 is the winner!", board[i]);
                        return true;
                    }
                    else 
                    {
                        Console.WriteLine("Vertical win for {0}. Player 2 is the winner!", board[i]);
                        return true;
                    }
                }
            }
            // Third check for main diagonal wins
            if (board[0] == board[4] && board[4] == board[8]) 
            {
                if (board[0] == 'O')
                {
                    Console.WriteLine("Main Diagonal win for {0}. Player 1 is the winner!", board[0]);
                    return true;
                }
                else 
                {
                    Console.WriteLine("Main diagonal win for {0}. Player 2 is the winner!", board[0]);
                    return true;
                }
            }

            //Fourth check for secondary diagonal wins
            if (board[2] == board[4] && board[4] == board[6]) 
            {
                if (board[2] == 'O') 
                {
                    Console.WriteLine("Secondary Diagonal win for {0}. Player 1 is the winner!", board[2]);
                    return true;
                }
                else
                {
                    Console.WriteLine("Main diagonal win for {0}. Player 2 is the winner!", board[2]);
                    return true;
                }

            }


            return false;
        }

        static void Main(string[] args)
        {
            Display();
            int choice;

            Console.WriteLine("Welcome to TicTacToe.Press exit if you want to stop the game! :-(\n");
            string input = "";

            // If the user does not hit 'exit' the game continues until a winner has been decided
            while (input != "exit") 
            {
                
                if (player == 1)
                {
                    Console.Write("Player 1 turn.Choose a field to play:");
                    input = Console.ReadLine();
                    // Checking the input once again to determine if the game will continue
                    if (input == "exit") break;
                    // Check the input in case it is not a digit between 1-9
                    while (!(input.Length == 1 && input.All(char.IsDigit))) 
                    {
                        Console.Write("Invalid input!Please give a valid field number(1-9)! :");
                        input = Console.ReadLine();
                        if (input == "exit") break;
                    }
                    // Turn the input into number
                    choice = int.Parse(input);
                    // Ask for the field again in case it is occupied already
                    while (board[choice - 1] == 'X' || board[choice - 1] == 'O') 
                    {
                        Console.WriteLine("Field already marked!Please choose another one:");
                        input = Console.ReadLine();
                        if (input == "exit") break;
                        choice = int.Parse(input);
                    }
                    // If everything seems correct change the board, clear the console and show the new board
                    board[choice - 1] = 'O';
                    Console.Clear();
                    Display();
                    if (CheckWin(board)) break;
                    player = 2;
                }
                else
                {
                    Console.Write("Player 2 turn.Choose a field to play:");
                    input = Console.ReadLine();
                    // Checking the input once again to determine if the game will continue
                    if (input == "exit") break;
                    // Check the input in case it is not a digit between 1-9
                    while (!(input.Length == 1 && input.All(char.IsDigit)))
                    {
                        Console.Write("Invalid input!Please give a valid field number(1-9)! :");
                        input = Console.ReadLine();
                        if (input == "exit") break;
                    }
                    choice = int.Parse(input);
                    // Ask for the field again in case it is occupied already
                    while (board[choice - 1] == 'X' || board[choice - 1] == 'O')
                    {
                        Console.WriteLine("Field already marked!Please choose another one:");
                        input = Console.ReadLine();
                        if (input == "exit") break;
                        choice = int.Parse(input);
                    }
                    // If everything seems correct change the board, clear the console and show the new board
                    board[choice - 1] = 'X';
                    Console.Clear();
                    Display();
                    if (CheckWin(board)) break;
                    player = 1;
                }
            }

        }
    }
}
