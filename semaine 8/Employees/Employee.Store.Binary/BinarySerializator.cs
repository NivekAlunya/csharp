using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Employees.Store.Binary
{
    public class BinarySerializator : Serializator
    {
        private static BinarySerializator _instance = null;

        public static BinarySerializator Instance
        {
            get
            {
                return _instance == null ? _instance = new BinarySerializator() : _instance;
            }
        }

        private BinarySerializator()
            :base()
        { 
            this.Formatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
        }

    }
}
