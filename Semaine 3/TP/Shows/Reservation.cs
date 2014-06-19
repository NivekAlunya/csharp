using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shows
{
    public class Reservation
    {
        #region attributes
        private DateTime _dateReservation;
        private int _nbPlaces;
        private Client _client;
        #endregion
        #region properties
        public DateTime DateReservation { get; set; }
        public int NbPlaces { get; set; }
        public Client Client { get; set; }
        #endregion
        #region constructors
        public Reservation(Client client, int nbplaces)
        {
            Client = client;
            NbPlaces = nbplaces;
        }
        #endregion
        #region methods
        #endregion
        #region overrides
        public override string ToString()
        {
            return string.Format("{0} - {2}p : {1}",this.DateReservation,this.Client,this.NbPlaces);
        }
        #endregion
    }
}
