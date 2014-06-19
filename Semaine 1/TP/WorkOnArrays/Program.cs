using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOnArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            run();
        }
        static void run()
        {
            int[] array = createArray(5);
            catchArray(array);
            Console.WriteLine("display array");
            displayArray(array);
            Console.WriteLine("display sorted array");
            sortArrayDesc(array);
            displayArray(array);
            Console.ReadKey();
        }
        static int[] createArray(int n = 0)
        {
            return 0 < n ? new int[n] : null;
        }

        static void catchArray(int[] array)
        {
            if (null == array)
            {
                return;
            }

            for (int i = 0; i < array.Length; ++i)
            {
                if (!int.TryParse(Console.ReadLine(), out array[i])) Console.WriteLine("{0} inserted ", array[i]);
            }
        }

        static void displayArray(int[] array)
        {
            if (null == array)
            {
                Console.WriteLine("No array provided");
                
                return;
            }
            if (1 > array.Length) 
            {
                Console.WriteLine("Empty array");

                return;
            }

            for (int i = 0; i < array.Length; ++i)
            {
                Console.WriteLine(array[i]);
            }
        }

        static void sortArrayDesc(int[] array)
        {
            int tmp;
            Array.Sort(array);
            for (int i = 0; i < array.Length / 2; ++i)
            {
                tmp = array[i];
                array[i]=array[(array.Length - 1) - i];
                array[(array.Length - 1) - i] = tmp;
            }
        }

    }
}
