using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace BO
{
    [Serializable]
    [XmlRoot("BonDeCommande")]
    public class Commande //: IXmlSerializable
    {
        #region "Attributs"
        private DateTime _dateCde;
        

        private Client _client;
        [NonSerialized]
        private List<Livre> _livresCommandes;

        #endregion

        #region "Propriétés"
        [XmlIgnore]
        public DateTime DateCde
        {
            get { return _dateCde; }
            set { _dateCde = value; }
        }
        [XmlAttribute("DateCde")]
        public String DateCdeFormatted
        {
            get { return this.DateCde.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture); }
            set { DateCde = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture); }
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

        [XmlArray("Livres")]
        [XmlArrayItem("Livre")]
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
            :this()
        {
            //la commande stocke la référence du client qui lui est assigné
            this.Client = client;
            //quelques initialisations envisagées pour une nouvelle commande
            this.Etat = EtatCmde.enPreparation;
            this.DateCde = DateTime.Today;

            //construire la collection des livres commandés
            //_livresCommandes = new List<Livre>();

            //ajouter le premier livre à la commande
            ajoutLivre(livre);

        }

        public Commande(Client client, Livre livre, DateTime dateCde)
            :this(client,livre)
        {
            
            this.DateCde = dateCde;
        }

        /// <summary>
        /// Constructeur necessaire pour sérialisation XML
        /// </summary>
        public Commande()
        {
            _livresCommandes = new List<Livre>();
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
            message += "Montant de votre commande (Serialisé) : " + this._mtGeneral.ToString("C");

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

        #region "personnaliser la sérialisation Binaire et SOAP"
        private decimal _mtGeneral;
        /// <summary>
        /// préférer sérialiser le tableau
        /// </summary>
        private Livre[] _livresCommandesTab;
        [OnSerializing]
        private void SetValuesOnSerializing(StreamingContext context)
        {
            this._mtGeneral = this.Montant;
            if (_livresCommandes != null)
                _livresCommandesTab = _livresCommandes.ToArray();
        }
        [OnDeserialized]
        private void SetValuesOnDeSerialized(StreamingContext context)
        {
            if (_livresCommandesTab != null)
                _livresCommandes = _livresCommandesTab.ToList();
        }

        #endregion

        /*
         * Implémentation de l'interface IXmlSerializable
         * 
         */
        //public System.Xml.Schema.XmlSchema GetSchema()
        //{
        //    return null;
        //}

        //public void ReadXml(System.Xml.XmlReader reader)
        //{
        //    throw new NotImplementedException();
        //}

        //public void WriteXml(System.Xml.XmlWriter writer)
        //{
        //    writer.WriteComment("Personnalisation de notre flux XML");
        //    writer.WriteStartElement("objects");
        //    writer.WriteStartElement("object");
        //    writer.WriteStartAttribute("type");
        //    writer.WriteString(this.GetType().Namespace+"."+this.GetType().Name);
        //    writer.WriteEndAttribute();
        //    foreach (PropertyInfo oProperty in this.GetType().GetProperties())
        //    {
        //        writer.WriteStartElement("property");
        //        writer.WriteStartAttribute("name");
        //        writer.WriteString(oProperty.Name);
        //        writer.WriteEndAttribute();
        //        writer.WriteStartAttribute("value");
        //        writer.WriteString(oProperty.GetValue(this).ToString());
        //        writer.WriteEndAttribute();
        //        writer.WriteEndElement();
                
        //    }
        //    writer.WriteEndElement();
        //    writer.WriteEndElement();

        //    //writer.WriteStartElement("Client");
        //    //XmlSerializer xs = new XmlSerializer(typeof(Client));
        //    //xs.Serialize(writer,this.Client);
        //    //writer.WriteEndElement();
        //    //writer.WriteStartElement("Montant");
        //    //writer.WriteString(Convert.ToString(this.Montant));
        //    //writer.WriteEndElement();

        //}
    }

    public enum EtatCmde
    {
        [XmlEnum("Commande en preparation")]
        enPreparation,
        [XmlEnum("Commande envoyée")]
        envoyee,
        [XmlEnum("Commande reçue")]
        recue
    }
   
}
