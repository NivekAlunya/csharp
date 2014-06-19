using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BLL
{
    public class MgtPrincipal
    {
        private List<Client> _lalisteClient;

        public List<Client> getClients
        {
            get
            {
                return _lalisteClient;
            }
        }
        public MgtPrincipal()
        {
            _lalisteClient = new List<Client>();
            chargerClient();
        }
        private void chargerClient()
        {
            
            _lalisteClient.Add(new Client("Dupond", "Jean", "DUP"));
            _lalisteClient.Add(new Client("Martin", "Paul", "MAR"));
            _lalisteClient.Add(new Client("ROBERT", "Robb", "DUP"));
        }
    }
}
