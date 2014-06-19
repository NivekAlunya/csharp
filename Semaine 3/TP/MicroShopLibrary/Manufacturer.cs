using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Products
{
    public class Manufacturer : IComparable
    {
        #region attributes
        private string _name;
        private int _number;
        #endregion
        #region properties
        public string Name { get; set; }
        #endregion
        #region constructors
        public Manufacturer()
            :base()
        {
        }
        public Manufacturer(string n)
            :this()
        {
            Name = n;
        }
        public Manufacturer(string n, Object adresse)
            :this()
        {
            Name = n;
        }
        #endregion
        #region methods
        public override string ToString()
        {
            return (new StringBuilder()).Append(this.Name).ToString();
        }
        #endregion

        public int CompareTo(object obj)
        {
            if (null != obj)
            {
                return this.Name.CompareTo(((Manufacturer)obj).Name);
            }
            else
            {
                if (this == obj)
                    return 0;
                else if (null == obj)
                    return 1;
                else
                    return -1;
            }
        }
    }
}
