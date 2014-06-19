using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumeration
{
    class Program
    {
        enum etitle
        {
            mister,       // = 0
            madam,         // = 1 
            miss,   // = 2 
            doctor,        // = 3
            master,         // = 4
            professor      // = 5 
        }

        static void Main(string[] args)
        {
            run();
        }
        static void run()
        {
            etitle mytitle = etitle.doctor;

            Console.WriteLine("My title is " + mytitle); // display string enum identifier

            Console.WriteLine("My new title is " + (mytitle = catchTitle())); // display string enum identifier
            searchDeal(mytitle);
            Console.ReadKey();
        }

        static etitle catchTitle()
        {
            etitle title;
            Console.WriteLine("Enter your Title (0 = mister , 1 = madam, 2 = miss, 3 = doctor, 4 = master, 5 = professor): ");
            title = (etitle)int.Parse(Console.ReadLine());

            return title; 
        }

        static void searchDeal(etitle title)
        {
            switch (title)
            {
                case etitle.mister:
                    Console.WriteLine("deals on tools");
                    break;
                case etitle.professor:
                case etitle.master:
                case etitle.doctor:
                    Console.WriteLine("deals on book");
                    break;
                case etitle.miss:
                case etitle.madam:
                    Console.WriteLine("deals on shoes");
                    break;
            }
        }
    }
}
