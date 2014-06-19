using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Employees.Store.Serialization
{
    public class SoapSerializator : Serializator
    {
        private static SoapSerializator _instance = null;
        
        public static SoapSerializator Instance
        {
            get
            {
                return _instance == null ? _instance = new SoapSerializator() : _instance;
            }
        }

        private SoapSerializator()
            :base()
        { 
            this.Formatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
        }

    }
}
