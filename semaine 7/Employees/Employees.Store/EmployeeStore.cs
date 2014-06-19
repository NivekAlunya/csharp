using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Model;

namespace Employees.Store
{
    public static class EmployeeStore
    {
        private static List<Employee> _lst;
        public static List<Employee> getEmployees()
        {
            if (null == _lst)
            {
                _lst = new List<Employee>();
                _lst.Add(new Employee("Jobs", "Steve", new DateTime(1956, 1, 1), new DateTime(1976, 1, 1), 1, ServiceStore.getServices().ElementAt(0)));
                _lst.Add(new Employee("Wozniak", "Steve", new DateTime(1953, 1, 1), new DateTime(1976, 1, 1), 1, ServiceStore.getServices().ElementAt(1)));
            }
            return _lst;
        }
    }
}
