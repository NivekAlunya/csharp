using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shows
{
    public class Representation
    {
        #region attributes
        private DateTime _date;
        private int _placesDispo;
        private double _tarif;
        private List<Reservation> _reservations;
        #endregion
        #region properties
        public DateTime Date { get; set; }
        public int PlacesDispo { get; set; }
        public double Tarif { get; set; }
        public List<Reservation> Reservations { get; set; }
        #endregion
        #region constructors
        public Representation()
            :base()
        {
            Reservations = new List<Reservation>();
        }
        #endregion
        #region methods
        public void ajouterReservation(Client client,int nbplaces)
        {
            this.Reservations.Add(new Reservation(client,nbplaces));
        }
        public void annulerReservation(Client client)
        {
            this.Reservations.Remove(this.rechercherReservation(client));
        }
        public Reservation rechercherReservation(Client client)
        {
            foreach (Reservation r in this.Reservations)
            {
                if (r.Client == client) return r;
            }
            return null;
        }

        #endregion
        #region overrides
        #endregion


    }
}
