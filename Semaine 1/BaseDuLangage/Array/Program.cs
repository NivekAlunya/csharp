using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            array();
        }

        static void array()
        {
            //usage
            string[] daysOfWeek = new string[7];
            daysOfWeek[0] = "Monday";
            daysOfWeek[1] = "Tuesday";
            daysOfWeek[2] = "Wednesday";
            daysOfWeek[3] = "Thursday";
            daysOfWeek[4] = "Friday";
            daysOfWeek[5] = "Saturday";
            daysOfWeek[6] = "Sunday";
            string[] daysOfWeek2 = {"Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday" };
            Console.WriteLine(daysOfWeek);
            arrayWalk(daysOfWeek);
            arrayWalk(daysOfWeek2);
            updateArray(daysOfWeek);
            arrayWalk(daysOfWeek);
            Console.ReadKey();
        }

        static void arrayWalk(string[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Console.WriteLine(array[i]);
            }
        }

        static string[] createArray(int size = 0)
        {

            return size > 0 ? new string[size] : new string[(new Random()).Next()];
        
        }

        static void updateArray(string[] array)
        {
            array[0] = "MONDAY";
        }
    }
}
