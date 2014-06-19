using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Artwork : ICotable
    {
        #region attributes
        decimal _quotation;
        bool _isRising;
        #endregion

        #region interface ICotable
        public decimal Quotation
        {
            get
            {
                return this._quotation;
            }
            set
            {
                _isRising = value > this._quotation ? true : false;
                this._quotation = value;
            }
        }

        public bool isRising()
        {

            return this._isRising;
        }
        #endregion
    }
}
