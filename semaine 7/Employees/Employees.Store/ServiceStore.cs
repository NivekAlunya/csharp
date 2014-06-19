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
        private static List<Service> _lst=null;
            
        public static List<Service> getServices()
        {
            if (null == _lst)
            {
                _lst = new List<Service>();
                _lst.Add(new Service("MANPW", "Man Power"));
                _lst.Add(new Service("BUYER", "Buying People"));
            }
            return _lst;
        }

    }
}
