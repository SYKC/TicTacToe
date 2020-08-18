using System;
using System.Text.RegularExpressions;

namespace TicTacToe
{

    static class winner
    {
        //Global Variables to store the times the players win for the leaderboard
        public static int winner1 = 0;
        public static int winner2 = 0;
    }
    class Program
    {
        static void initing(String[] box) //Initialising the boxes
        {
            for (int i = 1; i < 10; i++)
            {
                box[i] = i.ToString();
            }

        }

        static void display(String[] box) //Display the boxes in grid form
        {
            Console.WriteLine();
            Console.WriteLine(" {0} | {1} | {2} ", box[7], box[8], box[9]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", box[4], box[5], box[6]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", box[1], box[2], box[3]);
            Console.WriteLine();
        }

        static Boolean SomeoneWin(Boolean terminate, String[] box) //Checking is someone is winning
        {
            terminate = false;
            if ((box[1] == box[2]) && (box[2] == box[3]) && (box[1] != null))
            {
                terminate = true;
            }
            else if ((box[4] == box[5]) && (box[5] == box[6]) && (box[4] != null))
            {
                terminate = true;
            }
            else if ((box[7] == box[8]) && (box[8] == box[9]) && (box[7] != null))
            {
                terminate = true;
            }
            else if ((box[1] == box[4]) && (box[4] == box[7]) && (box[1] != null))
            {
                terminate = true;
            }
            else if ((box[2] == box[5]) && (box[5] == box[8]) && (box[2] != null))
            {
                terminate = true;
            }
            else if ((box[3] == box[6]) && (box[6] == box[9]) && (box[3] != null))
            {
                terminate = true;
            }
            else if ((box[1] == box[5]) && (box[5] == box[9]) && (box[1] != null))
            {
                terminate = true;
            }
            else if ((box[3] == box[5]) && (box[5] == box[7]) && (box[3] != null))
            {
                terminate = true;
            }
            return terminate;
        }

        static void playing(int i, string[] box) //Putting O or X in the boxes
        {
            if ((i % 2) == 0) //to output O or X
            {
                Console.WriteLine("-> O turn <-");
            }

            else
            {
                Console.WriteLine("-> X turn <-");
            }
            Console.Write("In which box do you want to play: ");

            String input = Console.ReadLine();

            //Verify that input is not alphabet or symbol or empty
            int x = validate(input);

            while (((box[x] == "O") || (box[x] == "X")))
            {
                Console.Write("Invalid move. Please input empty box: ");
                input = Console.ReadLine();
                x = validate(input);
            }

            if ((i % 2) == 0)
            {
                box[x] = "O";
            }
            if ((i % 2) != 0)
            {
                box[x] = "X";
            }

        }

        static int validate(String input) //Validate input
        {
            Regex regex1 = new Regex("^[a-zA-Z]");
            Regex regex2 = new Regex(@"\W|_");
            Regex regex4 = new Regex("^[1-9]{1}$");
            while (!(regex4.IsMatch(input)))
            {
                if (((regex1.IsMatch(input)) || (regex2.IsMatch(input)) || (input == "")))
                {
                    Console.Write("Invalid input. Input Again: ");
                }
                else if ((input.Length > 1) || (input == "0"))
                {
                    Console.Write("Number not in range. Input Again: ");
                }
                input = Console.ReadLine();
            }
            return (int.Parse(input));
        } 
        static void winDisplay(int i) //Dipslay winner
        {
            String PlayerWin="";
            Console.WriteLine("#####################");
            if ((i % 2) == 0)
            {
                PlayerWin = "1(O)";
                winner.winner1++;
            }
            if ((i % 2) != 0)
            {
                PlayerWin = "2(X)";
                winner.winner2++;
            }
            Console.WriteLine("# Player {0} Wins! #",PlayerWin);
            Console.WriteLine("#####################");
           
        }

        static void play(Boolean terminate, int i, String[] box, Boolean draw) //Play and check for draw
        {
            while (terminate != true)
            {
                playing(i, box);
                display(box);
                if (i > 3 && i <= 8)
                {
                    terminate = SomeoneWin(terminate, box);
                    if (i == 8 && terminate == false)
                    {
                        terminate = true;
                        draw = true;
                        Console.WriteLine("Draw");
                        Console.WriteLine("No Winner!");
                    }
                    
                }
                
                if (terminate == true && draw == false)
                {
                    winDisplay(i);
                }
                i++;
            }
        }

        static void displayHelp(String[] box) //Display of instructions
        {
            Console.WriteLine("==================================================================================================");
            Console.WriteLine("HOW TO PLAY");
            Console.WriteLine("__________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("1. The game is played on a grid that's 3 squares by 3 squares labelled from 1 to 9.");
            Console.WriteLine("2. Players take turns putting their marks(O/X) in empty squares.");
            Console.WriteLine("3. The first player to get 3 of her marks in a row(up, down, across, or diagonally) is the winner.");
            Console.WriteLine("4. When all 9 squares are full, the game is over.If no player has 3 marks in a row,\n   the game ends in a tie.");

            initing(box);
            display(box);
            Console.WriteLine("==================================================================================================");
        } 

        static void Main(string[] args)
        {
            String[] box = new String[10];
            initing(box);

            Boolean terminate = false;
            Boolean draw = false;

            Console.WriteLine("Welcome to Tic Tac Toe!");


            
            Regex regex3 = new Regex("^[0-2]{1}$");

            int i = 0;
            int choice=0;
            
            while (choice !=2)
            {
                if (choice == 0)
                {
                    Console.WriteLine();
                    displayHelp(box);
                }
                else
                {
                    play(terminate, i, box, draw);
                    Console.WriteLine();
                    Console.WriteLine("-----------------");
                    Console.WriteLine("---LEADERBOARD---");
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Player 1 : {0}", winner.winner1);
                    Console.WriteLine("Player 2 : {0}", winner.winner2);
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("------------------");
                Console.WriteLine("-------MENU-------");
                Console.WriteLine("------------------");
                if (choice != 0)
                {
                    Console.WriteLine("Help. Input 0.");
                }
                Console.WriteLine("Play, Input 1.");
                Console.WriteLine("Exit, Input 2.");
                Console.Write("Choice: ");
                String input = Console.ReadLine();

                while (!(regex3.IsMatch(input)))
                {
                    Console.Write("Invalid Choice. Input Choice Again: ");
                    input = Console.ReadLine();
                }

                choice = Convert.ToInt32(input);
                if (choice ==1)
                {
                    initing(box);
                    Console.WriteLine();
                    Console.WriteLine("-----------------");
                    Console.WriteLine("----NEW GAME----");
                    Console.WriteLine("-----------------");
                    display(box);
                }
            }
            
            Console.ReadKey();
        }
    }
}
