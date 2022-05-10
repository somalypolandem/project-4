using System;
using static System.Console;

namespace TicTacToe5
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\tTIC TAC TOE \n");
            while (true)
            {
                Menu();
            }


            static void Menu()
            {
                Console.WriteLine("\t~*~ Menu ~*~");
                Console.WriteLine("\t1 - New Game");
                Console.WriteLine("\t2 - About the author");
                Console.WriteLine("\t3 - Quit");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Game();
                        break;


                    case "2":
                        author();
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;
                }



                static void author()
                {
                    Console.Clear();
                    Console.WriteLine("Andrelouiz is the creator of the Tic Tac Toe game. It took him 20 years to write all the code.");
                    Console.WriteLine();

                }

                static void Game()
                {
                    int gameStatus = 0;
                    int currentPlayer = -1;
                    char[] Slots = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                    do
                    {
                        Console.Clear();

                        currentPlayer = GetNextPlayer(currentPlayer);

                        HeadsUpDisplay(currentPlayer);
                        DrawGameboard(Slots);

                        GameEngine(Slots, currentPlayer);


                        gameStatus = CheckWinner(Slots);

                    } while (gameStatus.Equals(0));

                    Console.Clear();
                    HeadsUpDisplay(currentPlayer);
                    DrawGameboard(Slots);

                    if (gameStatus.Equals(1))
                    {
                        Console.WriteLine($"Player {currentPlayer} has won!");
                        Console.WriteLine();

                        Console.WriteLine("Press enter to continue or any key to return to Menu.");
                        ConsoleKeyInfo keyPressed = ReadKey();

                        if (keyPressed.Key == ConsoleKey.Enter)
                        {
                            Game();
                        }
                        else
                        {
                            Menu();
                        }

                    }

                    if (gameStatus.Equals(2))
                    {
                        Console.WriteLine($"The game is a draw!");
                        Game();
                    }
                }

                 static int CheckWinner(char[] Slots)
                {
                    if (IsGameDraw(Slots))
                    {
                        return 2;
                    }

                    if (IsGameWinner(Slots))
                    {
                        return 1;
                    }

                    return 0;
                }

                 static bool IsGameDraw(char[] Slots)
                {
                    return Slots[0] != '1' &&
                           Slots[1] != '2' &&
                           Slots[2] != '3' &&
                           Slots[3] != '4' &&
                           Slots[4] != '5' &&
                           Slots[5] != '6' &&
                           Slots[6] != '7' &&
                           Slots[7] != '8' &&
                           Slots[8] != '9';
                }

                 static bool IsGameWinner(char[] Slots)
                {
                    if (SameSlot(Slots, 0, 1, 2))
                    {
                        return true;
                    }

                    if (SameSlot(Slots, 3, 4, 5))
                    {
                        return true;
                    }

                    if (SameSlot(Slots, 6, 7, 8))
                    {
                        return true;
                    }

                    if (SameSlot(Slots, 0, 3, 6))
                    {
                        return true;
                    }

                    if (SameSlot(Slots, 1, 4, 7))
                    {
                        return true;
                    }

                    if (SameSlot(Slots, 2, 5, 8))
                    {
                        return true;
                    }

                    if (SameSlot(Slots, 0, 4, 8))
                    {
                        return true;
                    }

                    if (SameSlot(Slots, 2, 4, 6))
                    {
                        return true;
                    }

                    return false;
                }

                 static bool SameSlot(char[] testSlots, int pos1, int pos2, int pos3)
                {
                    return testSlots[pos1].Equals(testSlots[pos2]) && testSlots[pos2].Equals(testSlots[pos3]);
                }

                 static void GameEngine(char[] Slots, int currentPlayer)
                {
                    bool notValidMove = true;

                    do
                    {
                        string userInput = Console.ReadLine();

                        if (!string.IsNullOrEmpty(userInput) &&
                            (userInput.Equals("1") ||
                            userInput.Equals("2") ||
                            userInput.Equals("3") ||
                            userInput.Equals("4") ||
                            userInput.Equals("5") ||
                            userInput.Equals("6") ||
                            userInput.Equals("7") ||
                            userInput.Equals("8") ||
                            userInput.Equals("9")))
                        {

                            int.TryParse(userInput, out var gamePlacementMarker);

                            char currentMarker = Slots[gamePlacementMarker - 1];

                            if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                            {
                                Console.WriteLine("Spot already taken, choose a different one.");
                            }
                            else
                            {
                                Slots[gamePlacementMarker - 1] = GetPlayerMarker(currentPlayer);

                                notValidMove = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid move, try again.");
                        }
                    } while (notValidMove);
                }

                static char GetPlayerMarker(int player)
                {
                    if (player % 2 == 0)
                    {
                        return 'O';
                    }

                    return 'X';
                }

                static void HeadsUpDisplay(int PlayerNumber)
                {

                    Console.WriteLine("Player 1: X");
                    Console.WriteLine("Player 2: O");
                    Console.WriteLine();
                    Console.WriteLine();

                }

                static void DrawGameboard(char[] Slots)
                {


                    Console.WriteLine($" {Slots[0]} | {Slots[1]} | {Slots[2]} ");
                    Console.WriteLine("---+---+---");
                    Console.WriteLine($" {Slots[3]} | {Slots[4]} | {Slots[5]} ");
                    Console.WriteLine("---+---+---");
                    Console.WriteLine($" {Slots[6]} | {Slots[7]} | {Slots[8]} ");
                }

                static int GetNextPlayer(int player)
                {
                    if (player.Equals(1))
                    {
                        return 2;
                    }

                    return 1;
                }

            }


        }
       
    }


}