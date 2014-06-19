using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;

using BO;

namespace AppliEditeur
{
    class Program
    {
        private static Livre livre = null;
        private static List<Livre> lesLivres = null;
        private static Auteur auteur = null;
        private static Commande cmd = null;

        static void Main(string[] args)
        {
            run();
            Console.ReadLine();
        }

        private static void run()
        {
            try
            {
                Bouchon();
                //binary formatter
                string s = "ma chaine de caracteres";
                string file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "s.soa");
                SerializeSOAP(s, file);
                Console.WriteLine(file);
                Console.WriteLine(DeSerializeSOAP<string>(file));

                file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "auteur.soa");
                SerializeSOAP(auteur, file);
                Console.WriteLine(file);
                Console.WriteLine((DeSerializeSOAP<Auteur>(file)).ToString());

                file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "livres.soa");
                SerializeSOAP(lesLivres.ToArray(), file);
                Console.WriteLine(file);
                List<Livre> livres = DeSerializeSOAP<List<Livre>>(file);
                visualiserCollection(livres);
                return;
                Console.WriteLine(cmd.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void runBinarySerialization()
        {
            try
            {
                Bouchon();
                //binary formatter
                string s = "ma chaine de caracteres";
                string file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "s.txt");
                SerializeBinary(s, file);
                Console.WriteLine(file);
                Console.WriteLine(DeSerializeBinary<string>(file));

                file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "auteur.txt");
                SerializeBinary(auteur, file);
                Console.WriteLine(file);
                Console.WriteLine((DeSerializeBinary<Auteur>(file)).ToString());

                file = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "livres.txt");
                SerializeBinary(lesLivres, file);
                Console.WriteLine(file);
                List<Livre> livres = DeSerializeBinary<List<Livre>>(file);
                visualiserCollection(livres);
                return;
                visualiserCollection(lesLivres);
                Console.WriteLine(cmd.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static T DeSerializeBinary<T>(string file)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = default(FileStream);
            T deserialized;
            try
            {
                fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None);
                deserialized = (T)bf.Deserialize(fs);
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (null != fs) fs.Close();
            }
            return deserialized;
        }

        private static void SerializeBinary<T>(T object2Serialize, string file)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = default(FileStream);
            try
            {
                fs = new FileStream(file, FileMode.Create);
                bf.Serialize(fs, object2Serialize);

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (null != fs) fs.Close();
            }
        }

        private static void SerializeSOAP<T>(T object2Serialize, string file)
        {
            SoapFormatter sf = new SoapFormatter();
            FileStream fs = default(FileStream);
            try
            {
                fs = new FileStream(file, FileMode.Create);
                sf.Serialize(fs, object2Serialize);
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (null != fs) fs.Close();
            }
        }

        private static T DeSerializeSOAP<T>(string file)
        {
            SoapFormatter sf = new SoapFormatter();
            FileStream fs = default(FileStream);
            T deserialized;
            try
            {
                fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None);
                deserialized = (T)sf.Deserialize(fs);
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (null != fs) fs.Close();
            }
            return deserialized;
        }

        private static void SerializeJSON<T>(T object2Serialize, string file)
        {
            //sf = new SoapFormatter();
            //FileStream fs = default(FileStream);
            //try
            //{
            //    fs = new FileStream(file, FileMode.Create);
            //    sf.Serialize(fs, object2Serialize);
            //}
            //catch (Exception e)
            //{

            //    throw e;
            //}
            //finally
            //{
            //    if (null != fs) fs.Close();
            //}
        }

        //private static T DeSerializeJSON<T>(string file)
        //{
        //    SoapFormatter sf = new SoapFormatter();
        //    FileStream fs = default(FileStream);
        //    T deserialized;
        //    try
        //    {
        //        fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None);
        //        deserialized = (T)sf.Deserialize(fs);
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //    finally
        //    {
        //        if (null != fs) fs.Close();
        //    }
        //    return deserialized;

        //}


        private static void Bouchon()
        {
            auteur = new Auteur("GROUSSARD", "Thierry", "adresse", "44800", "Saint Herblain", "Tres populaire");

            //reproduire les tests pour le modèle Client      
            Client c = new Client("dupond", "jean-paul", "13 rue machin", "01263", "ville", DateTime.Now, 10.2f);

            //un livre en mémoire
            livre = new Livre(auteur,
                                        "les fondamentaux du langage",
                                        377,
                                        "123-4-5678-9101-2");

            //référencer les livres en mémoire
            lesLivres = new List<Livre>();

            //la référence du livre csharp est placée dans le tableau
            lesLivres.Add(livre);
            lesLivres.Add(new Livre(auteur, "livre1", 450, "123-4-5678-9101-6"));
            lesLivres.Add(new Livre(auteur, "livre2", 366, "123-4-5678-9101-7"));
            lesLivres.Add(new Livre(auteur, "livre3", 666, "123-4-5678-9101-8"));

            //gerer les commandes de Jean-Paul Dupont
            cmd = new Commande(c, lesLivres[2], DateTime.Today);

            //ajouter des livres à la commande
            cmd.ajoutLivre(lesLivres[0]);
            cmd.ajoutLivre(lesLivres[3]);
            cmd.ajoutLivre(lesLivres[1]);

        }

        private static void visualiserCollection(List<Livre> _lesLivres)
        {
            Console.WriteLine();
            Console.WriteLine("Collection Editions ENI");
            Console.WriteLine();
            foreach (Livre livre in _lesLivres)
            {
                if (livre != null)
                    Console.WriteLine(livre.ToString());
                else break;
            }
        }
    }
}
