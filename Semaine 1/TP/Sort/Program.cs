using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array= new int[10];
            Random rand = new Random();
            for (int i = 0; i < array.Length - 1; i++) 
                array[i] = rand.Next(64);
            sortArray(array);

            int[] array2 = {5,6,2,4,3,1,2};
            sortArrayBalancer(array2,0,array2.Length-1);
            Console.ReadKey();

            
        }

        static void sortArray(int[] array)
        {
            int tmp;
            int cnt=0;
            for (int i = 0; i < array.Length - 1; ++i)
            {
                for (int j = i+1; j < array.Length; ++j)
                {
                    if (array[i] > array[j])
                    {
                        tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                    ++cnt;
                }
            }
            Debug.WriteLine(cnt);
        }

        static void sortArrayBalancer(int[] array,int start, int end)
        {
            int cntLowerThan=0;
            int cur = array[start];
            int tmp;
            for (int i = start + 1; i <= end; ++i)
            { 
                if (array[i] <array[start] )
                {
                    cntLowerThan++;
                }
            }
            if (0 < cntLowerThan) 
            {
                tmp = array[start + cntLowerThan];
                array[start + cntLowerThan] = array[start];
                array[start]=tmp;
            }
        }

        static void arraySwitch(int[] array, int pivot)
        {
            for (int i = 0; i <= end; ++i)
            {
                if (array[i] < array[start])
                {
                    cntLowerThan++;
                }
            }
            
            
        }

    }
}
