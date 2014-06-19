using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Products
{
    public class Processor : Product
    {
        #region attributes
        private int _frequency;
        private string _type;
        #endregion
        #region properties
        public int Frequency { get; set; }
        public override string Type { get; set; }
        #endregion
        #region constructors
        public Processor()
            :base()
        {
        }
        public Processor(int r, decimal p, string n, int a,string t,int f, double d = 1f, Manufacturer m = null)
            :base(r, p, n, a, d,m)
        {
            Type = t;
            Frequency = f;
        }

        #endregion
        #region methods
        public override string ToString()
        {
            return (new StringBuilder()).Append(string.Format("{0}\t{1}", this.Type, this.Frequency)).Append("\t").Append(base.ToString()).ToString();
        }
        #endregion
    }
}
