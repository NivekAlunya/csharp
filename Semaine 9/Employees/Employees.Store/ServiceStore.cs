using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Model;
using System.Xml;
using System.Xml.Schema;

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

        public static void save(IEnumerable<Service> lst)
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
    }
}
