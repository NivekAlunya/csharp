using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM
{
    class Program
    {
        static void Main(string[] args)
        {
            processICM();    
            Console.ReadKey();
        }
        static void processICM() {
            Console.Write("weight in kg:");
            double weight = double.Parse(Console.ReadLine().Replace(".", ","));
            Console.Write("height in m:");
            double height = double.Parse(Console.ReadLine().Replace(".", ","));
            double icm = weight / Math.Pow(height, 2.0);

            if (icm < 20)
            {
                Console.WriteLine("you have a deficiency");
            }
            else if (icm < 25)
            {
                Console.WriteLine("you are normal");
            }
            else if (icm < 30)
            {
                Console.WriteLine("you are overweight");
            }
            else
            {
                Console.WriteLine("Fat boy");
            }
        }
    }
}
