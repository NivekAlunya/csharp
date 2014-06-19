using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompany.Tools;
using System.ComponentModel;
namespace Employees.Model
{
    [Serializable]
    public class Employee : Person
    {

        #region attributes
        private DateTime _employedAt;
        private int _salary;
        #endregion
        #region properties
       
        public Service Service { get; set; }
        public Employee Chief {get; set;}
        public int Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (0 > value) throw new Exception("Salary can't be negative");
                _salary = value;
            }
}
        public DateTime EmployedAt
        {
            get
            {
                return _employedAt;
            }
            set
            {
                if (DateTime.Now < value || base.DOB.ageOf(value) <= 18) throw new Exception("DOB can't be greater than today and can't be lower than his age can t be lower than 18 years");
                _employedAt = value;
            }
        }

        public int Seniority
        {
            get
            {
                return this.EmployedAt.ageOf(DateTime.Now);
            }
        }
        #endregion
        #region constructors
        /// <summary>
        /// Create an employee
        /// throw Exception
        /// </summary>
        /// <param name="id"></param>
        /// <param name="surname"></param>
        /// <param name="firstname"></param>
        /// <param name="dob"></param>
        /// <exception cref="Exception"></exception>
        public Employee(string surname, string firstname, DateTime dob, DateTime employedAt,int salary, Service service = null, Employee chief = null)
            : this(Guid.NewGuid(), surname, firstname, dob, employedAt,salary,service,chief)
        {
        }
        /// <summary>
        /// Dedicated constructor
        /// throw Exception
        /// </summary>
        /// <param name="id"></param>
        /// <param name="surname"></param>
        /// <param name="firstname"></param>
        /// <param name="dob"></param>
        /// <exception cref="Exception"></exception>
        public Employee(Guid id, string surname, string firstname, DateTime dob, DateTime employedAt, int salary, Service service = null, Employee chief = null)
            : base(id, surname, firstname, dob)
        {
            try
            {
                EmployedAt = employedAt;
                Salary = salary;
                Chief = chief;
                Service = service;

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public Employee()
        {

        }
        #endregion
        #region methods
        public string myInformations(DisplayingOption wich)
        {
            switch (wich)
            {
                case DisplayingOption.Simple:
                    break;
                case DisplayingOption.WithAge:
                    break;
                case DisplayingOption.WithSalary:
                    break;
                case DisplayingOption.WithSeniority:
                    break;
                case DisplayingOption.All:
                    break;
                case DisplayingOption.Default:
                    break;
                default:
                    break;
            }
            return "";
         }
        public override string introduceYou()
        {
            return "Hello ! i m " + base.ToString();
        }
        public string yourSalary()
        {
            return "my salary is " + this.Salary;
        }
        public override string ToString()
        {
            return this.introduceYou() + " " + this.yourSalary() + (null != this.Service ? " I m working in " + this.Service : "") + (null != this.Chief ? " My chief is " + this.Chief:"");
        }
        #endregion

    }
}
