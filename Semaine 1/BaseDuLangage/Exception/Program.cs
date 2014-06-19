using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exceptions
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
            //not for syntax error
            //not for predictable errors
            //--------------
            //for system errors : file access, network, hardware
            //for rules in model object
            try
            {
                readFile("d:/data/file.txt");
                readFile("c:/file not found/error.txt");
            }
            catch
            {
                
                
            }
        }

        static void readFile(string pathtoFile)
        {
            StreamReader sr;
            try
            {
                sr = File.OpenText(pathtoFile);
                Console.WriteLine("Reading " + pathtoFile);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error on " + pathtoFile);
                throw new Exception("File not found");
            }
            finally
            {
                Console.WriteLine("End process reading");
            }



        }
    }
}
