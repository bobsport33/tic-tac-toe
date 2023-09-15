using System;

namespace Arrays
{
    internal class Program
    {
        static string[,] board =
        {
            {"1","2","3"},
            {"4", "5","6"},
            {"7", "8", "9"}
        };

        static bool checkForWin(string[,] board)
        {

            // horizontal check
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
                {
                    return true;
                }
            }
            // veritcal check
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[0, i] == board[1, i] && board[0, i] == board[2, i])
                {
                    return true;
                }
            }

            // diagnal check
            if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2])
            {
                return true;
            }
            if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0])
            {
                return true;
            }

            return false;
        }

        static void drawBoard(string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.WriteLine("   |   |   ");
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(" " + board[i, j] + " ");
                    if (j != 2)
                    {
                        Console.Write('|');
                    }
                }
                Console.WriteLine("");
                if (i != 2)
                {
                    Console.WriteLine("___|___|___");
                } else
                {
                    Console.WriteLine("   |   |   ");
                }

            }
        }

        static void playGame()
        {
            bool winner = false;
            int playerId = 1;
            string messageFromPrevTurn = "";

            // Gameplay
            while (!winner)
            {
                //clear console
                Console.Clear();


                drawBoard(board);
                string userInput = "";
                Console.WriteLine(messageFromPrevTurn);
                messageFromPrevTurn = "";
                // Ask for input

                while (userInput == "")
                {
                    Console.WriteLine("Player " + playerId + ": Choose your field!");
                    userInput = Console.ReadLine();

                    //Check if input is valid
                    try
                    {
                        int inputAsInt = Int32.Parse(userInput);

                    }
                    catch
                    {
                        messageFromPrevTurn = "Not a valid input, try again.";

                    }
                }

                // Find element in board and check to make sure it can be updated
                string currentValueOnBoard = "";
                switch (userInput)
                {
                    case "1":
                        currentValueOnBoard = board[0, 0];
                        break;
                    case "2":
                        currentValueOnBoard = board[0, 1];
                        break;
                    case "3":
                        currentValueOnBoard = board[0, 2];
                        break;
                    case "4":
                        currentValueOnBoard = board[1, 0];
                        break;
                    case "5":
                        currentValueOnBoard = board[1, 1];
                        break;
                    case "6":
                        currentValueOnBoard = board[1, 2];
                        break;
                    case "7":
                        currentValueOnBoard = board[2, 0];
                        break;
                    case "8":
                        currentValueOnBoard = board[2, 1];
                        break;
                    case "9":
                        currentValueOnBoard = board[2, 2];
                        break;
                }

                if (currentValueOnBoard == "X" || currentValueOnBoard == "O")
                {
                    messageFromPrevTurn = "Already been selected, please pick a valid space.";
                    continue;

                }
                // Update board
                string letterForBoard;
                if (playerId == 1)
                {
                    letterForBoard = "X";
                }
                else
                {
                    letterForBoard = "O";
                }

                switch (userInput)
                {
                    case "1":
                        board[0, 0] = letterForBoard;
                        break;
                    case "2":
                        board[0, 1] = letterForBoard;
                        break;
                    case "3":
                        board[0, 2] = letterForBoard;
                        break;
                    case "4":
                        board[1, 0] = letterForBoard;
                        break;
                    case "5":
                        board[1, 1] = letterForBoard;
                        break;
                    case "6":
                        board[1, 2] = letterForBoard;
                        break;
                    case "7":
                        board[2, 0] = letterForBoard;
                        break;
                    case "8":
                        board[2, 1] = letterForBoard;
                        break;
                    case "9":
                        board[2, 2] = letterForBoard;
                        break;
                }

                // redraw board
                drawBoard(board);

                // check for winner
                winner = checkForWin(board);
                if (winner) { break; }

                //toggle user
                if (playerId == 1)
                {
                    playerId = 2;
                }
                else
                {
                    playerId = 1;
                }


            }
            Console.Clear();
            drawBoard(board);
             Console.WriteLine("The Winner is Player " + playerId);
        }
        static void Main(string[] args)
        {
            playGame();
            Console.Read();
        }
    }
}