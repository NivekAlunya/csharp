using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shows
{
    public class ClientAbonne : Client
    {
        #region attributes
        private int _anneeAbonnement;
        private double _solde;
        #endregion
        #region properties
        public int AnneeAbonnement { get; set; }
        public double Solde { get; set; }
        #endregion
        #region constructors
        #endregion
        #region methods
        public void crediterCompte(double montant)
        {
            Solde += montant;
        }
        public void debiterCompte(double montant)
        {
            Solde -= montant;
        }
        #endregion
        #region overrides
        #endregion
    }
}
