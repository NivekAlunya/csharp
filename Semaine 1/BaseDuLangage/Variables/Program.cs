using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables
{
    class Program
    {
        static string name;
        const double TVA = 1.20;
        static void Main(string[] args)
        {
            int i, cpt=10; //2 vars of type integer , one initialized;
            string thestring = "Hi we are on ";

            i = cpt + 2;
            thestring = thestring + DateTime.Now;
            //name = i;
            name = i.ToString();
            //i = name;
            //we can convert a string to any value but we have to "cast" this value
            i = int.Parse(name);
            name = "robert";
            //i = int.Parse(name);
            double sellPrice;
            sellPrice = i; 
            sellPrice = i * TVA;
            //this is a cast > we loose the decimal part ;
            i = (int)sellPrice;
            name = "12" + 6;
            //view
            Console.WriteLine(i);
            Console.WriteLine(thestring);
            Console.WriteLine(name);
            //input name
            Console.WriteLine("What's your name?");
            name = Console.ReadLine();
            Console.WriteLine("Hello " + name);
            Console.WriteLine("What is your age?");
            //string tmp;
            //tmp = Console.ReadLine();
            //i = int.Parse(tmp);
            i = int.Parse(Console.ReadLine());

            Console.ReadKey();
        }
    }
}
