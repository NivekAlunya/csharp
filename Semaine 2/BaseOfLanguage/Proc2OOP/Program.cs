using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Proc2OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            run();
            Console.ReadKey();
        }
        static void run()
        { 
            //Object variable : refers to the adress of this object
            DateTime dt;
            //instanciation
            dt = new DateTime(); //default constructor
            dt = new DateTime(2100,2,28);
            try
            {
                dt = new DateTime(2014, 4, 31); //default constructor
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            Debug.WriteLine(dt.ToString());
            Debug.WriteLine(dt.ToString("dddd d MMMM yyyy"));
            Debug.WriteLine(dt.Year);
            Debug.WriteLine(dt = dt.AddYears(2));

            //deal with class members = common things between instances of the class
            Debug.WriteLine(DateTime.Now.ToShortDateString());
            Debug.WriteLine(DateTime.IsLeapYear(DateTime.Now.Year));
            
            //deal with enumerations
            switch(dt.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Debug.WriteLine("Day Off ");
                    break;
                default:
                    Debug.WriteLine("Working day ...");
                    break;
            }

            Debug.WriteLine(DateTime.Now.dayOfEaster().AddDays(1).ToString("dddd d MMMM yyyy"));


        }
    }
}
