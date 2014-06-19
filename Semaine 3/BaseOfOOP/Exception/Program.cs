using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AppException
{
    class Program
    {
        static void Main(string[] args)
        {
            run();
            Console.ReadKey();
        }

        static void run()
        {
            tryexception(10);
            tryexception(0);
            try
            {
                throwexception(10);
                throwexception(0);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }

        }

        static void tryexception(int div)
        {
            try
            {
                Debug.WriteLine("Before exception");
                Console.WriteLine(1 / div);
                Debug.WriteLine("After exception");
            }
            catch
            {
                Debug.WriteLine("Catch error (exception)");
            }
            finally
            {
                Debug.WriteLine("Finally execute");
            }
            Console.WriteLine("End function");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="div"></param>
        /// <exception cref="Exception"></exception>
        static void throwexception(int div)
        {
            try
            {
                Debug.WriteLine("Before exception");
                Console.WriteLine(1 / div);
                Debug.WriteLine("After exception");
            }
            catch(DivideByZeroException e)
            {
                Debug.WriteLine("Catch error (exception)");
                Debug.WriteLine("Throwing exception");
                throw new WTFException();
                Debug.WriteLine("End catch");
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                Debug.WriteLine("Finally execute");
            }
            Console.WriteLine("End function");
        }

        static void exception(int div)
        {
            Debug.WriteLine("Before exception");
            Console.WriteLine(1 / div);
            Debug.WriteLine("After exception");
        }

    }
}
