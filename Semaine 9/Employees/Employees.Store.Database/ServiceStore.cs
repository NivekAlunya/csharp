using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Employees.Model;

namespace Employees.Store.Database
{
    public class ServiceStore
    {
        static private ServiceStore _instance;
        static public ServiceStore Instance { get { return null == _instance ? new ServiceStore() : _instance; } private set { _instance = value; } }
        private ServiceStore()
            : base()
        {
            _lst = new List<Service>();
        }

        private List<Service> _lst = null;

        public List<Service> getServices()
        {

            if (0 >= _lst.Count)
            {
                IDbConnection cn = Database.connection();
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from services";
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Service service = new Service(
                        reader.GetString(reader.GetOrdinal("code")),
                        reader.GetString(reader.GetOrdinal("label"))
                    );
                    _lst.Add(service);
                }
            }
            return _lst;
        }

        
        public void save(IEnumerable<Service> lst)
        {
        }

        public void load(IEnumerable<Service> p)
        {
            _lst = new List<Service>(p);
        }

        public Service addService(string code, string label)
        {
            Service service = null;

            try
            {
                service =  new Service(code, label);
                IDbConnection cn = Database.connection();
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into services values(@code,@label)";
                IDataParameter p = cmd.CreateParameter();
                p.DbType = DbType.String;
                p.Value = service.Code;
                p.ParameterName = "@code";
                cmd.Parameters.Add(p);
            
                p = cmd.CreateParameter();
                p.ParameterName = "@label";
                p.DbType = DbType.String;
                p.Value = service.Label;
                cmd.Parameters.Add(p);

                if(1 == cmd.ExecuteNonQuery()) 
                    _lst.Add(service);
                else
                    service =null;
            }
            catch (Exception e)
            {
                throw e;
            }

            return service;
        }

        public void updateService(Service service, string code, string label)
        {
            string targetcode = service.Code;
            try
            {
                service.memorize();
                service.Code = code;
                service.Label = label;
            }
            catch (Exception e)
            {
                service.restore();
                throw e;
            }

            try
            {
                IDbConnection cn = Database.connection();
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update services set code = @code,label = @label where code=@targetcode";
                IDataParameter p = cmd.CreateParameter();
                p.DbType = DbType.String;
                p.Value = targetcode;
                p.ParameterName = "@targetcode";
                cmd.Parameters.Add(p);
                
                p.DbType = DbType.String;
                p.Value = service.Code;
                p.ParameterName = "@code";
                cmd.Parameters.Add(p);

                p = cmd.CreateParameter();
                p.ParameterName = "@label";
                p.DbType = DbType.String;
                p.Value = service.Label;
                cmd.Parameters.Add(p);

                if (1 == cmd.ExecuteNonQuery())
                    _lst.Add(service);
                else
                    service = null;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public bool deleteService(Service service)
        {

            if (null != service)
            {
                try
                {
                    IDbConnection cn = Database.connection();
                    IDbCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from services where code=@code and not exists(select * from employees where employees.service = services.Code);";
                    IDataParameter p = cmd.CreateParameter();
                    p.ParameterName = "@code";
                    p.DbType = DbType.String;
                    p.Value = service.Code;
                    cmd.Parameters.Add(p);
                    cmd.ExecuteNonQuery();
                    EmployeeStore.Instance.getEmployees().RemoveAll((e) =>
                    {
                        return e.Service.Code == service.Code;
                    });
                }
                catch (Exception e)
                {
                    
                    throw e;
                }

                return _lst.Remove(service); ;
            }
            return false;
        }

    }
}
