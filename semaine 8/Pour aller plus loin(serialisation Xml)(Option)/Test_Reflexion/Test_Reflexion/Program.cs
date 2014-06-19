using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Test_Reflexion
{
    class Program
    {
        static void Main(string[] args)
        {
            ManipBaseReflexion();
            UtiliserReflexion("Villes.xml");
            UtiliserReflexion("Clients.xml");
            Console.ReadKey();
        }

        private static void ManipBaseReflexion()
        {
            //
            //Test 1 : manip de base Reflection
            //
            Assembly asm = default(Assembly);
            //on peut charger un assembly référencé par son nom
            asm = Assembly.Load("BO");

            //on peut charger un assembly par son fichier
            //asm = Assembly.LoadFrom("c:\BO.dll")

            //on peut récupérer l'instance de l'assembly en cours d'execution
            //asm = Assembly.GetExecutingAssembly()

            //
            //parcourir l'assembly pour explorer sa structure
            //
            foreach (Type unType in asm.GetTypes())
            {
                Console.WriteLine(unType.Name);
                foreach (Type UneInterface in unType.GetInterfaces())
                {
                    Console.WriteLine(" implémente " + UneInterface.Name);
                }

                foreach (MemberInfo membre in unType.GetMembers())
                {
                    Console.WriteLine("   - " + membre.Name + " - " + membre.MemberType.ToString());
                }
            }

            //
            //Instancier dynamiquement des types et manipuler leurs membres
            //
            Console.WriteLine(Environment.NewLine);
            object o = asm.CreateInstance("BO.Ville");

            foreach (PropertyInfo oProperty in o.GetType().GetProperties())
            {
                Console.WriteLine("Propriété : " + oProperty.Name);
            }

            foreach (MethodInfo oMethod in o.GetType().GetMethods())
            {
                Console.WriteLine("Méthode : " + oMethod.Name);
            }
            //alimenter les propriétés
            o.GetType().GetProperty("Nom").SetValue(o, "Rennes", null);
            o.GetType().GetProperty("Dept").SetValue(o, "35", null);
            //invoquer une méthode
            Console.WriteLine(o.GetType().GetMethod("ToString").Invoke(o, null));

        }

        private static void UtiliserReflexion(String fichier)
        {
            //
            //Test 2 : création des objets contenus dans les fichiers Villes.xml ou Clients.xml
            //

            string locationAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string rep = System.IO.Path.GetDirectoryName(locationAssembly);
            System.IO.FileInfo finfo = new System.IO.FileInfo(System.IO.Path.Combine(rep, fichier));
            object o = null;

            if (!finfo.Exists)
            {
                throw new Exception("le fichier est introuvable !");
            }

            XDocument xmlObject = XDocument.Load(finfo.FullName);

            IList<object> os = new List<object>();

            foreach (XElement node in xmlObject.Descendants("object"))
            {
                o = System.Reflection.Assembly.Load("BO").CreateInstance(node.Attribute("type").Value);
                foreach (XElement nodeP in node.Descendants("property"))
                {
                    PropertyInfo property = o.GetType().GetProperty(nodeP.Attribute("name").Value);
                    property.SetValue(o, nodeP.Attribute("value").Value, null);
                }
                Console.WriteLine(o.GetType().GetMethod("ToString").Invoke(o, null));
                os.Add(o);
            }

            Console.WriteLine(os.Count);
        }
    }
}
