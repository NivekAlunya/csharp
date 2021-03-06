﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Store;
using System.Data;
using System.Data.Common;


namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            run();
            Console.ReadKey();
        }

        private static void run()
        {
            providers();
            signin();
        }

        static void signin()
        {
            Console.WriteLine("Login ? :");
            string login = Console.ReadLine();
            Console.WriteLine("Password ? :");
            string password = Console.ReadLine();
            try
            {
                if (DbAgnostic.signin(login, password))
                {
                    Console.WriteLine("you re logged in...");
                }
                else
                {
                    Console.WriteLine("Forbidden Access ...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        public static void providers()
        {
            DataTable result;
            result = DbProviderFactories.GetFactoryClasses();
            foreach(DataRow row in result.Rows)
            {
                foreach (DataColumn col in result.Columns)
                {
                    Console.Write(col.ColumnName + ":\t" + row[col.ColumnName] + "\n\r");
                }
                Console.WriteLine("#####################################################");
            }
        }




    }
}
