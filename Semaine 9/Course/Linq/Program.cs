using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
namespace Linq
{
    class Program
    {
        private static List<Auteur> listeAuteurs = new List<Auteur>();
        private static List<Livre> listeLivres = new List<Livre>();

        static void Main(string[] args)
        {

            run();
            Console.ReadKey();
        }

        static IEnumerable<int> y()
        { 
            int i = 0;
            yield return ++i;
        }

        static void run()
        {
            InitialiserDatas();
            TestLinq();
        }
        private static void TestLinq()
        {
            string charselect = "G";
            afficherTitre("Afficher la liste des auteurs dont le nom commence par G");
            var linq = from Auteur aut in listeAuteurs
                       where aut.Nom.StartsWith(charselect)
                       select aut;
            foreach (Auteur a in linq)
            {
                Console.WriteLine(a.Nom + "    " + a.Prenom);
            }
            afficherTitre("Afficher les noms et prénoms des auteurs dont le nom commence par G (projection modifiée)");
            var linq1 = from Auteur aut in listeAuteurs
                        where aut.Nom.StartsWith(charselect)
                        select new { aut.Nom, aut.Prenom };
            foreach (var a in linq1)
            {
                Console.WriteLine(a.Nom + "    " + a.Prenom);
            }


            afficherTitre("Afficher la liste des auteurs dont le nom commence par G (projection modifiée avec alias )");
            var linq2 = from Auteur aut in listeAuteurs
                        where aut.Nom.StartsWith(charselect)
                        select new { leNom = aut.Nom, lePrenom = aut.Prenom };
            foreach (var a in linq2)
            {
                Console.WriteLine(a.leNom + "    " + a.lePrenom);
            }
            //***********************************************************************************
            afficherTitre("Afficher les livres des auteurs dont le nom commence par G (modèle objet)");
            var linq3 = from Livre liv in listeLivres
                        where liv.Auteur.Nom.StartsWith(charselect)
                        select liv;
            foreach (Livre l in linq3)
            {
                Console.WriteLine(l.Titre + "    " + l.Auteur.Nom);
            }
            afficherTitre("Afficher les livres des auteurs dont le nom commence par G (jointure)");
            Auteur d;
            var linq4 = from Livre l in listeLivres
                        join Auteur a in listeAuteurs on l.Auteur equals a
                        select l;

            foreach (Livre l in linq4)
            {
                Console.WriteLine(l.Titre + "    " + l.Auteur.Nom);
            }
            afficherTitre("Afficher les livres des auteurs dont le nom commence par G (jointure avec alias)");
            var linq5 = from Livre l in listeLivres
                        join Auteur a in listeAuteurs on l.Auteur equals a
                        where a.Nom.StartsWith(charselect)
                        select l;

            foreach (Livre l in linq5)
            {
                Console.WriteLine(l.Titre + "    " + l.Auteur.Nom);
            }
            afficherTitre("Afficher les livres des auteurs dont le nom commence par G (produit cartésien)");
            var linq6 = from Livre l in listeLivres
                        from Auteur a in listeAuteurs
                        where a.Nom.StartsWith(charselect) & a == l.Auteur
                        select l;
            foreach (Livre l in linq5)
            {
                Console.WriteLine(l.Titre + "    " + l.Auteur.Nom);
            }


            //***********************************************************************************
            afficherTitre("Afficher les auteurs et la liste de leurs livres (regroupement sur jointure : join into)");
            var linq7 = from Auteur auteur in listeAuteurs
                        join Livre livre in listeLivres on auteur equals livre.Auteur into auteur_livre
                        select new { auteur, auteur_livre };
            
            foreach (var t in linq7)
            {
                Console.WriteLine(t.auteur.Nom);
                foreach(var l in t.auteur_livre)
                {
                    Console.WriteLine("-----" + l.Titre);
                }
            }

            
            
            afficherTitre("Afficher les auteurs et la liste de leurs livres (regroupement sans jointure : group into)");

            var linq8 = from Livre livre in listeLivres
                          group livre by livre.Auteur into livre_per_auteur
                        select new { livre_per_auteur.Key, livre_per_auteur };

            foreach (var t in linq8)
            {
                Console.WriteLine(t.Key.Nom);
                foreach (var l in t.livre_per_auteur)
                {
                    Console.WriteLine("-----" + l.Titre);
                }
            }

            //***********************************************************************************
            afficherTitre("Afficher tous les titres des livres");
            var linq9 = from Livre livre in listeLivres
                        select livre.Titre;

            foreach (var t in linq9)
            {
                Console.WriteLine(t);
            }


            afficherTitre("Afficher tous les titres différents des livres (Distinct())");
            var linq10 = linq9.Distinct();
            foreach (var t in linq10)
            {
                Console.WriteLine(t);
            }


            //***************************************************************************************
            afficherTitre("Création d'une liste de livres triée par auteur trié");
            var linq11 = from Livre livre in listeLivres
                         orderby livre.Titre,livre.Auteur.Nom
                         select livre;
            
            foreach (Livre l in linq11)
            {
                Console.WriteLine(l.Titre + " [" + l.Auteur.Nom + "]");
            }

            //***************************************************************************************
            afficherTitre("Afficher le plus grand nombre de pages");
            
            Console.WriteLine(listeLivres.Max(o => o.NbPages).ToString());

            var linq20 = from l in 
                         (from ls in listeLivres
                         where ls.NbPages>500
                              select ls.NbPages)
                          select l;
            foreach (var l in linq20)
            {
                Console.WriteLine(l);
            }
            

            //***************************************************************************************
            afficherTitre("Afficher les auteurs facturés et la moyenne de leur(s) facture(s)");
            var linq12 = from Auteur auteur in listeAuteurs
                         where auteur.Factures.Count>0 
                         select auteur;

            foreach (Auteur a in linq12)
            {
                Console.WriteLine(a.Nom + " [" + a.Factures.Average( f => f.Montant) + "]");
            }

            afficherTitre("Afficher la liste des livres dont le nombre de page est > à la moyenne");
            foreach (Livre livre in listeLivres.Where(l => l.NbPages > listeLivres.Average( (o) => { return o.NbPages; } )))
            {
                Console.WriteLine(livre.Titre + " [" + livre.NbPages + "]");
            }
            
            //***************************************************************************************
            afficherTitre("Afficher l'auteur ayant écrit le plus de livres");
            var linq13 = from Livre livre in listeLivres
                         group livre by livre.Auteur into livre_per_auteur
                         select new { key = livre_per_auteur.Key, count = livre_per_auteur.Count() };

            foreach (var auteur in linq13.Where(a => a.count == linq13.Max(a2 => a2.count)))
            {
                Console.WriteLine(auteur.key.Nom + " [" + auteur.count + "]");
            }

            afficherTitre(" -->>Afficher l'auteur ayant écrit le plus de livres");
            var linq14 = from Livre livre in listeLivres
                         group livre by livre.Auteur into livre_per_auteur
                         select new { key = livre_per_auteur.Key, count = livre_per_auteur.Count()};

            var linq15 = from o in linq14
                         let mx = linq14.Max( m => m.count)
                         where o.count == mx
                         select o;

            foreach (var auteur in linq15)
            {
                Console.WriteLine(auteur.key.Nom + " [" + auteur.count + "]");
            }

            afficherTitre("Afficher l'auteur ayant écrit le moins de livres");
            foreach (var auteur in linq13.Where(a => a.count == linq13.Min(a2 => a2.count)))
            {
                Console.WriteLine(auteur.key.Nom + " [" + auteur.count + "]");
            }
        }

        private static void afficherTitre(string titre)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#######{0}######", titre);
            Console.ResetColor();
        }

        private static void InitialiserDatas()
        {
            listeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            listeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            listeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            listeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            listeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            listeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", listeAuteurs.ElementAt(0), 533));
            listeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", listeAuteurs.ElementAt(0), 539));
            listeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", listeAuteurs.ElementAt(1), 311));
            listeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", listeAuteurs.ElementAt(3), 544));
            listeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", listeAuteurs.ElementAt(2), 452));
            listeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", listeAuteurs.ElementAt(0), 416));
            listeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", listeAuteurs.ElementAt(1), 216));
            listeAuteurs.ElementAt(0).addFacture(new Facture(3500, listeAuteurs.ElementAt(0)));
            listeAuteurs.ElementAt(0).addFacture(new Facture(3200, listeAuteurs.ElementAt(0)));
            listeAuteurs.ElementAt(1).addFacture(new Facture(4000, listeAuteurs.ElementAt(1)));
            listeAuteurs.ElementAt(2).addFacture(new Facture(4200, listeAuteurs.ElementAt(2)));
            listeAuteurs.ElementAt(3).addFacture(new Facture(3700, listeAuteurs.ElementAt(3)));
        }

    }
}
