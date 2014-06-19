using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Products
{
    public class Memory : Product
    {
        #region attributes
        private int _volume;
        private string _type;
        private int _speed;
        #endregion
        #region properties
        public int Volume { get; set; }
        public override string Type { get; set; }
        public int Speed { get; set; }
        #endregion
        #region constructors
        public Memory()
            :base()
        {
        }
        public Memory(int r, decimal p, string n, int a, string t, int s,int v, double d = 1f, Manufacturer m = null)
            :base(r, p, n, a, d,m)
        {
            Speed = s;
            Type = t;
            Volume = v;
        }

        #endregion
        #region methods
        public override string ToString()
        {
            return (new StringBuilder()).Append(string.Format("{0}\t{1}\t{2}", this.Type,this.Speed, this.Volume)).Append("\t").Append(base.ToString()).ToString();
        }
        #endregion
    }
}
