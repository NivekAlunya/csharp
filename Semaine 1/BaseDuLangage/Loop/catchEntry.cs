using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop
{
    class CatchEntry
    {
        static void Main()
        {
            char c = '\0';
            ConsoleKeyInfo cki;
            do {
                Console.Write("\nDo you wish to continue?[Y/N]");
                cki = Console.ReadKey();
                c = cki.KeyChar;
            } while ('Y' != c && 'y' != c && 'N' != c && 'n' != c);
        }
    }
}
