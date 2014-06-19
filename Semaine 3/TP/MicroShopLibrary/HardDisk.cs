using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Products
{
    public class HardDisk : Product
    {
        #region attributes
        private int _volume;
        private string _type;
        #endregion
        #region properties
        public int Volume { get; set; }
        public override string Type { get; set; }
        #endregion
        #region constructors
        public HardDisk()
            :base()
        {
        }
        public HardDisk(int r, decimal p, string n, int a, string t, int v, double d = 1f, Manufacturer m = null)
            :base(r, p, n, a, d,m)
        {
            Type = t;
            Volume = v;
        }

        #endregion
        #region methods
        public override string ToString()
        {
            return (new StringBuilder()).Append(string.Format("{0}\t{1}", this.Type, this.Volume)).Append("\t").Append(base.ToString()).ToString();
        }
        #endregion

    }
}
