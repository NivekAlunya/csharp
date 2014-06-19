using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProjectForm
{
    class PeopleController
    {
        private BindingList<People> _peoples;
        public BindingList<People> Peoples { get { return _peoples; } }
        public PeopleController()
            :base()
        {
            _peoples = new BindingList<People>();
            _peoples.ListChanged += (object sender, ListChangedEventArgs e) =>
            {
                
            };
        }

        public People addPeople(string surname, string firstname, string password, string comment)
        {
            People p = new People(surname, firstname, password, comment);
            _peoples.Add(p);
            return p;
        }

        public void updatePeople(People p,string surname, string firstname, string password, string comment)
        {
            p.Firstname = firstname;
            p.Surname = surname;
            p.Password = password;
            p.Comment = comment;
        }
    }
}
