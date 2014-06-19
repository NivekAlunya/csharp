using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Model
{
    class TeamOf<T> where T : Person , new()
    { 
        #region attributes
        private T[] _employees;
        private int _cursor = 0;
        #endregion
        #region constructors
        public TeamOf(int amountOf = 100)
        {
            _employees = new T[amountOf];
        }
        #endregion
        #region methods
        public void addEmployee(T employee)
        {
            if (_cursor >= _employees.Length)
            { 
                throw new Exception("No space left in the array of employees");
            }
            _employees[_cursor++] = employee;
        }
        public T teammateAt(int index)
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
