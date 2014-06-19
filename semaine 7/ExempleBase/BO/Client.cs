using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Client
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mdp { get; set; }
        public string Commentaire { get; set; }
        public Client(string nom, string prenom, string Mdp)
        {
            this.Nom = nom; this.Prenom = prenom; this.Mdp = Mdp;
        }
    }
}
