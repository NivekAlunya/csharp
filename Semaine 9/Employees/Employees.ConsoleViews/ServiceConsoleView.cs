using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Controler;
using Employees.Model;
using MyCompany.Tools;
namespace Employees.ConsoleViews
{
	public class ServiceConsoleView : ConsoleView
	{

		public override ConsoleKeyInfo display()
		{
			ConsoleKeyInfo ckidisplay;
            ServiceController.Instance.subscribe(() =>
            {
                Console.WriteLine("List sorted...");
                for (int i = 0; i < 1000000000; ++i) { }
            }
            );
			do
			{
				menu();
				ckidisplay = this.ask(
				   (ref ConsoleKeyInfo cki) =>
				   {
					   int r;
					   switch (cki.KeyChar.toUpper())
					   {
                            case 'A':
                                try
                                {
						            ServiceController.Instance.addService(
									    this.input<string>((string s) => s,"Code :"),
                                        this.input<string>((string s) => s, "Label :")
							        );
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message + " [Press as key]");
                                    Console.ReadKey();
                                }
                                return true;
						   case 'U':
							    ServiceController.Instance.evtUpdateService += (object service, EventArgs e) =>
							    {
								    Console.WriteLine(service + " updated...");
							    };
                                r = this.input<int>(
								    (string s) =>
								    {
									    int result;
										if (int.TryParse(s, out result)) return result;
										throw new Exception();
							        },
                                    "Wich number to update: "
							   );
                                try
                                {
                                    Service targetService = ServiceController.Instance.Services.ElementAt(r - 1);
                                    ServiceController.Instance.updateService(targetService,
                                    this.input<string>(
                                        (string s) => { 
                                            return 1 >s.Trim().Length ? targetService.Code : s ; 
                                        },"Code :"),
                                        this.input<string>((string s) =>
                                        {
                                            return 1 > s.Trim().Length ? targetService.Label : s; 
                                        },"Label :")
                                    );
                                }
							    catch (Exception e)
							    {
                                    Console.WriteLine(e.Message);
                                }
                                return true;
                            case 'D':
                                r = this.input<int>(
								(string s) =>
							    {
									int result;
									if (int.TryParse(s, out result)) return result;
								    throw new Exception();
								},
                                "Wich number to update: "
							   );
							   try
							   {
								   ServiceController.Instance.deleteService<Service>(ServiceController.Instance.Services.ElementAt(r - 1));
                               }
							   catch (Exception e)
							   {
								   throw e;
							   }
                               return true;
                           case (char)ConsoleKey.Enter:
							   return true;
						   case (char)ConsoleKey.Escape:
							   return true;
					   }
					   return false;
					   ;
				   }
			   );
			} while (ConsoleKey.Enter != ckidisplay.Key && ConsoleKey.Escape != ckidisplay.Key);
			return ckidisplay;
		}

		private void menu()
		{
			Console.Clear();
			Console.WriteLine("--SERVICES --");
			int i = 0, padleft = ServiceController.Instance.Services.Count().ToString().Length;
			foreach (Service service in ServiceController.Instance.Services)
				Console.WriteLine((++i).ToString().PadLeft(padleft) + " - " + service);
			Console.WriteLine("-------------");
			Console.WriteLine("[A]dd a service " + (ServiceController.Instance.Services.Count() > 0 ? "[U]pdate a service [D]elete a service [S]earch " : "") + "[ESC]quit");
		}
	}
}
