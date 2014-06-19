using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Model;
using Employees.Store.Database;
using System.ComponentModel;
namespace Employees.Controler
{
    public class EmployeeController
    {
        #region event
        public event EventHandler evtUpdateEmployee;
        #endregion
        #region attributes
        private static EmployeeController _instance = null;
        private BindingList<Employee> _employees;
        #endregion
        #region properties
        public static EmployeeController Instance { 
            get 
            {
                return _instance == null ? _instance = new EmployeeController() : _instance;
            }
        }

        public BindingList<Employee> Employees
        {
            get
            {
                if (null == _employees)
                {
                    _employees = new BindingList<Employee>(EmployeeStore.Instance.getEmployees());
                    
                }
                return _employees;
            }
        }
        #endregion

        #region constructors
        private EmployeeController()
            :base()
        { 
        
        }
        #endregion
        #region methods
        public Employee addEmployee(string surname, string firstname, DateTime dob, DateTime employedAt,int salary, Service service = null, Employee chief = null)
        {
            //implement storage
            Employee emp = EmployeeStore.Instance.addEmployee(surname, firstname, dob, employedAt, salary, service, chief);
            this.Employees.Add(emp);
            return emp;
        }

        public void updateEmployee(Employee employee, string surname, string firstname, DateTime dob, DateTime employedAt, int salary, Service service = null, Employee chief = null)
        {
            EmployeeStore.Instance.updateEmployee(employee,surname,firstname,dob,employedAt,salary,service,chief);    
            if (null != evtUpdateEmployee) evtUpdateEmployee(service, EventArgs.Empty);
        }

        public bool deleteEmployee(Employee target)
        {
            if (null != target)
            {
                this.Employees.Remove(target);
                return EmployeeStore.Instance.deleteEmployee(target);
            }
            return false;
        }
        #endregion
        #region interfaces
        #endregion
    }
}
