using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            run();
        }
        static void run()
        {
            Console.WriteLine("Which number you want the factorial : ");
            
            uint number = catchNumber();
            Console.WriteLine("!" + number + " = " + factorial(number));
            Console.ReadKey();
        }

        static uint catchNumber()
        {
            bool ok = false;
            uint number = 0;
            do
            {
                try
                {
                    number = uint.Parse(Console.ReadLine());
                    if (0 <= number)
                        ok = true;
                    else
                        Console.WriteLine("Wrong value entered! please enter a positive number");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong value entered! please enter a positive number");
                }
            }
            while (false == ok);

            return number;
        }
        /// <summary>
        /// Return the factorial of the number
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static ulong factorial(uint n)
        {
            if (0 >= n)
            {
                return 1;
            }
            else
            {
                return n * factorial(n - 1);
            }
        }
    }
}
