using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace MyCompany.Tools
{
    public class Logger
    {
        private string _name;
        public Logger(string name)
        {
            _name = name;
        }

        public void log(object o, string action)
        {
            Debug.WriteLine("[" + _name + "] " + o.ToString() + " " + action, "Logger");
        }

    }
}
