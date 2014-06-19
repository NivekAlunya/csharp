using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Model;
using System.Xml;
using System.Xml.Schema;
using System.Runtime.Serialization;

namespace Employees.Store.Serialization
{
    public class ServiceStore
    {
        static private ServiceStore _instance;
        static public ServiceStore Instance { get { return null == _instance ? new ServiceStore() : _instance; } private set { _instance = value; } }
        private ServiceStore()
            : base()
        {
            _lst = new List<Service>();
        }
        private List<Service> _lst=null;
            
        public List<Service> getServices()
        {
            if (0 >= _lst.Count)
            {
                _lst.Add(new Service("MANPW", "Man Power"));
                _lst.Add(new Service("BUYER", "Buying People"));
            }
            return _lst;
        }

        public void save(IEnumerable<Service> lst)
        {
            if (null == lst) return;
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", "yes"));
            doc.AppendChild(doc.CreateElement("Services"));
            foreach(Service s in lst)
            {
                XmlElement e = doc.CreateElement("Service");
                e.InnerXml = "<Code>" + s.Code + "</Code>"
                    + "<Label>" + s.Label + "</Label>";
                doc.ChildNodes[1].AppendChild(e);
            }
            doc.Save("Services.xml");
        }

        public void load(IEnumerable<Service> p)
        {
            _lst = new List<Service>(p);
        }

        public Service addService(string code, string label)
        {
            Service service = null;
            try
            {
                _lst.Add(service = new Service(code, label));
            }
            catch (Exception e)
            {
                throw e;
            }
            return service;
        }

        public void updateService(Service service, string code, string label)
        {
            try
            {
                service.memorize();
                service.Code = code;
                service.Label = label;
            }
            catch (Exception e)
            {
                service.restore();
                throw e;
            }
        }

        public bool deleteService(Service target)
        {
            Service targetService = target;
            if (null != targetService)
            {
                _lst.Remove(targetService);
                return true;
            }
            return false;
        }
    }
}
