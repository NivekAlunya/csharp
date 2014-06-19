using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
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
            Console.ReadKey();
        }
        /// <summary>
        /// 
        /// </summary>
        static void run()
        {
            Console.CursorVisible = false;
            int x = Console.WindowWidth / 2, y = 0;
            bool booloop = true;
            do
            {
//                displayBall(x, y);
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.Write("o");
                switch (Console.ReadKey(true).Key)
                { 
                    case ConsoleKey.LeftArrow:
                        x = x > 0 ? --x : 0;
                        break;
                    
                    case ConsoleKey.RightArrow:
                        x = x < Console.WindowWidth ? ++x : 0;
                        break;
                    
                    case ConsoleKey.Escape:
                        booloop = false;
                        break;

                    default:
                        break;
                }
            }while(++y<Console.WindowHeight & booloop);
        }

        //static void displayBall(int x, int y)
        //{
        //}

        static void wait(int mx =10000)
        {
            for (int i = 0; i < mx; ++i) ;
        }
    }
}
