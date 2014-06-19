using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WRC
{
    class Crew
    {
        #region properties
        public Person Driver { get; private set; }
        public Person CoDriver { get; private set; }

        #endregion
        public int Rank{ get; private set; }
        
        #region constructors
        public Crew(string drivername,string driverfirstname,string drivernation, string codrivername,string codriverfirstname, string codrivernation,int rank)
        {

            CoDriver = new Person(codrivername,codriverfirstname,codrivernation);
            Driver = new Person(drivername,driverfirstname,drivernation);
            Rank = rank;
        }
        #endregion
    
        #region methods
        public string crewToString()
        {
            return (new StringBuilder()).AppendLine(this.Driver.personToString()).AppendLine(this.CoDriver.personToString()).ToString();
        }
        #endregion

    }
}
