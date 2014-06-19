using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            const int MAX = 10;
            while(++i <= MAX)
            {
                Console.Write("\r" + i);
            }
            
            i = 1;            
            do 
            {
                Console.Write("\r" + i);
            } while (++i <= MAX);

            for (int j = 1,k=0; j <= MAX && k<=MAX; ++j,++k)
            {
                Console.Write("\r" + j + '/' +k);
            }

            Console.ReadKey();

        }
    }
}
