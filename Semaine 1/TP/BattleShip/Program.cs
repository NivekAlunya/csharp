using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Program
    {
        struct Coord {
            public int x;
            public int y;
        }
        static void Main(string[] args)
        {
            run();
        }
        static void run()
        {

            int[,] game;
            do
            {
                game = computeGame();
                int stateStroke = 0;
                Coord c;
                do
                {
                    Console.WriteLine("Your stroke : ?");
                    switch (stateStroke = play(game, c = catchStroke(game)))
                    { 
                        case 0:
                            Console.WriteLine("Missed in location {0}:{1}", c.x+1, c.y+1);
                            break;
                        case 1:
                            Console.WriteLine("You find the ship in location {0}:{1}", c.x+1, c.y+1);
                            break;
                        default:
                            Console.WriteLine("Already played!!!!");
                            break;

                    }
                }
                while (1 > stateStroke);
                Console.WriteLine("Play again ? (y/n)");
            } while ('y' == Console.ReadKey().KeyChar);
        }

        static Coord catchStroke(int[,] game)
        { 
            Coord c;
            Console.Write("x (max = {0}):", game.GetLength(0));
            c.x = catchValue(1, game.GetLength(0));
            Console.Write("y (max = {0}):", game.GetLength(1));
            c.y = catchValue(1, game.GetLength(1));
            return c;
        }

        static int catchValue(int min, int max)
        {
            bool booloop = true;
            int n;
            do
            {
                if (int.TryParse(Console.ReadLine(), out n) && min <= n && max >= n)
                    booloop = false;
                else 
                {
                    Console.WriteLine("Please enter an integer between {0} and {1} !!!", min, max);
                }
            }
            while (booloop);
            return n-1;
        }

        static int[,] computeGame()
        {
            int[,] game = new int[3,3];
            Random rand = new Random();
            game[rand.Next(3), rand.Next(3)] = 1;
            
            return game;
        }

        static int play(int[,] game, Coord c)
        {
            if (1 == game[c.x, c.y])
            {
                return 1;
            }
            else if (0 == game[c.x, c.y])
            {
                game[c.x, c.y] = -1;
                return 0;
            }
            else return -1;
        }
    }
}
