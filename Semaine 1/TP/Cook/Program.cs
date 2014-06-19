using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cook
{
    class Program
    {
        enum CookMode
        {
            soft    = 1,
            normal  = 2,
            hard    = 3
        }
        static void Main(string[] args)
        {
            char meatType = '\0';
            CookMode cookMode;
            int weight    = 0;
            
            meatType = catchMeat();
            cookMode = catchCookMode();
            weight = catchWeight();

            Console.WriteLine("\nCooking time is " + (int)(processCook(meatType, cookMode, weight) / 60) + " min");
            Console.ReadKey();
        }

        static char catchMeat()
        {
            char c;
            bool ok = false;
            Console.Write("\nWhich meat you want 'B' for beef 'P' for porc ?");
            do 
            {
                c = Console.ReadKey().KeyChar;
                if('P' == c || 'B' == c || 'p' == c || 'b' == c ) ok =true;
            }
            while(false == ok);

            return c;
        }

        static CookMode catchCookMode()
        {
            int c;
            bool ok = false;
            Console.Write("\nWhich cook mode you want '1' for soft '2' for normal '3' for hard ?");
            do 
            {
                c = (int)Console.ReadKey().KeyChar - 48;
                if ((int)CookMode.soft <= c && (int)CookMode.hard >= c) ok = true;
                Console.WriteLine("\b");
            }
            while(false == ok);

            return (CookMode)int.Parse(c.ToString());
        }

        static int catchWeight()
        {
            int weight=0;
            bool ok = false;
            Console.Write("\nWeight of the meat :");
            do 
            {
                try
                {
                    weight = int.Parse(Console.ReadLine());
                    if (0 < weight)
                        ok = true;
                    else
                        Console.Write("\nWrong value ! Please enter a positive integer value like 500 for the weight. Retry : ");
                }
                catch (Exception e) 
                {
                    Console.Write("\nWrong value ! Please enter an integer value like 500 for the weight. Retry : ");
                }
            }
            while (false == ok);
            
            return weight;
        }

        static int processCook(char meatType, CookMode cookMode, int weight)
        {
            int refTime =0 ,refWeight=0;
            switch (meatType)
            {
                case 'B':
                case 'b':
                    refWeight = 500;
                    refTime = processBeef(cookMode);
                    break;
                default:
                    refWeight = 400;
                    refTime = processPorc(cookMode);
                    break;
            }
            return (int)(weight * refTime * 60 / refWeight);
        }
        static int processBeef(CookMode cookMode)
        {
            switch (cookMode)
            {
                case CookMode.soft:
                    return 10;
                case CookMode.normal:
                    return 17;
                case CookMode.hard:
                    return 25; 
            }
            return 0;
        }

        static int processPorc(CookMode cookMode)
        {
            switch (cookMode)
            {
                case CookMode.soft:
                    return 15;
                case CookMode.normal:
                    return 25;
                case CookMode.hard:
                    return 40;
            }
            return 0;
        }

    }
}
