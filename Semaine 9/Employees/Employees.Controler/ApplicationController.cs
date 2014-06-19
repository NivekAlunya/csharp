using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Model;
using System.Runtime.Serialization;
using System.IO;
//using Employees.Store.Database;
using Employees.Store.Serialization;

namespace Employees.Controller
{
    [Serializable]
    public class ApplicationPersist:ISerializable
    {
        public enum eStorage
        {
            binary,
            soap
        }
        static private ApplicationPersist _instance=null;
        static private eStorage _format;
        static public eStorage Format { 
            private get 
            { 
                return _format ;
            } 
            set 
            {
                _format = value;
                switch (_format)
	            {
                    case eStorage.soap:
                        serializator = SoapSerializator.Instance;
                        break;
                    case eStorage.binary:
		            default:
                        serializator = BinarySerializator.Instance;
                        break;                        
                }
	        }

        }
        static Serializator serializator;
        static public string outputDirectory { private get; set; }

        static public ApplicationPersist Instance {
            get {
                return null == _instance ? (_instance = new ApplicationPersist()) : _instance;
            }
        }
        
        private Object[] _applicationObjects = new Object[2];

        private ApplicationPersist()
            :base()
        { 

        }

        public void save()
        {
            _applicationObjects[0] = ServiceStore.Instance.getServices().ToArray<Service>();
            _applicationObjects[1] = EmployeeStore.Instance.getEmployees().ToArray<Employee>();
            serializator.Serialize(_applicationObjects, (null != outputDirectory ? outputDirectory + (0 < outputDirectory.Length ? "/" : "") : "") + "application.objects");
        }

        public bool load()
        {
            try
            {
                _applicationObjects = serializator.DeSerialize<Object[]>((null != outputDirectory ? outputDirectory + (0 < outputDirectory.Length ? "/" : "") : "") + "application.objects");
            }
            catch (Exception)
            {

                return false;
            }
            ServiceStore.Instance.load((IEnumerable<Service>)_applicationObjects[0]);
            EmployeeStore.Instance.load((IEnumerable<Employee>)_applicationObjects[1]);
            return true;
        }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
           
        
        }
    }
}
