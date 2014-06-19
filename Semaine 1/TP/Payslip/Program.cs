using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payslip
{

    class Program
    {
        const double RDS = 0.0349, CSG = .0615, HEALTH = 0.0095, OLDAGE = 0.0844, UNEMPLOYEMENT = 0.0305, PENSION = 0.0381, AGFF = 0.0102;
        const int FULLTIME = 169, OVERTIME = 180;
        enum Status
        {
            unknown,
            single,
            married,
            divorced,
            widow
        }
        enum CalculMode
        {
            rule1,
            rule2,
            rule3
        }

        struct Employee
        {
            public string name;
            public Status status;
            public CalculMode mode;
            public double hourlyRate;
            public double workTime;
            public short child; 
        }
        struct Payslip {
            public double gross;
            public double contributions;
            public double bonus;
            public double salary;
        }

        static void Main(string[] args)
        {
            run();
            Console.ReadKey();
        }
        
        static void run()
        {
            Payslip ps;
            Employee employee;
            employee = catchEmployee();
            ps = computePaySlip(employee);
            displayEmployeePaySlip(employee, ps);
        }
        static void displayEmployeePaySlip(Employee employee, Payslip payslip)
        {
            Console.WriteLine("== Payslip of " + employee.name + " (" + employee.status + ") ==");
            Console.WriteLine("gross : " + payslip.gross);
            Console.WriteLine("contributions : " + payslip.contributions);
            Console.WriteLine("bonus : " + payslip.bonus);
            Console.WriteLine("---------------");
            Console.WriteLine("salary : " + payslip.salary);

        }
        static Payslip computePaySlip(Employee employee)
        {
            Payslip ps;
            
            ps.gross = computeBaseSalary(employee.hourlyRate,employee.workTime,employee.mode);
            ps.contributions = computeContributions(ps.gross);
            ps.bonus = computeBonus(employee.child);
            ps.salary=ps.gross - ps.contributions + ps.bonus;

            return ps;
        }
        static double computeBonus(short child)
        {
            if (2 == child)
                return 50;
            else if (2 > child)
                return 20 * child;
            else
                return 70 + (child - 2) * 20;

        }
        static double computeContributions(double baseSalary)
        {
            return baseSalary * RDS
                + baseSalary * CSG
                + baseSalary * HEALTH
                + baseSalary * OLDAGE
                + baseSalary * UNEMPLOYEMENT
                + baseSalary * PENSION
                + baseSalary * AGFF;
        }
        static double computeBaseSalary(double hourlyRate,double workTime, CalculMode mode)
        {
            double baseSalary = 0;
            switch (mode)
            {
                case CalculMode.rule1:
                    baseSalary = hourlyRate * workTime;
                    break;
                case CalculMode.rule2:
                    baseSalary = (hourlyRate * FULLTIME) + ((workTime - FULLTIME) * hourlyRate * 1.5);
                    break;
                case CalculMode.rule3:
                    baseSalary = (hourlyRate * FULLTIME) 
                        + ((OVERTIME - FULLTIME) * hourlyRate * 1.5) 
                        + ((workTime - OVERTIME) * hourlyRate * 1.6);
                    break;
            }
            return baseSalary;
        }


        static Employee catchEmployee()
        {
            Employee employee;
            Console.Write("Name : ");
            employee.name = Console.ReadLine();
            employee.status = catchStatus();
            employee.child = catchChild();
            employee.hourlyRate = catchHourlyRate();
            employee.workTime = catchWorkTime();
            employee.mode = selectRule(employee.workTime);
            
            return employee;
        }

        static double catchWorkTime()
        {
            bool booloop = true;
            double time = 0.0;
            
            Console.Write("Work duration in hours:");
            do
            {
                try
                {
                    if (double.TryParse(Console.ReadLine().Replace(".", ","), out time) && 0 <= time)
                        booloop = false;
                    else
                        Console.Write("Please enter a positive time in hours like 169,25 :");

                }
                catch (Exception e)
                {
                    Console.Write("Please enter a positive time in hours like 169,25 :");
                }
            } while (booloop);
            
            return time;
        }

        static double catchHourlyRate()
        {
            bool booloop = true;
            double hourlyrate = 0.0;
            
            Console.Write("Hourly rate in Euros:");
            
            do
            {
                try
                {
                    if (double.TryParse(Console.ReadLine().Replace(".", ","), out hourlyrate) && 0 < hourlyrate)
                        booloop = false;
                    else
                        Console.Write("Please enter a positive hourly rate in Euros like 9,25 :");
                }
                catch (Exception e)
                {
                    Console.Write("Please enter a positive hourly rate in Euros like 9,25 :");
                }
            } while (booloop);
            return hourlyrate;
        }

        static short catchChild()
        {
            short child = 0;
            bool ok = false;

            Console.Write("\nNumber of childs :");
            
            do
            {
                try
                {
                    if (short.TryParse(Console.ReadLine(), out child) && 0 <= child && 50 >= child)
                        ok = true;
                    else
                        Console.Write("\nWrong value ! Please enter a positive integer value like 2 for the number of child. Retry : ");
            
                }
                catch (Exception e)
                {
                    Console.Write("\nWrong value ! Please enter a positive integer value like 2 for the number of child. Retry : ");
                }
            }
            while (false == ok);

            return child;
        }


        static Status catchStatus()
        {
            int c;
            bool ok = false;
            
            Console.Write("\nWhat is the status of the employee '0' for unknown '1' for single '2' for married '3' for divorced '4' for widow(er) ?");
            
            do
            {
                c = (int)Console.ReadKey().KeyChar - 48;
                if ((int)Status.unknown <= c && (int)Status.widow >= c) ok = true;

            }
            while (false == ok);

            return (Status)c;
        }

        static CalculMode selectRule(double workTime)
        {
            if (FULLTIME >= workTime)
                return CalculMode.rule1;
            else if (OVERTIME >= workTime)
                return CalculMode.rule2;
            else
                return CalculMode.rule3;
        }

    }
}
