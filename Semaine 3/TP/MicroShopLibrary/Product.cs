using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Products
{
    public abstract class Product : IComparable
    {
        #region attributes
        //private string _name;
        //private decimal _price;
        //private int _amount;
        //private double _discount;
        //private int _reference;
        #endregion

        #region properties
        public string Name { get; set; }
        public Manufacturer Manufacturer {get; set;}
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public double Discount { get; set; }
        public int Reference { get; set; }
        public abstract string Type { get; set; }
        #endregion

        #region constructors
        public Product()
            :base()
        {
        
        }
        public Product(int r, decimal p, string n, int a, double d = 1.0f , Manufacturer m = null)
            :this()
        {
            Reference = r;
            Price = p;
            Name = n;
            Amount = a;
            Discount = d;
            Manufacturer = m;
        }
        #endregion

        #region methods
        public override string ToString()
        {
            return (new StringBuilder()).Append(this.Manufacturer).Append("\t").Append(this.Reference).Append("\t").Append(this.Name).Append("\t").Append(this.Price).Append("\t").Append(this.Amount).Append("\t")
                .Append(this.Discount).Append("\t").ToString();
        }
        #endregion


        #region methods
        public int CompareTo(object obj)
        {
            if (!(obj is Product))
                return -1;
            Product o = (Product)obj;
            int r;
            if (null != this.Manufacturer && null != o.Manufacturer)
            {
                r = this.Manufacturer.CompareTo(o.Manufacturer);
            }
            else
            {
                if (o.Manufacturer == this.Manufacturer) 
                    r = 0;
                else if (null == o.Manufacturer) 
                    r = 1;
                else 
                    r = -1;
            }
            
            if (0 != r) return r;
            
            r = this.Type.CompareTo(o.Type);
            if (0 != r) return r;
            return o.Reference > this.Reference ? -1 : o.Reference < this.Reference ?  1 : 0;
        }
        #endregion
        
    }
}
