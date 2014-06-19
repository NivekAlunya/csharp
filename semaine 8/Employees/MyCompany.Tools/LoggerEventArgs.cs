using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Tools
{
    public class LoggerEventArgs : EventArgs
    {
        public delegate void LoggerEventHandler(object sender,string action);
        private string _action;
        public string Action { get { return _action; } }
        public LoggerEventArgs(string action)
        {
            _action = action;
        }
    }
}
