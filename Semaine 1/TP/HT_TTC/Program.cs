using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_TTC
{
    class Program
    {
        const float TVA = .2f;
        static void Main(string[] args)
        {
            // read unit price
            // read amount
            // displaying the price
            decimal unitPrice = 0;
            bool ok = false;
            do
            {
                try
                {
                    Console.Write("Unit Price : ");
                    unitPrice = decimal.Parse(Console.ReadLine());
                    ok = true;
                }
                catch (Exception e)
                {
                    Console.Write("Wrong! Please use this format 10,5.\n");
                }
            } while (ok == false);
            
            Console.Write("amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            decimal taxPrice = unitPrice * (decimal)(1 + TVA);
            Console.Write("Total : " + (taxPrice * amount) + " Euros");
            Console.ReadKey();

        }
    }
}
