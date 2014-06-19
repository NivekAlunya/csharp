using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace BO
{
    public class Commande : ISerializable,IDeserializationCallback
    {
        #region "Attributs"
        private DateTime _dateCde;
        

        private Client _client; 
        
        [NonSerialized]
        private List<Livre> _livresCommandes;
        private Livre[] _livres;

        #endregion

        #region "Propriétés"
        public DateTime DateCde
        {
            get { return _dateCde; }
            set { _dateCde = value; }
        }

        public Client Client
        {
            get { return _client; }
            set
            {
                if (value != null)
                    _client = value;
                else
                    throw new ApplicationException("Une référence client doit être associée à cette commande !");
            }
        }

        public List<Livre> LivresCommandes
        {
            get { return _livresCommandes; }
        }

        public EtatCmde Etat { get; set; }

        /// <summary>
        /// propriété calculée
        /// </summary>
        public decimal Montant
        {
            get
            {
                decimal montant = 0;
                foreach (Livre livre in this.LivresCommandes)
                {
                    montant += livre.prix;
                }
                return montant;
            }
        }
        #endregion

        #region "Constructeurs"
        //association affinée (vers Client (1) et vers Livre (1..n))
        public Commande(Client client, Livre livre)
        {
            //la commande stocke la référence du client qui lui est assigné
            this.Client = client;
            //quelques initialisations envisagées pour une nouvelle commande
            this.Etat = EtatCmde.enPreparation;
            this.DateCde = DateTime.Today;

            //construire la collection des livres commandés
            _livresCommandes = new List<Livre>();

            //ajouter le premier livre à la commande
            ajoutLivre(livre);

        }

        public Commande(Client client, Livre livre, DateTime dateCde)
            :this(client,livre)
        {
            
            this.DateCde = dateCde;
        }
        #endregion

        #region "Méthodes"
        /// <summary>
        /// détailler l'etat de la commande
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            String message = "";
            switch (this.Etat)
            {
                case EtatCmde.enPreparation:
                    message = "est en cours de préparation";
                    break;
                case EtatCmde.envoyee:
                    message = "a été envoyée";
                    break;
                case EtatCmde.recue:
                    message = "a été reçue";
                    break;
            }
            message = "La commande de \n" + this.Client.ToString() +
                    ",\npassée le " + this.DateCde.ToString("D") + ", \n" +
                    message + "\nLivres commandés :\n";

            foreach (Livre livre in this.LivresCommandes)
            {
                message += "@ " + livre.ToString() + '\n';
            }

            message += "Montant de votre commande : " + this.Montant.ToString("C");

            return message;
        }

        /// <summary>
        /// ajouter un livre à la commande
        /// </summary>
        /// <param name="livre"></param>
        public void ajoutLivre(Livre livre)
        {
            if (livre != null)
            {
                this.LivresCommandes.Add(livre);
            }
            else
            {
                throw new ApplicationException("Une référence livre est obligatoire !");
            }
        }
        #endregion

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (null != _livresCommandes)
            {
                _livres = _livresCommandes.ToArray();
            }
            else
                _livres = null;
        }

        public void OnDeserialization(object sender)
        {
            ((Commande)sender)._livresCommandes = new List<Livre>(((Commande)sender)._livres);

        }
    }

    public enum EtatCmde
    {
        enPreparation,
        envoyee,
        recue
    }
   
}
