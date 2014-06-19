using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestion_Fichiers
{
    class Manip_Fichier
    {  private struct personne{
        int num ;
         public String nom; 
        public DateTime date_naiss; 
        }
   
        

   static void Main(string[] args)
        {
     Char    rep , action;

        do{
            Console.Clear();
            Console.WriteLine("gestion d'un fichier direct");
            Console.WriteLine("1-ecrire, 2-lire");
            action = char.Parse(Console.ReadLine());
          switch (action){
              case '1' :
                    ecrire();
                  break;
              case '2' :
                    lire();
                     break;
               }
          Console.WriteLine("continuer à gérer le fichier (O/N) : ");
            rep =char.Parse( System.Console.ReadLine());
        } while (rep == 'O' | rep == 'o');

    
        }

   private static void ecrire()
   {
      Char   rep;

        do
        { Console.Clear();

            Console.WriteLine("continuer à écrire (O/N) : ");
            rep =char.Parse( Console.ReadLine());}
        while (rep == 'O' | rep == 'o');
    }

   static void lire()
   {
       Char  rep,action;
      

        do{
            Console.Clear();
            Console.WriteLine("1-lire un enregistrement particulire, 2-tout lire");
            action = char.Parse(Console.ReadLine());
            switch (action){
                case '1':
                    lireOnerecord();
                    break;
            case '2':
                    lireAllRecords();
                    break;
                }
        
            Console.WriteLine("continuer à lire (O/N) : ");
            rep = char.Parse(Console.ReadLine());}
        while (rep == 'O' | rep == 'o');
    }

   static void lireOnerecord(){
       //TODO : lire un enregistrement
    }

   static void lireAllRecords()
   {
       //TODO : lire tout le fichier
    }



   
    }
}
