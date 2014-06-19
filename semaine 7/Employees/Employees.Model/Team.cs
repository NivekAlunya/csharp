using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Model
{
    public class Team
    {
        #region attributes
        private Employee[] _employees;
        private int _cursor = 0;
        #endregion
        #region constructors
        public Team(int amountOf = 100)
        {
            _employees = new Employee[amountOf];
        }
        #endregion
        #region methods
        public void addEmployee(Employee employee)
        {
            if (_cursor >= _employees.Length)
            { 
                throw new Exception("No space left in the array of employees");
            }
            _employees[_cursor++] = employee;
        }
        public Employee employeeAt(int index)
        {
            if (0 > index || _cursor <= index )
            {
                throw new Exception("Can t retrieve employee at this index!!!!");
            }
            return _employees[index];
        }
        #endregion

    }
}
