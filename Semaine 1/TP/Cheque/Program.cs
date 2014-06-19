using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheque
{
    class Program
    {
        static void Main(string[] args)
        {
            run();
        }
        static void run()
        {
            string cheque = "", lowerCheque= "", upperCheque="";
            int nbCheque = 0, nbLowerCheque = 0, nbUpperCheque = 0;
            double total = 0.0, amount = 0.0, lowerTotal = 0.0, upperTtotal= 0.0, lowerAmount = 0.0, upperAmount = 0.0;
            while ((cheque = catchCheque()) != "0")
            {
                nbCheque++;
                amount = catchChequeAmount();
                total += amount;
                if (200 > amount)
                {
                    nbLowerCheque++;
                    lowerTotal += amount;
                }
                else
                {
                    nbUpperCheque++;
                    upperTtotal += amount;
                }

                if (1 == nbCheque)
                {
                    lowerCheque = upperCheque  = cheque;
                    lowerAmount = upperAmount = amount;
                    continue;
                }

                if (lowerAmount > amount)
                {
                    lowerAmount = amount;
                    lowerCheque = cheque;
                }
                else if (upperAmount < amount)
                {
                    upperAmount = amount;
                    upperCheque = cheque;
                }

            }
            if (0 < nbCheque)
            {
                //RESULTS
                Console.WriteLine("> REPORTING *****************************");
                Console.WriteLine("Number of cheque is " + nbCheque + " for a total of " + total + " Euros.");
                Console.WriteLine("Nunber of cheque lower than 200 Euros is " + nbLowerCheque + " for a total of " + lowerTotal + " Euros");
                Console.WriteLine("Nunber of cheque equal or greater than 200 Euros is " + nbUpperCheque + " for a total of " + upperTtotal + " Euros");
                Console.WriteLine("The cheque number n° " + lowerCheque + " for an amount of " + lowerAmount + " is the lower cheque.");
                Console.WriteLine("The cheque number n° " + upperCheque + " for an amount of " + upperAmount + " is the upper cheque.");
            }
            Console.WriteLine("\nBye");
            Console.ReadKey();
        }

        static string catchCheque()
        {
            bool booloop= true;
            string cheque = "";
            Console.Write("Cheque number:");
            do
            {
                if ((cheque = Console.ReadLine()) != "")
                    booloop = false;
                else
                    Console.Write("Please enter something for the cheque number!!! :");
            } while (booloop);
            
            return cheque;
        }

        static double catchChequeAmount()
        {
            bool booloop = true;
            double amount=0.0;
            Console.Write("Cheque amount:");
            do
            {
                try
                {
                    if (0 < (amount = double.Parse(Console.ReadLine().Replace(".",","))))
                        booloop = false;
                    else
                        Console.Write("Please enter a positive price like 150,25 for the cheque amount!!! :");

                }
                catch (Exception e)
                {
                    Console.Write("Please enter a price like 150,25 for the cheque amount!!! :");
                }
            } while (booloop);
            return amount;
        }

    }
}
