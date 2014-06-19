using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.WRC;
namespace AppWRC
{
    class Program
    {
        static void Main(string[] args)
        {
            run();
            Console.ReadKey();

        }

        static void run()
        {
            /*
             * définition d'un Rallye
             */
            Rallye rallyOfCorse = new Rallye("Corse FR", new DateTime(2012, 05, 10));
            /*
             * associer les spéciales
             */
            Stage ss;
            ss = new Stage("ES1 (Pénitencier Coti – Agosta plage)", 25.89m, 10, new DateTime(2012, 05, 10, 14, 13, 00), Stage.StageType.qualifying);

            rallyOfCorse.addStage(ss);
            ss = new Stage("ES2 (Sarrola – Plage de Liamone)", 26.70m, 10, new DateTime(2012, 05, 10, 16, 19, 00), Stage.StageType.qualifying);
            rallyOfCorse.addStage(ss);
            ss = new Stage("ES3 (Le Fangu – ND de la Serra)", 27.53m, 11, new DateTime(2012, 05, 11, 8, 27, 00), Stage.StageType.special);
            rallyOfCorse.addStage(ss);
            Console.WriteLine(rallyOfCorse.informations());
            Console.WriteLine(rallyOfCorse.listStages());

            /*
             * définir les équipes
             */
            Team teamCitroen = new Team("Citroen", "FR", true); ;
            teamCitroen.addCrew(new Crew("LOEB", "Sebastien", "FR", "ELENA", "Daniel", "FR", 1));
            teamCitroen.addCrew(new Crew("HIRVONEN", "Mikko", "FL", "LEHTINEN", "Jarma", "FL", 2));
            Team teamFord = new Team("Ford", "USA", true);
            teamFord.addCrew(new Crew("PILOTE", "Pilote", "USA", "COPILOTE", "Copilote", "USA", 3));

            Console.WriteLine(teamCitroen.listCrews());
            Console.WriteLine(teamFord.listCrews());
            
            /*
             * saisir les résultats par spéciale
             */
            foreach (Stage s in rallyOfCorse.Stages)
            {
                if (null != s)
                {
                    resultsForTeam(s, teamCitroen.Crews);
                    resultsForTeam(s, teamFord.Crews);
                }
                
            }
        }

        static void resultsForTeam(Stage s,Crew[] crews)
        {
            Random r = new Random(0);
            int bound = 3600 * 1000;
            int boundPenalty = 300;
            foreach (Crew c in crews)
                if(null != c) s.addStageTime(new StageTime(c, (new DateTime()).AddMilliseconds(r.Next(bound)), (new DateTime()).AddSeconds(r.Next(boundPenalty))));
                
        }
    }
}
