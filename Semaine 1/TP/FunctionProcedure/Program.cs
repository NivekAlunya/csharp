using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionProcedure
{
    class Program
    {
        //static string name;
        static void Main(string[] args)
        {
            // ask name
            string name = askName();
            //display name
            displayName(name);
            displayName(name);
            Console.ReadKey();
        }

        //static void askName()
        static string askName()
        {
            Console.Write("What is your name : ");
            return Console.ReadLine();
        }
        static void displayName(string name)
        {
            Console.WriteLine("Hello " + name);
            name = "1212312332";
        }
    }
}
