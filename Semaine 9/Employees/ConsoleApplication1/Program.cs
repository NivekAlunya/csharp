using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Employees.Model;
using Employees.Store;
using MyCompany.Tools;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            runSerialize();
            Console.ReadKey();
        }

        private static void runSerialize()
        {
            ApplicationPersist.Formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            ApplicationPersist.Instance.load();

            //ApplicationPersist.Instance.save();
        }

        static void runXmlStore()
        {
            runTestObject();
            EmployeeStore.save(EmployeeStore.getEmployees());
            ServiceStore.save(ServiceStore.getServices());

        }

        static void runTestObject()
        {
            Debug.WriteLine((new DateTime(2008, 4, 6)).ageOf(new DateTime(2006, 4, 7)));
            Debug.WriteLine("HUm_19-x".isServiceCode());
            Debug.WriteLine('a'.isLetter());
            Debug.WriteLine('A'.isUpperLetter());

            Debug.WriteLine('A'.toLower());
            Debug.WriteLine("LAUNAY Kevin".fisrtChar2uppperForEachWord());
            Employee p = null;
            Service s = null;
            p = new Employee("LAUNAY", "Kevin", new DateTime(1978, 4, 7), new DateTime(2007, 5, 1), 45000,
                    new Service("SLAVE", "SLAVES"),
                    new Employee("Chief", "chef", new DateTime(1958, 12, 7), new DateTime(1978, 1, 1), 60000,
                        new Service("mastr", "Masters")
                        , null));
            displayPerson(p);
            Team t = null;
            t = new Team(1);
            t.addEmployee(p);
        }

        static void displayPerson(Person person)
        {
            Debug.WriteLine(person.introduceYou());
            if (person is Employee) 
            {
                Employee p = (Employee)person;
                Debug.WriteLine(p);
            }
        }
    }
}
