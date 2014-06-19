using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using modele.WRC;

namespace AppliWRC
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * définition d'un Rallye
             */
            Rallye rallyeCorse = new Rallye("Corse FR", new DateTime(2012, 05, 10));
            /*
             * associer les spéciales
             */
            Speciale es;
            es = new Speciale("ES1 (Pénitencier Coti – Agosta plage)", 25.89m, 10, new DateTime(2012,05,10,14,13,00), Type_Epreuve.Qualification);
            rallyeCorse.ajouterSpeciale(es);
            es = new Speciale("ES2 (Sarrola – Plage de Liamone)", 26.70m, 10, new DateTime(2012, 05, 10, 16, 19, 00), Type_Epreuve.Qualification);
            rallyeCorse.ajouterSpeciale(es);
            es = new Speciale("ES3 (Le Fangu – ND de la Serra)", 27.53m, 11, new DateTime(2012, 05, 11, 8, 27, 00), Type_Epreuve.Speciale);
            rallyeCorse.ajouterSpeciale(es);
            Console.WriteLine(rallyeCorse.infosRallye());
            Console.WriteLine(rallyeCorse.listerSpeciales());

            /*
             * définir les équipes
             */
            Equipe eqCitroen = new Equipe("Citroen", "FR", true);; 
            eqCitroen.ajouterEquipage(new Equipage("LOEB", "Sebastien", "FR", "ELENA", "Daniel", "FR", 1));
            eqCitroen.ajouterEquipage(new Equipage("HIRVONEN", "Mikko", "FL", "LEHTINEN", "Jarma", "FL", 2));
            Equipe eqFord = new Equipe("Ford", "USA", true);
            eqFord.ajouterEquipage(new Equipage("PILOTE", "Pilote", "USA", "COPILOTE", "Copilote", "USA", 3));

            Console.WriteLine(eqCitroen.listerEquipages());
            Console.WriteLine(eqFord.listerEquipages());
            Console.ReadKey();

            /*
             * saisir les résultats par spéciale
             */
        }
    }
}
