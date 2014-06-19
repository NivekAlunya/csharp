using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Ville : ITest
    {
        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }


        private string _dept;
        public string Dept
        {
            get { return _dept; }
            set { _dept = value; }
        }

        public override string ToString()
        {
            return string.Format("Ville : {0} - {1}", this.Nom, this.Dept);
        }
    }
}
