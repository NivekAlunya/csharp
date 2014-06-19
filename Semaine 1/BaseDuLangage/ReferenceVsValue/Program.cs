using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace ReferenceVsValue
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Main");
            int var = 10;
            Debug.WriteLine("Call procValue");
            procValue(var);
            Debug.WriteLine("Called procValue");
            Debug.WriteLine("val = " + var);

            Debug.WriteLine("Call procReference");
            procReference(ref var);
            Debug.WriteLine("Called procReference");
            Debug.WriteLine("val = " + var);
            int result;
            Console.Write("\nEnter an integer value with int.Parse:");
            try
            {
                result = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            { }

            Console.Write("\nEnter an integer value with int.TryParse:");
            while (!int.TryParse(Console.ReadLine(), out result)) ;


            Debug.WriteLine("End Main");
            Console.ReadKey();
        }

        static void procValue(int val)
        {
            Debug.WriteLine("Star procValue() function");
            Debug.WriteLine("val = " + val);
            Debug.WriteLine("val = " + (val += 5));
            Debug.WriteLine("Stop procValue()");

        }

        static void procReference(ref int val)
        {
            Debug.WriteLine("Star procReference() function");
            Debug.WriteLine("val = " + val);
            Debug.WriteLine("val = " + (val += 5));
            Debug.WriteLine("Stop procReference()");

        }
    }
}
