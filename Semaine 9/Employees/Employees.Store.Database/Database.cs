using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace Employees.Store.Database
{
    class Database
    {
        public static IDbConnection connection()
        {
            IDbConnection cn = default(IDbConnection);
            try
            {
                cn = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["sqlserver"].ProviderName).CreateConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["sqlserver"].ConnectionString;
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

    }
}
