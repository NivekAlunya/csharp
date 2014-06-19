using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Store
{
    class AccountStore
    {
        public static SqlConnection connection()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = "Server=localhost;Database=Users;Persist Security Info=True;UID=sa;PWD=Pa$$w0rd";
                cn.Open();
            }
            catch (Exception e)
            {
                throw new ApplicationException(String.Format("Something happened {0}", e.Message), e.InnerException);
            }
            return cn;
        }

        public static void disconnect(SqlConnection cn)
        {
            if(null != cn && cn.State != System.Data.ConnectionState.Closed) cn.Close();
        }

        public static bool signin(string login, string password)
        {
            SqlConnection cn=default(SqlConnection);
            int r;
            try
            {
                cn = connection();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "select count(*) from logins where login=@login and password=@password";
                SqlParameter p = cmd.CreateParameter();
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
            return 1==r?true:false;
        }

    }
}
