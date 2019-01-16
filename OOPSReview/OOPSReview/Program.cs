using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSReview
{
    class Program
    {
        static void Main(string[] args)
        {

            //The key word "new" cause an instance (occurance) of the specified
            //   class to be created and placed in the
            //   receiving variable
            //the variable is a pointer address to the actual
            //   physical memory location of the instance
            

            //declaring an instance (occurance) of the specified
            //   class will not create a physical instance, just a 
            //   a pointer which can hold a physical instance
            Turn theTurn;

            //new causes the constructor of a class to execute
            //   and a phyiscal instance to be created
            Die player1 = new Die();            //default
            Die player2 = new Die(6, "green");  //greedy


            //Track the game plays
            List <Turn> turnList = new List<Turn>();

            string menuChoice = "";
            do
            {
                //Console is a static class
                Console.WriteLine("\nMake a choice\n");
                Console.WriteLine("A) Roll");
                Console.WriteLine("B) Set number of dice sides");
                Console.WriteLine("C) Display Current Game Stats");
                Console.WriteLine("X) Exit\n");
                Console.Write("Enter your choice:\t");
                menuChoice = Console.ReadLine();

                //user friendly error handling
                try
                {
                    switch (menuChoice.ToUpper())
                    {
                        case "A":
                            {
                                //Die is a non-static class

                                //generate a new FaceValue
                                player1.RollDie();
                                player2.RollDie();
                                // save the roll 
                                //method a) default constructor and individual setting
                                theTurn = new Turn();
                                theTurn.Player1Result = player1.FaceValue;
                                theTurn.Player2Result = player2.FaceValue;

                                //method b) greedy constructor
                                theTurn = new Turn(player1.FaceValue, player2.FaceValue);

                                //display the round results
                                if (player1.Sides == 6)
                                {
                                    Console.WriteLine("Player 1 rolled:\n");
                                    DrawDie(player1.FaceValue);
                                    Console.WriteLine("Player 2 rolled:\n");
                                    DrawDie(player2.FaceValue);
                                }

                                else
                                {
                                    Console.WriteLine("Player 1 rolled {0}", player1.FaceValue);
                                    Console.WriteLine("Player 2 rolled {0}", player2.FaceValue);
                                }


                                if (player1.FaceValue > player2.FaceValue)
                                {
                                    Console.WriteLine("Player 1 Wins!");
                                }
                                else if (player1.FaceValue < player2.FaceValue)
                                {
                                    Console.WriteLine("Player 2 Wins!");
                                }
                                else
                                {
                                    Console.WriteLine("Tie!");
                                }





                                //track the round
                                turnList.Add(theTurn);
                                break;
                            }
                        case "B":
                            {
                                string inputSides = "";
                                int sides = 0;

                                Console.Write("Enter your number of desired sides (greater than 1):\t");
                                inputSides = Console.ReadLine();

                                //using the conversion try version of parsing
                                // TryParse has two parameters
                                // one: in string to convert
                                // two: the output conversion value if the string can be
                                //      converted
                                // successful conversion returns a true bool
                                // failed conversion returns a false bool
                                if (int.TryParse(inputSides, out sides))
                                {
                                    //validation of the incoming value
                                    if (sides > 1)
                                    {
                                        //set the die instance Sides
                                        player1.SetSides(sides);
                                        player2.SetSides(sides);
                                    }
                                    else
                                    {
                                        throw new Exception("You did not enter a numeric value greater than 1.");
                                    }
                                }
                                else
                                {
                                    throw new Exception("You did not enter a numeric value.");
                                }
                                break;
                            }
                        case "C":
                            {
                                //Display the current players' stats
                                DisplayCurrentPlayerStats(turnList);
                                break;
                            }
                        case "X":
                            {
                                //Display the final players' stats
                                DisplayCurrentPlayerStats(turnList);
                                Console.WriteLine("\nThank you for playing.");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Your choice was invalid. Try again.");
                                break;
                            }
                    }//eos
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + ex.Message);
                    Console.ResetColor();
                }
            } while (menuChoice.ToUpper() != "X");
        }//eomain

        public static void DisplayCurrentPlayerStats(List<Turn> turnList)
        {
            
            int wins1 = 0;
            int wins2 = 0;
            int draws = 0;

            //travser the List<Turn> to calculate wins, losses, and draws
            //could also be:
            //foreach (var turn in turnList)
            //  in this case var will take on the datatype of the list provided but it will be delayed
            foreach (Turn turn in turnList)
            {
                if (turn.Player1Result > turn.Player2Result)
                {
                    wins1++;
                }
                else if (turn.Player1Result < turn.Player2Result)
                {
                    wins2++;
                }
                else
                {
                    draws++;
                }
            }

            //display the results
            Console.WriteLine("\n Total Rounds: " + (wins1 + wins2 + draws).ToString());
            Console.WriteLine("\nPlayer1: Wins: {0}  Player2: Wins: {1}  Total Draws: {2}",
                wins1, wins2, draws);
           
        }
        public static void DrawDie(int face)
        {
            int imageSize = 9;
            int pipCounter = 0;
            char sideChar = '#';
            char pipChar = 'O';
            int[] pipList;

            switch (face)
            {
                case 1:
                    pipList = new int[7] { 0, 0, 0, 1, 0, 0, 0 };
                    break;
                case 2:
                    pipList = new int[7] { 1, 0, 0, 0, 0, 0, 1 };
                    break;
                case 3:
                    pipList = new int[7] { 1, 0, 0, 1, 0, 0, 1 };
                    break;
                case 4:
                    pipList = new int[7] { 1, 1, 0, 0, 0, 1, 1 };
                    break;
                case 5:
                    pipList = new int[7] { 1, 1, 0, 1, 0, 1, 1 };
                    break;
                case 6:
                    pipList = new int[7] { 1, 1, 1, 0, 1, 1, 1 };
                    break;
                default:
                    pipList = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
                    break;
            }

            for (int row = 0;row < imageSize; row++)
            {
                //Full Line
                if (row == 0 | row == 8)
                {
                    for (int col = 0; col < imageSize; col++)
                    {
                        Console.Write(sideChar);
                    }
                }
                //pip line
                else if (row == 2 || row == 4 || row == 6)
                {
                    
                    for (int col = 0; col < imageSize; col++)
                    {
                        if (col == 0 || col == 8) Console.Write(sideChar);
                        else if ((row == 2 || row == 6) && (col == 2 || col == 6))
                        {
                            if (pipList[pipCounter] == 1) Console.Write(pipChar);
                            else Console.Write(' ');
                            pipCounter++;
                        }
                        else if (row == 4 && (col == 2 || col == 4 || col == 6))
                        {
                            if (pipList[pipCounter] == 1) Console.Write(pipChar);
                            else Console.Write(' ');
                            pipCounter++;
                        }
                        else Console.Write(' ');
                    }

                }
                //Blank line
                else
                {
                    for (int col = 0; col < imageSize; col++)
                    {
                        if (col == 0 || col == 8) Console.Write(sideChar);
                        else Console.Write(' ');
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
