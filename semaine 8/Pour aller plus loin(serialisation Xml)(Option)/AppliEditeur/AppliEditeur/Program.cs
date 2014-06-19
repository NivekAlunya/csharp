using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace AppliEditeur
{
    class Program
    {
        private static Livre livre = null;
        private static List<Livre> lesLivres = null;
        private static Auteur auteur = null;
        private static Commande cmd = null;
        private static Client client = null;

        static void Main(string[] args)
        {
            try
            {
                Bouchon();
                //visualiserCollection(lesLivres);
                //Console.WriteLine(cmd.ToString());

                String fichier;
                String chaine;
                string chaineRecup;
                Auteur auteurRecup;
                Livre livreRecup;
                List<Livre> livresRecup;
                Commande cmdRecup;
                ///*
                // * Serialisation Binaire : 
                // * BinaryFormatter
                // * [Serializable], [NonSerialized],[OnSerialized],[OnSerializing],[OnDeserialized],[OnDeserializing]
                // * 
                // */
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Tests du Formatter Binaire");
                Console.ResetColor();
                //Serialisation binaire d'un objet isolé (String)
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "string.txt");
                chaine = "Chaine à sérialiser";
                SerialiserBinaire(chaine, fichier);

                chaineRecup = DeserialiserBinaire<string>(fichier);
                Console.WriteLine("objet déserialisé : BINAIRE " + chaineRecup);

                //Serialisation binaire d'un objet hérité (Auteur)
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "auteur.txt");
                SerialiserBinaire(auteur, fichier);

                auteurRecup = DeserialiserBinaire<Auteur>(fichier);
                Console.WriteLine("objet hérité déserialisé : BINAIRE " + auteurRecup.ToString());

                //Serialisation binaire d'un objet lié (Livre)
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "livre.txt");
                SerialiserBinaire(livre, fichier);

                livreRecup = DeserialiserBinaire<Livre>(fichier);
                Console.WriteLine("objet lié déserialisé : BINAIRE " + livreRecup.ToString());

                //Serialisation binaire d'une collection d'objets (les livres)
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "livres.txt");
                SerialiserBinaire(lesLivres, fichier);

                livresRecup = DeserialiserBinaire<List<Livre>>(fichier);
                Console.WriteLine("objet collection déserialisé : BINAIRE " + livresRecup);

                //Serialisation binaire d'une collection d'objets (Commande et ses Livres)
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "commande.txt");
                SerialiserBinaire(cmd, fichier);

                cmdRecup = DeserialiserBinaire<Commande>(fichier);
                Console.WriteLine("objet commande déserialisé : BINAIRE " + cmdRecup.ToString());

                /*
                 * Serialisation SOAP
                 * ajouter la référence : System.Runtime.Serialization.Formatters.Soap;
                 * SoapFormatter
                 * Problème sur les collections génériques (attributs SoapIgnore, SoapElement)
                 */
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Tests du Formatter SOAP");
                Console.ResetColor();
                //Serialisation SOAP d'un objet isolé (String)
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "string.soa");
                chaine = "Chaine à sérialiser";
                SerialiserSOAP(chaine, fichier);

                chaineRecup = DeserialiserSOAP<string>(fichier);
                Console.WriteLine("objet déserialisé : SOAP " + chaineRecup);

                //Serialisation SOAP d'un objet hérité (Auteur)
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "auteur.soa");
                SerialiserSOAP(auteur, fichier);

                auteurRecup = DeserialiserSOAP<Auteur>(fichier);
                Console.WriteLine("objet déserialisé : SOAP " + auteurRecup.ToString());

                //Serialisation SOAP d'un objet lié (Livre)
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "livre.soa");
                SerialiserSOAP(livre, fichier);

                livreRecup = DeserialiserSOAP<Livre>(fichier);
                Console.WriteLine("objet déserialisé : SOAP " + livreRecup.ToString());

                //Serialisation SOAP d'une collection d'objets (les livres)
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "livres.soa");
                SerialiserSOAP(lesLivres.ToArray(), fichier);

                livresRecup = DeserialiserSOAP<Livre[]>(fichier).ToList();
                Console.WriteLine("objet déserialisé : SOAP " + livresRecup.ToString());

                //Serialisation SOAP d'une collection d'objets (Commande et ses Livres) 
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "commande.soa");
                SerialiserSOAP(cmd, fichier);

                cmdRecup = DeserialiserSOAP<Commande>(fichier);
                Console.WriteLine("objet déserialisé : SOAP " + cmdRecup);

                /*
                 * Serialisation XML 
                 * XmlSerializer
                 * Regles : 
                 * - classes, structures et énumérations sont sérialisables, pas les interfaces
                 * - les types doivent être publics
                 * - seules les collections typées sont prises en compte
                 * - les membres publics sont sérialisés
                 * - les propriétés ne doivent être en lecture seule sauf pour celles retournant une collection
                 * (dans ce cas la collection doit être instanciée dans le constructeur par défaut)
                 * - un constructeur par défaut public
                 *                  
                 * attributs (lors de la serialisation de la commande)
                 * - XmlRoot (sur Commande)
                 * - XmlAttribute (exemple sur datecde)
                 * - XmlIgnore, XmlElement, 
                 * - controler le format d'une propriété (exemple sur DateCde)
                 * - XmlArray et XmlArrayItem
                 * - énumération Flags (valeurs pouvant être combinées par un OU binaire
                 * et XmlEnum
                 * 
                 * - Sérialisation des classes dérivées (XmlInclude(typeof(Auteur)) et
                 * XmlInclude(typeof(Client)) sur Personne)
                 */
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Tests du Formatter XML");
                Console.ResetColor();
                //Serialisation XML d'un objet isolé (String)
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "string.xml");
                chaine = "Chaine à sérialiser";
                SerialiserXML(chaine, fichier);

                chaineRecup = DeserialiserXML<string>(fichier);
                Console.WriteLine("objet déserialisé : XML " + chaineRecup);

                //Serialisation XML d'un objet hérité (Auteur)
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "auteur.xml");
                SerialiserXML(auteur, fichier);

                auteurRecup = DeserialiserXML<Auteur>(fichier);
                Console.WriteLine("objet déserialisé : XML " + auteurRecup.ToString());

                //Serialisation XML d'un objet lié (Livre)
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "livre.xml");
                SerialiserXML(livre, fichier);

                livreRecup = DeserialiserXML<Livre>(fichier);
                Console.WriteLine("objet déserialisé : XML " + livreRecup.ToString());

                //Serialisation XML d'une collection d'objets (les livres)
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "livres.xml");
                SerialiserXML(lesLivres, fichier);

                livresRecup = DeserialiserXML<List<Livre>>(fichier).ToList();
                Console.WriteLine("objet déserialisé : XML " + livresRecup.ToString());

                //Serialisation XML d'une collection d'objets (Commande et ses Livres) 
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "commande.xml");
                SerialiserXML(cmd, fichier);

                cmdRecup = DeserialiserXML<Commande>(fichier);
                Console.WriteLine("objet déserialisé : XML " + cmdRecup);
                //Console.WriteLine("recup montant : XML " + cmdRecup.getMontantSerial());

                //Serialisation d'une liste polymorphe
                List<Personne> contacts = new List<Personne>();
                contacts.Add(auteur);
                contacts.Add(client);
                fichier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contacts.xml");
                SerialiserXML(contacts, fichier);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
          

            Console.ReadLine();
        }

        private static void SerialiserBinaire<T>(T objet, String destination)
        {
            FileStream fichierSauvegarde = null;
            IFormatter _formatter = new BinaryFormatter();
            try
            {
                fichierSauvegarde = new FileStream(destination, FileMode.Create, FileAccess.Write, FileShare.None);
                _formatter.Serialize(fichierSauvegarde, objet);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Une erreur est survenue lors de la sérialisation : {0}", e.Message));
            }
            finally
            {
                if (fichierSauvegarde != null)
                    fichierSauvegarde.Close();
            }
        }

        private static T DeserialiserBinaire<T>(string origine)
        {
            FileStream fichierSauvegarde = null;
            IFormatter _formatter = new BinaryFormatter();
            T objet;
            try
            {
                fichierSauvegarde = new FileStream(origine, FileMode.Open, FileAccess.Read, FileShare.Read);
                objet = (T)_formatter.Deserialize(fichierSauvegarde);
                return objet;
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Une erreur est survenue lors de la désérialisation : {0}", e.Message));
            }
            finally
            {
                if (fichierSauvegarde != null)
                    fichierSauvegarde.Close();
            }
        }

        private static void SerialiserSOAP<T>(T objet, String destination)
        {
            FileStream fichierSauvegarde = null;
            IFormatter _formatter = new SoapFormatter();
            try
            {
                fichierSauvegarde = new FileStream(destination, FileMode.Create, FileAccess.Write, FileShare.None);
                _formatter.Serialize(fichierSauvegarde, objet);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Une erreur est survenue lors de la sérialisation : {0}", e.Message));
            }
            finally
            {
                if (fichierSauvegarde != null)
                    fichierSauvegarde.Close();
            }
        }

        private static T DeserialiserSOAP<T>(string origine)
        {
            FileStream fichierSauvegarde = null;
            IFormatter _formatter = new SoapFormatter();
            T objet;
            try
            {
                fichierSauvegarde = new FileStream(origine, FileMode.Open, FileAccess.Read, FileShare.Read);
                objet = (T)_formatter.Deserialize(fichierSauvegarde);
                return objet;
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Une erreur est survenue lors de la désérialisation : {0}", e.Message));
            }
            finally
            {
                if (fichierSauvegarde != null)
                    fichierSauvegarde.Close();
            }
        }

        private static void SerialiserXML<T>(T objet, String destination)
        {
            FileStream fichierSauvegarde = null;
            XmlSerializer _formatter = new XmlSerializer(typeof(T));
            try
            {
                fichierSauvegarde = new FileStream(destination, FileMode.Create, FileAccess.Write, FileShare.None);
                _formatter.Serialize(fichierSauvegarde, objet);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Une erreur est survenue lors de la sérialisation : {0}", e.Message));
            }
            finally
            {
                if (fichierSauvegarde != null)
                    fichierSauvegarde.Close();
            }
        }

        private static T DeserialiserXML<T>(string origine)
        {
            FileStream fichierSauvegarde = null;
            XmlSerializer _formatter = new XmlSerializer(typeof(T));
            T objet;
            try
            {
                fichierSauvegarde = new FileStream(origine, FileMode.Open, FileAccess.Read, FileShare.Read);
                objet = (T)_formatter.Deserialize(fichierSauvegarde);
                return objet;
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Une erreur est survenue lors de la désérialisation : {0}", e.Message));
            }
            finally
            {
                if (fichierSauvegarde != null)
                    fichierSauvegarde.Close();
            }
        }

        private static void Bouchon()
        {
            auteur = new Auteur("GROUSSARD", "Thierry", "adresse", "44800", "Saint Herblain", "Tres populaire");

            //reproduire les tests pour le modèle Client      
            client = new Client("dupond", "jean-paul", "13 rue machin", "01263", "ville", DateTime.Now, 10.2f);

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
            lesLivres.Add( new Livre(auteur, "livre2", 366, "123-4-5678-9101-7"));
            lesLivres.Add(new Livre(auteur, "livre3", 666, "123-4-5678-9101-8"));

            //gerer les commandes de Jean-Paul Dupont
            cmd = new Commande(client, lesLivres[2], DateTime.Today);
            
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
