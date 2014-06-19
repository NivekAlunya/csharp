using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Model;
namespace Employees.ConsoleViews
{
    public abstract class ConsoleView
    {

        /// <summary>
        /// return true if the key is acceptable else false
        /// </summary>
        /// <param name="cki"></param>
        /// <returns></returns>
        protected delegate bool replyDelegate(ref ConsoleKeyInfo cki);
        protected delegate T inputDelegate<T>(string s);
        #region attributes
        protected string _message;
        #endregion

        #region properties

        #endregion

        #region constructors

        #endregion

        #region methods
        protected void displayMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(this._message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        protected ConsoleKeyInfo ask(replyDelegate ask,string prompt = "")
        {

            bool doloop = false;
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine(prompt);
                cki = Console.ReadKey(true);
                doloop = !ask(ref cki);
                Console.SetCursorPosition(0, --Console.CursorTop);

            } while (doloop);
            return cki;
        }

        protected T input<T>(inputDelegate<T> p,string prompt = "")
        {
            do
            {
                Console.WriteLine(prompt);
                try
                {
                    return p(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(0, --Console.CursorTop);
                }
                Console.SetCursorPosition(0, --Console.CursorTop);
                Console.Write("\n Error on ....");
            } while (true);
        }

        public abstract ConsoleKeyInfo display();
        #endregion

        #region delegates

        #endregion

    }
}
