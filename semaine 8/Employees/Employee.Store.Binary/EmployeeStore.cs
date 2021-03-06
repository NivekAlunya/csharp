﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using MyCompany.Tools;
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
                _lst.Add(new Employee("Wozniak", "Steve", new DateTime(1953, 1, 1), new DateTime(1976, 1, 1), 1, ServiceStore.getServices().ElementAt(1),_lst[0]));
            }
            return _lst;
        }

        public static Employee addEmployee(string surname, string firstname, DateTime dob, DateTime employedAt, int salary, Service service = null, Employee chief = null)
        {
            Employee employee;
            //implement storage

            _lst.Add(employee = new Employee(surname, firstname, dob, employedAt, salary, service, chief));
            return employee;
        }

        public static void updateEmployee(Employee employee, string surname, string firstname, DateTime dob, DateTime employedAt, int salary, Service service = null, Employee chief = null)
        {
            object[] saved = new object[7];
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
                employee.DOB = dob;
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
        }

        public static bool deleteEmployee(Employee target)
        {
            if (null != target)
            {
                return _lst.Remove(target);
            }
            return false;
        }


        public static void save(IEnumerable<Employee> lst )
        {
            
        }

        public static void load(IEnumerable<Employee> p)
        {
            _lst = new List<Employee>(p);
        }

    }
}
