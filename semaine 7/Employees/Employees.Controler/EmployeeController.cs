using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Model;
using Employees.Store;
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
                    _employees = new BindingList<Employee>(EmployeeStore.getEmployees());
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
            Employee employee;
            this.Employees.Add(employee = new Employee(surname, firstname, dob, employedAt,salary,service, chief));
            return employee;
        }
        public void updateEmployee(Employee employee, string surname, string firstname, DateTime dob, DateTime employedAt, int salary, Service service = null, Employee chief = null)
        {
            object[] saved =new object[7];
            saved[0] = employee.Firstname;
            saved[1] = employee.Surname;
            saved[2] = employee.DOB;
            saved[3] = employee.EmployedAt;
            saved[4] = employee.Service;
            saved[5] = employee.Chief;
            saved[6] = employee.Salary;
            try
            {
                employee.Firstname = firstname;
                employee.Surname = surname;
                employee.DOB= dob;
                employee.EmployedAt = employedAt;
                employee.Service = service;
                employee.Chief = chief;
                employee.Salary = salary;
            }
            catch (Exception e)
            {
                employee.Firstname = (string)saved[0];
                employee.Surname = (string)saved[1];
                employee.DOB = (DateTime)saved[2];
                employee.EmployedAt = (DateTime)saved[3];
                employee.Service = (Service)saved[4];
                employee.Chief = (Employee)saved[5];
                employee.Salary = (int)saved[6];
                throw e;
            }
            if (null != evtUpdateEmployee) evtUpdateEmployee(service, EventArgs.Empty);
        }
        public bool deleteEmployee(Employee target)
        {
            if (null != target)
            {
                return this.Employees.Remove(target);
            }
            return false;
        }
        #endregion
        #region interfaces
        #endregion
    }
}
