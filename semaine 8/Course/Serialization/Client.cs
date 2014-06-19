using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
   /// <summary>
   /// Modele de conception du Client
   /// </summary>
    public class Client : Personne
    {

        #region "Propriétés"
        public DateTime DepuisLe {get; set;}
        public float CoeffFidelite {get; set;}
        #endregion

        #region "Méthodes"
        /// <summary>
        /// Retourne l'état d'un Client sous la forme d'une chaine de caractères
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "\n" + DepuisLe.ToString("dd/MM/yyyy") + " " + CoeffFidelite;
        }
        #endregion

        #region "Constructeur"
        /// <summary>
        /// Constructeur unique de la classe Client
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="adresse"></param>
        /// <param name="cp"></param>
        /// <param name="ville"></param>
        public Client(String nom, String prenom, String adresse, string cp, String ville, DateTime depuisLe, float fidelite) 
            :base(nom,prenom,adresse,cp,ville)
        {
            this.CoeffFidelite = fidelite;
            this.DepuisLe = depuisLe;
        }
        #endregion
    }
}
