using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Model;
using System.Xml;
using System.Xml.Schema;
using MyCompany.Tools;
namespace Employees.Store
{
    public static class EmployeeStore
    {
        private static List<Employee> _lst;

        public static List<Employee> getEmployees()
        {
            if (null == _lst)
            {
                _lst = new List<Employee>();
                _lst.Add(new Employee("Jobs", "Steve", new DateTime(1956, 1, 1), new DateTime(1976, 1, 1), 1, ServiceStore.getServices().ElementAt(0)));
                _lst.Add(new Employee("Wozniak", "Steve", new DateTime(1953, 1, 1), new DateTime(1976, 1, 1), 1, ServiceStore.getServices().ElementAt(1),_lst[0]));
            }
            return _lst;
        }

        public static void save(IEnumerable<Employee> lst )
        {
            //XmlNamespaceManager xmlns = new XmlNamespaceManager();
            //xmlns.AddNamespace("tns","http://localhost/Employee.xsd");
            if (null == lst) return;
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", "yes"));
            bool haserror = false;
            doc.AppendChild(doc.CreateElement("Employees"));
            //doc.DocumentElement.SetAttribute("xmlns", "http://localhost/Employee.xsd");
            //doc.DocumentElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            //doc.DocumentElement.SetAttribute("xsi:noNamespaceSchemaLocation", "Employee.xsd");

            foreach (Employee emp in _lst)
            {
                doc.ChildNodes[1].AppendChild(buildEmployeeNode(emp,doc));    
            }

            doc.Save("_employees.xml");
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            XmlReader reader = XmlReader.Create("_employees.xml",settings);
            XmlSchema s = doc.Schemas.Add("http://localhost/Employee.xsd", "Employee.xsd");
            doc.Load(reader);
            try
            {
                doc.Validate((Object sender, ValidationEventArgs e) =>
                {
                    switch (e.Severity)
                    {
                        case XmlSeverityType.Error:
                            haserror = true;
                            break;
                        case XmlSeverityType.Warning:
                            break;
                        default:

                            break;
                    }
                });
            }
            catch (Exception e)
            {
            }
            finally
            {
                reader.Close();
                System.IO.File.Delete("_employees.xml");
            }
            if (!haserror) doc.Save("Employees.xml");
        }

        private static XmlElement buildEmployeeNode(Employee emp,XmlDocument doc)
        {
            XmlElement e= doc.CreateElement("Employee");
            XmlAttribute attr = doc.CreateAttribute("ID");
            attr.Value = emp.ID.ToString();
            e.Attributes.Append(attr);
            if (null != emp.Chief)
            {
                attr = doc.CreateAttribute("Chief");
                attr.Value = emp.Chief.ID.ToString();
                e.Attributes.Append(attr);
            }

            attr = doc.CreateAttribute("Service");
            attr.Value = emp.Service.Code;
            e.Attributes.Append(attr);

            e.InnerXml = "<Surname>" + emp.Firstname.escapeXmlString() + "</Surname>"
                + "<Firstname>" + emp.Firstname.escapeXmlString() +  "</Firstname>"
                + "<DOB>" + emp.DOB.ToString().escapeXmlString() + "</DOB>"
                + "<EmployedAt>" + emp.EmployedAt.ToString().escapeXmlString() + "</EmployedAt>"
                + "<Salary>" + emp.Salary.ToString().escapeXmlString() + "</Salary>"
            ;

            return e;
        }
    }
}
