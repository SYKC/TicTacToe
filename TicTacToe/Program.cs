using System;
using System.Text.RegularExpressions;

namespace TicTacToe
{

    static class winner
    {
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
            Console.WriteLine("{0} | {1} | {2} ", box[7], box[8], box[9]);
            Console.WriteLine("----------");
            Console.WriteLine("{0} | {1} | {2} ", box[4], box[5], box[6]);
            Console.WriteLine("----------");
            Console.WriteLine("{0} | {1} | {2} ", box[1], box[2], box[3]);
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
            Console.Write("Enter the boxnum: ");

            String input = Console.ReadLine();
            Regex regex1 = new Regex("^[a-zA-Z]");
            Regex regex2 = new Regex(@"\W|_");

            //Verify that input is not alphabet or symbol or empty
            int x = validate(regex1, regex2, input);

            while (((box[x] == "O") || (box[x] == "X")))
            {
                Console.Write("Invalid move. Please input empty box: ");
                input = Console.ReadLine();
                x = validate(regex1, regex2, input);
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

        static int validate(Regex regex1, Regex regex2, String input)
        {
            while ((regex1.IsMatch(input)) || (regex2.IsMatch(input)) || (input == "") || (input.Length > 1) || (input == "0"))
            {
                if (((regex1.IsMatch(input)) || (regex2.IsMatch(input)) || (input == "")))
                {
                    Console.Write("Invalid input. Input Again: ");
                }
                if ((input.Length > 1) || (input == "0"))
                {
                    Console.Write("Number not in range. Input Again: ");
                }
                input = Console.ReadLine();
            }
            return (int.Parse(input));
        }
        static void winDisplay(int i)
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

        static void Main(string[] args)
        {
            String[] box = new String[10];
            initing(box);

            Boolean terminate = false;
            Boolean draw = false;
            display(box);
            int i = 0;
            int choice=1;

            while (choice == 1)
            {
                play(terminate, i, box, draw);
                Console.WriteLine();
                Console.WriteLine("-----------------");
                Console.WriteLine("---Leaderboard---");
                Console.WriteLine("-----------------");
                Console.WriteLine("Player 1 : {0}", winner.winner1);
                Console.WriteLine("Player 2 : {0}", winner.winner2);
                Console.WriteLine();
                Console.WriteLine("Play again, Input 1.");
                Console.WriteLine("Exit, Input 2.");
                
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice ==1)
                {
                    initing(box);
                    Console.WriteLine();
                    Console.WriteLine("-----------------");
                    Console.WriteLine("----New  Game----");
                    Console.WriteLine("-----------------");
                    display(box);
                }
            }
            
            Console.ReadKey();
        }
    }
}
