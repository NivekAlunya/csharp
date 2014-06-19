using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    [Serializable]
    public abstract class Personne
    {
        #region "Attributs"
        private String _nom;
        private String _prenom;
        private int _cp;
        private String _ville;
        #endregion

        #region "Propriétés"
        /// <summary>
        /// Le nom de la Personne est :
        /// - obligatoire
        /// - en majuscules
        /// </summary>
        public String Nom
        {
            get {
                return _nom;
            }
            set {
                if (value != null && value.Trim().Length > 0)
                    _nom = value.ToUpper();
                else
                    throw new ApplicationException("Le nom ne doit pas être vide");
            }
        }

        /// <summary>
        /// Le prenom de la Personne est :
        /// - chaque première lettre est en majuscule
        /// </summary>
        public String Prenom
        {
            get {
                return _prenom;
            }
            set {
                if (value != null && value.Trim().Length > 0)
                    _prenom = firstInUpper(value.Trim(), '-');
            }
        }

        public String Adresse { get; set; }

        /// <summary>
        /// Le code postal de la Personne est :
        /// - compris entre 1000 et 99999
        /// </summary>
        public String CodePostal {
            get {
                return _cp.ToString("00000");
            }
            set {
                int cp = 0;
                bool ok = int.TryParse(value, out cp);
                //cp = int.Parse(value); //attention aux exceptions...
                //cp = Convert.ToInt32(value); //attention aux exceptions...
                if(!ok || (cp > 99999 || cp < 1000))
                    throw new ApplicationException("Le code postal est incorrect");
                else
                    _cp = cp;
            }
        }

        /// <summary>
        /// La ville de la Personne est :
        /// - obligatoire
        /// - chaque première lettre est en majuscule
        /// </summary>
        public String Ville
        {
            get {
                return _ville;
            }
            set {
                if (value != null && value.Trim().Length > 0)
                    _ville = firstInUpper(value, ' ');
                else
                    throw new ApplicationException("Le nom de la ville ne peut être vide");
            }
        }
        #endregion

        #region "Méthodes"
        public override string ToString()
        {
            return "->\t" + Nom + " " + Prenom + "\n\t" + Adresse + "\n\t"
               + CodePostal + " " + Ville.ToUpper();
        }

        //static : la méthode n'est définie qu'une seule fois en mémoire (dans la classe)
       //possible car la méthode ne fait pas directement référence à un objet client.
        /// <summary>
        /// Chaque première lettre des mots de la chaine est transformé en majuscule.
        /// Le séparateur de mot doit être précisé.
        /// </summary>
        /// <param name="chaine"></param>
        /// <param name="separateur"></param>
        /// <returns></returns>
        /// <remarks>static : la méthode n'est définie qu'une seule fois en mémoire (dans la classe)
        ///         possible car la méthode ne fait pas directement référence à un objet personne.
        /// </remarks>
        private static String firstInUpper(String chaine, char separateur) {
            //la première lettre est obligatoiremenet en majuscule
            chaine = char.ToUpper(chaine[0]) + chaine.Substring(1).ToLower();
            int pos = chaine.IndexOf(separateur);
            while(pos != -1) {
                if(++pos < chaine.Length)
                    chaine = chaine.Substring(0, pos)
                    + char.ToUpper(chaine[pos]) + chaine.Substring(pos + 1);
                pos = chaine.IndexOf(separateur, pos);
            }
            return chaine;
        }

        #endregion

        #region "Constructeur"
        /// <summary>
        /// Constructeur unique de la classe Personne
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="adresse"></param>
        /// <param name="cp"></param>
        /// <param name="ville"></param>
        public Personne(String nom, String prenom, String adresse, string cp, String ville) {
            //appel aux propriétés pour appliquer les règles aux données
            this.Nom = nom; // this = correspond à l'instance !
            this.Prenom = prenom;
            this.Adresse = adresse;
            this.CodePostal = cp;
            this.Ville = ville;
        }
        #endregion
    }
}
