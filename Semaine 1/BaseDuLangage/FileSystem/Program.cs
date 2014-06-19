using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSystem
{
    class Program
    {
        private struct personne
        {
            int id;
            public String name;
            public DateTime dob;
        }

        const string PATH= "d:/data/file.txt";

        static void Main(string[] args)
        {
            char answer, action;

            do
            {
                Console.Clear();
                Console.WriteLine("File access");
                Console.WriteLine("1 - write , 2 - read");
                action = char.Parse(Console.ReadLine());
                switch (action)
                {
                    case '1':
                        write();
                        break;
                    case '2':
                        read();
                        break;
                }
                Console.WriteLine("Continue(Y/N) : ");
                answer = char.Parse(System.Console.ReadLine());
            } while (answer == 'Y' | answer == 'y');
        }



        private static void write()
        {
            char answer;
            StreamWriter sw;
            try
            {
                sw = File.AppendText(PATH); // open or create the file and go to the end of file
            }
            catch (Exception e)
            {
                throw e;
            }

            do
            {
                try
                {
                    Console.Write("id:");
                    sw.WriteLine(Console.ReadLine());
                    Console.Write("name:");
                    sw.WriteLine(Console.ReadLine());
                    Console.Write("dob dd/mm/yyyy:");
                    sw.WriteLine(Console.ReadLine());
                }
                catch (Exception e)
                {
                    break;
                }
                Console.WriteLine("Do you wish one more record  Y/N: ");
                answer = char.Parse(Console.ReadLine());
                Console.Clear();
            }
            while (answer == 'y' || answer == 'Y');

            try
            {
                sw.Close();
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        static void raise()
        {
            throw new Exception("Generic");
        }
        static void read()
        {
            char answer, action;

            do
            {
                Console.Clear();
                Console.WriteLine("1 - Read single , 2 - read all records");
                action = char.Parse(Console.ReadLine());
                switch (action)
                {
                    case '1':
                        readSingleRecord();
                        break;
                    case '2':
                        readAllRecords();
                        break;
                }

                Console.WriteLine("do you wish to continue (Y/N) : ");
                answer = char.Parse(Console.ReadLine());
            }
            while (answer == 'Y' || answer == 'y');
        }

        static void readSingleRecord()
        {

        }

        static void readAllRecords()
        {
            StreamReader sr;
            try
            {
                sr = File.OpenText(PATH);
            }
            catch (Exception e)
            {
                
                throw e;
            }


            while(!sr.EndOfStream)
            {
                try
                {
                    Console.WriteLine(sr.ReadLine());
                }
                catch (Exception)
                {
                    
                    break;
                }
            }            



        }

    }
}
