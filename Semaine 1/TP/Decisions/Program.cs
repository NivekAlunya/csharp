using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decisions
{
    class Program
    {
        static void Main(string[] args)
        {
            double price;
            Console.Write("Your basket in Euros: ");
            price = double.Parse(Console.ReadLine().Replace(".",","));
            
            double tmp = price;

            if (price >= 150)
            {
                Console.WriteLine("You've got 30%"); 
                price *= .7;
            }
            else if (price >= 100)
            {
                Console.WriteLine("You've got 20%");
                price *= .8;
            }
            else
            {
                Console.WriteLine("You've got 10%");
                price *= .9;
            }
            Console.WriteLine(price);
            Console.Write("Do you want to pay ?");
            char key = Console.ReadKey().KeyChar;

            if (key == 'y' || key == 'Y')
            {
                Console.WriteLine("\nPay an have a good day...");
            }
            else if (key == 'n' || key == 'N')
            {
                Console.WriteLine("\nBye");
            }
            else 
            {
                Console.WriteLine("\n#WTF");
            }

            switch (key) {
                case 'y':
                case 'Y':
                    Console.WriteLine("Pay an have a good day...");
                    break;
                case 'n':
                case 'N':
                    Console.WriteLine("Bye");
                    break;
                default:
                    Console.WriteLine("#WTF");
                    break;
            }
            Console.ReadKey();
        }
    }
}
