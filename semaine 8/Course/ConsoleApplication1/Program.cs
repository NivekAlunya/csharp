using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
namespace Course.XML
{
    class Program
    {
        private static void Main(string[] args)
        {
            run();
            Console.ReadKey();
        }
        private static void run()
        {
            
        }

        private static void runXML()
        {
        XmlDocument doc = load("Menu.xml");
            addAttributeWithDOM(doc);
            addNodeWithDOM(doc);
            parseDocXmlWithDOM(doc);
            Console.WriteLine("-----------XPATH--------------");
            //Console.WriteLine("#####//menu[@type=\"cheap\"]");
            //parseDOMWithXPAth(doc, "//menu[@type=\"cheap\"]");
            //Console.WriteLine("\n\n#####//menu[count(cheese) = 0]");
            //parseDOMWithXPAth(doc, "//menu[count(cheese) = 0]");
            Console.WriteLine("\n\n#####//menu[count(cheese) = 0]");
            parseDOMWithXPAth(doc, "//menu[//*/. =  \"irish coffee\"]");

            doc.Save("Menu.saved.xml");
        }
        private static void parseDOMWithXPAth(XmlDocument doc, string xpathQuery)
        {
            XPathNavigator navx = doc.CreateNavigator();
            XPathNodeIterator it = navx.Select(xpathQuery);
            while (it.MoveNext())
            {
                Console.WriteLine(it.Current.OuterXml);
                if (it.Current.MoveToFirstChild())
                {
                    Console.WriteLine("--" + it.Current.Value);
                    while (it.Current.MoveToNext())
                    {
                        Console.WriteLine("--" + it.Current.Value);
                    }
                }

            }
        }

        private static XmlDocument load(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            return doc;
            
        }
        private static void addAttributeWithDOM(XmlDocument doc)
        {
            XmlAttribute attrTips = default(XmlAttribute);
            foreach (XmlNode nodeMenu in doc.GetElementsByTagName("menu"))
            {
                attrTips = doc.CreateAttribute("tips");
                attrTips.Value = "cheap" == nodeMenu.Attributes["type"].Value ? "10" : "20";
                nodeMenu.Attributes.Append(attrTips);
            }
        }

        private static void addNodeWithDOM(XmlDocument doc)
        {
            XmlNode node = default(XmlNode);
            foreach (XmlNode nodeMenu in doc.GetElementsByTagName("menu"))
            {
                if ("gastronomic" == nodeMenu.Attributes["type"].Value)
                {
                    node = doc.CreateNode(XmlNodeType.Element, "liquor", "");
                    nodeMenu.AppendChild(node);
                    
                    XmlNode node2 = doc.CreateElement("name");
                    node.AppendChild(node2);
                    XmlNode txt = doc.CreateNode(XmlNodeType.Text, "", "");
                    txt.Value = "cognac";
                    node2.AppendChild(txt);
                    XmlNode node3 = doc.CreateNode(XmlNodeType.Attribute,"energy","");
                    node3.Value = "300";
                    node2.Attributes.Append((XmlAttribute)node3);
                }
            }
        }

        private static void parseDocXmlWithDOM(XmlDocument doc)
        {
            foreach (XmlNode nodeMenu in doc.GetElementsByTagName("menu"))
            {
                Console.Write("type :");
                Console.WriteLine(nodeMenu.Attributes["type"].Value);
                Console.Write("price :");
                Console.WriteLine(null != nodeMenu.Attributes["price"] ? nodeMenu.Attributes["price"].Value : "no price");
                Console.Write("tips :");
                Console.WriteLine(null != nodeMenu.Attributes["tips"] ? nodeMenu.Attributes["tips"].Value : "no tips");
                foreach (XmlNode nodeName in nodeMenu.ChildNodes)
                {
                    Console.WriteLine("{1} ==> {0}", nodeName.Name, nodeName.NodeType);
                    foreach (XmlNode nodeText in nodeName.ChildNodes)
                    {
                        Console.WriteLine(nodeText.NodeType + " = " + nodeText.InnerText);
                    }
                }
            }
        }
    }
}
