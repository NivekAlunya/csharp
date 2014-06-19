using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using MyCompany.Tools;
using Employees.Model;
namespace Employees.Store.Database
{
    public class EmployeeStore
    {
        static private EmployeeStore _instance;
        static public EmployeeStore Instance { get { return null == _instance ? new EmployeeStore() : _instance; } private set { _instance = value; } }
        private EmployeeStore()
            : base()
        {
            _lst = new List<Employee>();
        }

        private List<Employee> _lst;

        public List<Employee> getEmployees()
        {
            if (0 >= _lst.Count)
            {
                IDbConnection cn = Database.connection();
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from employees order by id asc;";
                IDataReader reader = cmd.ExecuteReader();
                List<Service> services = ServiceStore.Instance.getServices();
                List<Guid> chiefs = new List<Guid>();
                while (reader.Read())
                {
                    Service service = reader.IsDBNull(reader.GetOrdinal("service")) ? null : services.Find((Service s) =>
                    {
                        return (s.Code == reader.GetString(reader.GetOrdinal("service")));
                    });
                    Employee emp = new Employee(
                        reader.GetGuid(reader.GetOrdinal("id")),
                        reader.GetString(reader.GetOrdinal("surname")),
                        reader.IsDBNull(reader.GetOrdinal("firstname")) ? null : reader.GetString(reader.GetOrdinal("firstname")),
                        reader.GetDateTime(reader.GetOrdinal("dob")),
                        reader.GetDateTime(reader.GetOrdinal("employedAt")),
                        (int)reader.GetDecimal(reader.GetOrdinal("salary")),
                        service,
                        null
                        );

                    chiefs.Add(reader.IsDBNull(reader.GetOrdinal("chief")) ? Guid.NewGuid() : reader.GetGuid(reader.GetOrdinal("chief")));
                    _lst.Add(emp);
                }
                //link chief with employee objects
                int cpt = 0;
                foreach (Employee emp in _lst)
                {
                    emp.Chief = _lst.Find((Employee e) =>
                    {
                        return e.ID == chiefs.ElementAt(cpt);
                    });
                    cpt++;
                }

            }
            return _lst;
        }

        public Employee addEmployee(string surname, string firstname, DateTime dob, DateTime employedAt, int salary, Service service = null, Employee chief = null)
        {
            Employee employee;
            //implement storage

            try
            {
                employee = new Employee(surname, firstname, dob, employedAt, salary, service, chief);
                IDbConnection cn = Database.connection();
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into employees(id, surname, firstname, dob, employedAt, salary, service, chief) values(@id,@surname,@firstname,@dob,@employedAt,@salary,@service,@chief)";
                IDataParameter p = cmd.CreateParameter();
                p.ParameterName = "@id";
                p.DbType = DbType.Guid;
                p.Value = employee.ID;
                cmd.Parameters.Add(p);
            
                p = cmd.CreateParameter();
                p.DbType = DbType.String;
                p.Value = employee.Surname;
                p.ParameterName = "@surname";
                cmd.Parameters.Add(p);
            
                p = cmd.CreateParameter();
                p.ParameterName = "@firstname";
                p.DbType = DbType.String;
                p.Value = employee.Firstname;
                cmd.Parameters.Add(p);
            
                p = cmd.CreateParameter();
                p.ParameterName = "@dob";
                p.DbType = DbType.DateTime;
                p.Value = employee.DOB;
                cmd.Parameters.Add(p);
            
                p = cmd.CreateParameter();
                p.ParameterName = "@employedAt";
                p.DbType = DbType.DateTime;
                p.Value = employee.EmployedAt;
                cmd.Parameters.Add(p);
            
                p = cmd.CreateParameter();
                p.ParameterName = "@salary";
                p.DbType = DbType.Int32;
                p.Value = employee.Salary;
                cmd.Parameters.Add(p);
            
                p = cmd.CreateParameter();
                p.ParameterName = "@service";
                p.DbType = DbType.String;
                if (null != employee.Service)
                    p.Value = employee.Service.Code;
                else
                    p.Value = DBNull.Value;
                cmd.Parameters.Add(p);
            
                p = cmd.CreateParameter();
                p.ParameterName = "@chief";
                p.DbType = DbType.Guid;
                if (null != employee.Chief)
                    p.Value = employee.Chief.ID;
                else
                    p.Value = DBNull.Value;
                cmd.Parameters.Add(p);

                if(1 == cmd.ExecuteNonQuery()) 
                    _lst.Add(employee);
                else
                    employee =null;
                }
            catch (Exception e)
            {
                
                throw e;
            }

            return employee;
        }

        public void updateEmployee(Employee employee, string surname, string firstname, DateTime dob, DateTime employedAt, int salary, Service service = null, Employee chief = null)
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

            try
            {
                IDbConnection cn = Database.connection();
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update employees set surname = @surname,firstname = @firstname,dob =@dob,employedAt = @employedAt,salary = @salary,service = @service,chief = @chief where id=@id";
                IDataParameter p = cmd.CreateParameter();
                p.ParameterName = "@id";
                p.DbType = DbType.Guid;
                p.Value = employee.ID;
                cmd.Parameters.Add(p);
            
                p = cmd.CreateParameter();
                p.DbType = DbType.String;
                p.Value = employee.Surname;
                p.ParameterName = "@surname";
                cmd.Parameters.Add(p);
            
                p = cmd.CreateParameter();
                p.ParameterName = "@firstname";
                p.DbType = DbType.String;
                p.Value = employee.Firstname;
                cmd.Parameters.Add(p);
            
                p = cmd.CreateParameter();
                p.ParameterName = "@dob";
                p.DbType = DbType.DateTime;
                p.Value = employee.DOB;
                cmd.Parameters.Add(p);
            
                p = cmd.CreateParameter();
                p.ParameterName = "@employedAt";
                p.DbType = DbType.DateTime;
                p.Value = employee.EmployedAt;
                cmd.Parameters.Add(p);
            
                p = cmd.CreateParameter();
                p.ParameterName = "@salary";
                p.DbType = DbType.Int32;
                p.Value = employee.Salary;
                cmd.Parameters.Add(p);
            
                p = cmd.CreateParameter();
                p.ParameterName = "@service";
                p.DbType = DbType.StringFixedLength;
                if (null != employee.Service)
                    p.Value = employee.Service.Code;
                else
                    p.Value = DBNull.Value;
                cmd.Parameters.Add(p);
            
                p = cmd.CreateParameter();
                p.ParameterName = "@chief";
                p.DbType = DbType.Guid;
                if (null != employee.Chief)
                    p.Value = employee.Chief.ID;
                else
                    p.Value = DBNull.Value;
                
                cmd.Parameters.Add(p);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        public bool deleteEmployee(Employee employee)
        {
            if (null != employee)
            {
                IDbConnection cn = Database.connection();
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update employees set chief = null where id=@id;delete from employees where id=@id;";
                IDataParameter p = cmd.CreateParameter();
                p.ParameterName = "@id";
                p.DbType = DbType.Guid;
                p.Value = employee.ID;
                cmd.Parameters.Add(p);

                return _lst.Remove(employee);
            }

            return false;
        }

        public void save(IEnumerable<Employee> lst )
        {
            
        }

        public void load(IEnumerable<Employee> p)
        {
            _lst = new List<Employee>(p);
        }
    }
}
