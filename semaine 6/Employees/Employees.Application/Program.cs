using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Employees.Controler;
using Employees.Model;
using Employees.ConsoleViews;
using MyCompany.Tools;
namespace Employees.Application
{
    static class Program
    {
        private delegate void displayDelegate(string output);

        static void Main(string[] args)
        {
            run();
        }

        static void run()
        {   
            //runServiceView();
            //return;
            ConsoleKeyInfo cki;
            MainConsoleView main = new MainConsoleView();
            do { } while (ConsoleKey.Escape != (cki = main.display()).Key);

        }
        
        static void localfunction(string s)
        {
            Debug.WriteLine(s);
        }
        static void runDelegate()
        {
            display(Console.WriteLine);
            display(localfunction);
        }

        static void display(displayDelegate fn)
        {
            fn("bonjour");
        }

        static void runServiceView()
        {
            Logger logger = new Logger("logger 1");
            Logger logger2 = new Logger("logger 2");
            foreach (Service s in ServiceControler.Instance.Services)
            {
                s.addLogger(logger);
                Console.WriteLine(s);
            }
            try
            {
                ServiceControler.Instance.updateService(ServiceControler.Instance.Services.ElementAt(0), "XXXXX", "");
            }
            catch (Exception e)
            {
            }
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine(ServiceControler.Instance.retrieveService("BUYER",ServiceSearchOption.SearchOnCode));

            ServiceControler.addServiceDelegate d = (Service s) => {
                    Console.WriteLine(s);
                };
            Service s2 = ServiceControler.Instance.addService("XXXXX", "THE X SERVICE",
                d
            );
            s2.addLogger(logger2);
            s2.addLogger(logger);

            ServiceControler.Instance.evtUpdateService += (object service, EventArgs e) =>
            {
                Console.WriteLine(service + " created...");
            };
            ServiceControler.Instance.updateService(s2,"XXXX1","The X SERVICE");

        }
    }
}
