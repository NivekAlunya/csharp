using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOnString
{
    class Program
    {
        static void Main(string[] args)
        {
            string mystring;
            mystring = "Bonjour "; //mem space reserved
            mystring = mystring + "\tKevin      "; //mem space reserved
            Console.WriteLine(mystring);
            //extract string
            Console.WriteLine(mystring.Substring(0, 7));
            //insert a string
            Console.WriteLine(mystring.Insert(7, ","));
            //change case
            Console.WriteLine(mystring.ToLower());
            Console.WriteLine(mystring.ToUpper());
            //search string
            Console.WriteLine(mystring.IndexOf("k")>-1? "yes":"no");
            Console.WriteLine(mystring.IndexOf("K") > -1 ? "yes" : "no");
            //replace string
            Console.WriteLine(mystring.Replace("e","E"));
            //read length property
            Console.WriteLine(mystring.Length);
            //
            Console.ReadKey();
        }
    }
}
