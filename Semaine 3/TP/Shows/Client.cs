using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shows
{
    public abstract class Client
    {
        #region attributes
        private string _mail;
        private string _nom;
        private string _prenom;
        private string _tel;
        #endregion
        #region properties
        public string Mail { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        #endregion
        #region constructors
        #endregion
        #region methods
        #endregion
        #region overrides
        public override string ToString()
        {
            return string.Format("{1} : {2} - @mail {0} ({3})", this.Mail, this.Nom, this.Prenom, this.Tel);
        }
        #endregion
    }
}
