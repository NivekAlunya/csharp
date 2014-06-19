using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Mine
{
    class Program
    {
        struct Coord
        {
            public int x;
            public int y;
        };

        enum PointValues
        {
            notplayed = 16,
            flagged = 32,
            demined = 64,
            mined = 128,
            maskval = 15,
            maskstate = 240
        }

        static Coord boundaries;
        static int[,] pane;
        static int nbMines = 5;
        static void Main(string[] args)
        {
            run();
            Console.ReadKey();
        }
        
        static void run()
        {
            boundaries.y = boundaries.x = 5;
            computePane(boundaries, pane = new int[boundaries.x, boundaries.y], nbMines);
            play();
        }

        static void play()
        {
            bool booloop = true;
            Coord cursor;
            cursor.x = 0;
            cursor.y = 0;
            do
            {
                displayPane(pane, boundaries, cursor);
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        cursor.x = (cursor.x - 1) < 0 ? boundaries.x-1 : cursor.x - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        cursor.x = (cursor.x + 1) % boundaries.x;
                        break;
                    case ConsoleKey.UpArrow:
                        cursor.y = (cursor.y - 1) < 0 ? boundaries.y-1 : cursor.y - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        cursor.y = (cursor.y + 1) % boundaries.y;
                        break;
                    case ConsoleKey.Escape:
                        booloop = false;
                        break;
                    default:
                        break;
                }
            } while (booloop);
            

        }

        static void displayPane(int[,]pane, Coord boundaries,Coord cursor)
        {
            Console.Clear();
            for(int i=0;i < boundaries.x;++i)
            {
                for(int j=0;j<boundaries.y;++j)
                {
                    if(cursor.x == j && cursor.y ==i) {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if ((pane[i, j] & (int)PointValues.mined) == (int)PointValues.mined)
                    {
                        Console.Write('X');
                    }
                    else{
                        Console.Write(pane[i, j] & (int)PointValues.maskval);
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write("\n");
            }
        }

        static void computePane(Coord boundaries, int[,] pane, int nbMines = 5)
        {
            placeMine(boundaries, pane, nbMines);
        }

        static void placeMine(Coord boundaries, int[,] pane, int nbMines = 5)
        {
            Coord coordMine;
            int val;
            int endx, endy;
            for (int i = 0; i < nbMines; ++i)
            { 
                do
                {
                    coordMine = randomizeMine(boundaries);

                } while (PointValues.mined == (PointValues)((int)pane[coordMine.x, coordMine.y] & (int)PointValues.mined));

                pane[coordMine.x, coordMine.y] = (int)pane[coordMine.x, coordMine.y] | (int)PointValues.mined;
                endx = (coordMine.x + 1 < boundaries.x ? coordMine.x + 1 : coordMine.x);
                endy = (coordMine.y + 1 < boundaries.y ? coordMine.y + 1 : coordMine.y);
                for (int j = coordMine.x > 0 ? coordMine.x - 1 : 0 ; j <= endx; ++j)
                {
                    for (int k = coordMine.y > 0 ? coordMine.y - 1 : 0; k <= endy; ++k)
                    {
                        val = (int)pane[j, k] & (int)PointValues.maskval;
                        val++;
                        Debug.WriteLine(pane[j, k] = ((int)pane[j, k] & (int)PointValues.maskstate | val));
                    }
                }
            }
        }

        static Coord randomizeMine(Coord boundaries)
        {
            Random rand = new Random();
            Coord coordMine;
            coordMine.x = rand.Next(boundaries.x);
            coordMine.y = rand.Next(boundaries.y);
            return coordMine;
        }

        

    }
}
