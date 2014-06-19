using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shows
{
    class ClientNonAbonne:Client
    {
        #region attributes
        private int _cvc;
        private DateTime _dateValide;
        private string _numCB;
        #endregion
        #region properties
        public int Cvc { get; set; }
        public DateTime DateValide { get; set; }
        public string NumCB { get; set; }
        #endregion
        #region constructors
        #endregion
        #region methods
        public void realiserTransaction(double montant)
        { 

        }
        #endregion
        #region overrides
        #endregion

    }
}
