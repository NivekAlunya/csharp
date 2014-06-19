using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiply
{
    class Program
    {
        static void Main(string[] args)
        {
            askMultiply();    
        }

        static void askMultiply()
        {
            Console.WriteLine("To table : ");
            int table = catchNumber();
            Console.WriteLine("To number : ");
            int toNumber = catchNumber();
            Console.WriteLine("-------------------------------------------------------");
            processMultiplyAndDisplay(table, toNumber);
            Console.ReadKey();
        }

        static int catchNumber()
        {
            bool ok = false;
            int number = 0;
            do {
                try
                {
                    number= int.Parse(Console.ReadLine());
                    ok = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Wrong value entered! please enter a number");
                }
            }
            while (false == ok);
            
            return number;
        }

        static void processMultiplyAndDisplay(int table,int toNumber)
        {
            for (int i = 1; i <= table; ++i)
            {
                Console.WriteLine("***** Table " + i + " ******");
                for (int j = 1; j <= toNumber; ++j)
                {
                    Console.WriteLine(i + "\tx\t" + j + "\t= " + (i * j));
                }
            }
        }
    }
}
