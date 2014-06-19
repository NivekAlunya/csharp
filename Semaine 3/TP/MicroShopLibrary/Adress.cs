using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Products
{
    public class Adress
    {
        #region attributes
        private string _country;
        private string _street;
        private string _city;
        #endregion
        #region properties
        public string Country { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        #endregion
        #region constructors
        public Adress()
            :base()
        {
        }
        public Adress(string country, string street, string city)
            :this()
        {
            Country = country;
            City = city;
            Street = street;
        }
        #endregion
        #region methods
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
