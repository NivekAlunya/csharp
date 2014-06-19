using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProjectForm
{
    public class People:INotifyPropertyChanged
    {
        private string _surname;
        private string _firstname;
        private string _password;
        private string _comment;
        public string Surname { get { return _surname; } set { _surname = value; _propertyUpdated("Surname"); } }
        public string Firstname { get { return _firstname; } set { _firstname = value; _propertyUpdated("Firstname"); } }
        public string Password { get { return _password; } set { _password = value; _propertyUpdated("Password"); } }
        public string Comment { get { return _comment; } set { _comment = value; _propertyUpdated("Comment"); } }

        public People(string surname, string firstname, string password, string comment)
        {
            Surname = surname;
            Firstname = firstname;
            Password = password;
            Comment = comment;
        }

        public override string ToString()
        {
            return this.Surname + " " + this.Firstname;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void _propertyUpdated(string propertyName)
        {
            if(null != this.PropertyChanged) this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
