using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WRC
{
    class Team
    {
        #region attributes
        private int nbCrew = 0;
        const int MAX_CREW = 10;
        #endregion

        #region properties
        public Crew[] Crews { get; private set; }
        public string  Name { get; private set; }
        public string Nation { get; private set; }
        public bool IsManufacturer { get; private set; }
        #endregion
        #region constructors
        public Team(string name, string nation, bool isManufacturer)
        {
            Name = name;
            Nation = nation;
            IsManufacturer = isManufacturer;
            Crews = new Crew[MAX_CREW];
        }
        #endregion
        #region methods
        public void addCrew(Crew crew)
        {
            if (MAX_CREW > nbCrew + 1) this.Crews[nbCrew++] = crew;
        }
        public string listCrews()
        {
            StringBuilder sb=new StringBuilder();
            foreach (Crew c in this.Crews)
            {
                if (null != c) sb.AppendLine(c.crewToString());
            }
            return sb.ToString();
        }
        #endregion
    }
}
