using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
namespace Database
{
    class DbAgnostic
    {
        public static IDbConnection connection()
        {
            IDbConnection cn = default(IDbConnection);
            try
            {
                cn = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["postgres"].ProviderName).CreateConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["postgres"].ConnectionString;
                cn.Open();
            }
            catch (Exception e)
            {
                throw new ApplicationException(String.Format("Something happened {0}", e.Message), e.InnerException);
            }
            return cn;
        }

        public static void disconnect(IDbConnection cn)
        {
            if (null != cn && cn.State != System.Data.ConnectionState.Closed) cn.Close();
        }

        public static bool signin(string login, string password)
        {
            IDbConnection cn = default(IDbConnection);
            int r;
            try
            {
                cn = connection();
                IDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = "select count(*) from logins where login=@login and password=@password";
                IDbDataParameter p = cmd.CreateParameter();
                p.ParameterName = "@login";
                p.Value = login;
                p.Direction = System.Data.ParameterDirection.Input;
                p.DbType = System.Data.DbType.String;
                cmd.Parameters.Add(p);
                p = cmd.CreateParameter();
                p.ParameterName = "@password";
                p.Value = password;
                p.Direction = System.Data.ParameterDirection.Input;
                p.DbType = System.Data.DbType.String;
                cmd.Parameters.Add(p);
                cmd.CommandType = System.Data.CommandType.Text;
                r = Convert.ToInt32(cmd.ExecuteScalar());
                //cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow)
            }
            catch (Exception e)
            {
                throw new ApplicationException(String.Format("Something happened {0}", e.Message), e.InnerException);
            }
            finally
            {
                disconnect(cn);
            }
            if (0 == r)
            {
                try
                {
                    cn = connection();
                    IDbCommand cmd = cn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "insertLogin";
                    IDbDataParameter p = cmd.CreateParameter();
                    p.ParameterName = "@login";
                    p.Value = login;
                    cmd.Parameters.Add(p);
                    p = cmd.CreateParameter();
                    p.ParameterName = "@password";
                    p.Value = password;
                    cmd.Parameters.Add(p);

                    p = cmd.CreateParameter();
                    p.ParameterName = "@password";
                    p.Value = password;
                    p.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(p);
                    cmd.ExecuteNonQuery();
                    if (0 == Convert.ToInt32(p.Value))
                    {
                        Console.WriteLine("user created");
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine("user not created");
                }
                finally
                {
                    disconnect(cn);
                }
            }

            return 1 == r ? true : false;
        }

    }
}
