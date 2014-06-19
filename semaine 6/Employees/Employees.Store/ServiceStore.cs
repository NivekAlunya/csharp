using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Model;

namespace Employees.Store
{
    public static class ServiceStore
    {
        public static List<Service> getServices()
        {
            List<Service> lst = new List<Service>();
            lst.Add(new Service("MANPW", "Man Power"));
            lst.Add(new Service("BUYER", "Buying People"));
            return lst;
        }

    }
}
