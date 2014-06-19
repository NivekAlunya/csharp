using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Client
    {
        public Client()
        {
        }
        public Client(string nom, string prenom):this()
        {
            this.Nom = nom;
            this.Prenom = prenom;
        }

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }


        private string _prenom;
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public override string ToString()
        {
            return string.Format("Client : {0} - {1}", this.Nom, this.Prenom);
        }
    }
}
