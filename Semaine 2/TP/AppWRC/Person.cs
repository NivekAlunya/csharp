using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WRC
{
    class Person
    {
        #region attributes
        #endregion
        #region properties
        public string Name { get; private set; }
        public string Firstname { get; private set; }
        public string Nation { get; private set; }
        #endregion
        #region constructors
        public  Person(string name, string firstname,string nation)
        {
            Name = name;
            Firstname = firstname;
            Nation = nation;
        }
        #endregion

        #region methods
        public string personToString()
        {
            return (new StringBuilder()).Append(this.Name).Append(" ").Append(this.Firstname).Append(" ").Append(this.Nation).ToString();
        }
        #endregion


    }
}
