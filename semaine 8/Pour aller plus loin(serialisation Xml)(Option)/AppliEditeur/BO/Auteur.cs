using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    [Serializable]
    public class Auteur : Personne
    {
        public String Popularite { get; set; }

        #region "Constructeur"
        /// <summary>
        /// Constructeur unique de la classe Auteur
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="adresse"></param>
        /// <param name="cp"></param>
        /// <param name="ville"></param>
        public Auteur(String nom, String prenom, String adresse, string cp, String ville, String popularite) 
            :base(nom,prenom,adresse,cp,ville)
        {
            this.Popularite = popularite;
        }

        /// <summary>
        /// Constructeur necessaire pour sérialisation XML
        /// </summary>
        public Auteur()
        {
        }
        #endregion

        public override string ToString()
        {
            return base.ToString() + "\n" + Popularite;
        }
    }
}
