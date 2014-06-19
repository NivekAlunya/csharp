using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.ConsoleViews
{
    public class MainConsoleView : ConsoleView
    {
        public override ConsoleKeyInfo display()
        {
            Console.Clear();
            Console.WriteLine("--MAIN MENU--");
            Console.WriteLine(" 1. Menu Services");
            Console.WriteLine(" 2. Menu Employees");
            Console.WriteLine("-------------");
            Console.WriteLine("(ESC) to quit...");
            Console.CursorVisible = false;

            return this.ask(
                (ref ConsoleKeyInfo cki) => {
                switch (cki.KeyChar)
                {
                    case '1':
                        cki = (new ServiceConsoleView()).display();
                        return true;
                    case '2':
                        return false;
                        throw new NotImplementedException();
                    case (char)ConsoleKey.Escape:
                        return true;
                }
                return false;
                ;
            });
        }
    }
}
