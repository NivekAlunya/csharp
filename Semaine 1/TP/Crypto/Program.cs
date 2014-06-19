using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    class Program
    {
        static int[,] cryptTable;

        static void Main(string[] args)
        {
            run();
            Console.ReadLine();
        }
        
        static void run()
        {
            string s;
            string k; ;
            cryptTable = createTable();
            //Console.WriteLine(s = crypt(Console.ReadLine().ToLower(), k = Console.ReadLine().ToLower()));
            Console.WriteLine(s = decrypt(crypt("informatique", k = "inraci"), k));
        }
        
        static string crypt(string s, string k)
        {
            char[] chars = s.ToCharArray();
            string crypt = "";
            for (int i = 0; i < s.Length; ++i)
            {
                crypt += getCryptoChar(s[i], k[i % k.Length], cryptTable);
            }

            return crypt;
        }

        static string decrypt(string s,string k)
        {
            char[] chars = s.ToCharArray();
            string decrypt = "";
            for (int i = 0; i < s.Length; ++i)
            {
                decrypt += getDecryptoChar(s[i], k[i % k.Length], cryptTable);
            }
            return decrypt;
        }

        static char getCryptoChar(char c,char k , int[,] array)
        {
        
            return (char)(97 + array[(int)c - 97, (int)k - 97]);
        }

        static char getDecryptoChar(char c, char k, int[,] array)
        {

            return (char)(97 + array[(int)k - 97, (((int)k - 97) + ((int)c - 97)) % 26]);
        }

        static int[,] createTable()
        { 
            int cote = 26;
            int[,] array = new int[cote,cote];
            int calc =0;
            for (int i = 0; i < cote; ++i)
            {
                for (int j = 0; j < cote; ++j)
                {
                    calc = (i+j) % cote;
                    array[i, j] = (calc)>0?calc:calc*-1;  
                }
            }
            return array;
        }
    }
}
