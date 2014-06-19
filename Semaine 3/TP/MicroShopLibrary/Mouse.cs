using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Products
{
    public class Mouse : Product
    {
        #region attributes
        //private string _slot;
        //private string _type;
        #endregion
        #region properties
        public string Slot { get; set; }
        public override string Type { get; set; }
        #endregion
        #region constructors
        public Mouse()
            :base()
        {
        }
        public Mouse(int r, decimal p, string n, int a, string t,string s, double d = 1f, Manufacturer m = null)
            : base(r, p, n, a, d, m)
        {
            Type = t;
            Slot = s;
        }

        #endregion
        #region methods
        public override string ToString()
        {
            return (new StringBuilder()).Append(string.Format("{0}\t{1}",this.Type,this.Slot)).Append("\t").Append(base.ToString()).ToString();
        }
        #endregion

    }
}
