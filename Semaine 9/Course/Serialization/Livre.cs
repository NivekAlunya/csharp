using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    [Serializable]
    public class Livre
    {
        #region "Attributs" 

        // attributs déclarés explicitement
        Auteur _auteur;
        private int _nbpages;
        private long _isbn;

        #endregion

        #region "Propriétés"
        // propriétés pour les attributs  ci-dessus
        /// <summary>
        /// L'auteur du livre est :
        /// - obligatoire
        /// </summary>
        public Auteur auteur
        {
            get { return _auteur; }
            set
            {
                if (value != null) _auteur = value;
                else throw new ApplicationException("le champ auteur doit contenir au moins un caractère");
            }
        }

        /// <summary>
        /// Le nombre de pages du Livre est :
        /// - strictement supérieur à zéro
        /// </summary>
        public int nbpages
        {
            get { return _nbpages; }
            set
            {
                if (value > 0) _nbpages = value;
                else throw new ApplicationException("nombre de pages positif !");
 
                }
        }

        /// <summary>
        /// La référence isbn du Livre est :
        /// - reçue au format String (13 caractères minimum)
        /// - ne contenir que des caractères numériques pour pouvoir être stocké au format long
        /// - livrée au format String "###-#-####-####-#"
        /// - stockée au format long
        /// </summary>
        public string isbn
        {
            get 
            {
                return _isbn.ToString("###-#-####-####-#");
               // 1234567891011 => 123-4-5678-9101-1
            }
            set 
            {
                if (value != null)
                {
                    //étape 1, replace : 123-4-5678-9101-1 => "1234567891011" 
                    string isbnWs = value.Replace("-", "");
                    
                    //étape 2 : parse : "1234567891011" => 1234567891011
                    long id = 0;
                    bool ok = long.TryParse(isbnWs, out id);
                    if (!ok || isbnWs.Length != 13)
                        throw new ApplicationException("Le code isbn n'est pas conforme !");
                    else
                        _isbn = id;
                }
                else
                {
                    throw new ApplicationException("Le code isbn est obligatoire !");
                }
            }
        }

        // titre : dans le set j'aurai _titre = value
        // dans le get j'aurai un simple return _titre
        // il y moyen d'alléger le code !
        // attribut IMPLICITE ! => sur la même ligne : déclaration de l'attribut et des accesseurs
        /// <summary>
        /// Le titre du Livre est :
        /// - totalement libre, associé à aucune règle particulière
        /// </summary>
        public string titre { get; set; }

        /// <summary>
        /// Le prix du Livre est :
        /// - calculé (pas déclaré dans la classe)
        /// </summary>
        public decimal prix
        {
            get {
                return ((nbpages * (decimal)0.05) + 10);
            }
        }
        #endregion

        #region "Constructeurs"
        /// <summary>
        /// Constructeur unique de la classe Livre
        /// </summary>
        /// <param name="pauteur"></param>
        /// <param name="ptitre"></param>
        /// <param name="pnbpages"></param>
        /// <param name="pisbn"></param>
        public Livre(Auteur pauteur, string ptitre, int pnbpages, string  pisbn)
        {
            //appel aux propriétés pour executer les reègles de gestion
            auteur = pauteur;
            titre = ptitre;
            nbpages = pnbpages;
            isbn = pisbn;
          
        }
 
        #endregion 

        #region "Méthodes"

        /// <summary>
        /// Retourne l'état d'un Livre sous la forme d'une chaine de caractères
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return titre + ", écrit par : " + auteur.Nom + ". \n\tPrix : " + prix + " euros. \n\tNuméro ISBN=" + isbn;
        }
        #endregion

    }
}
