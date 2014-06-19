using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Model;
using System.Runtime.Serialization;
using System.IO;
namespace Employees.Store
{
    [Serializable]
    public class ApplicationPersist
    {
        static private ApplicationPersist _instance=null;

        static public IFormatter Formatter { private get; set; }
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
            if (null != Formatter)
            {
                _applicationObjects[0] = ServiceStore.getServices();
                _applicationObjects[1] = EmployeeStore.getEmployees();
                Serialize(_applicationObjects, (null != outputDirectory ? outputDirectory + (0 < outputDirectory.Length ? "/" : "") : "") + "application.objects");
            }
        }

        public bool load()
        {
            try
            {
                _applicationObjects = DeSerialize<Object[]>((null != outputDirectory ? outputDirectory + (0 < outputDirectory.Length ? "/" : "") : "") + "application.objects");
            }
            catch (Exception)
            {

                return false;
            }
            ServiceStore.load((IEnumerable<Service>)_applicationObjects[0]);
            EmployeeStore.load((IEnumerable<Employee>)_applicationObjects[1]);
            return true;
        }


    }
}
