using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesMachina
{
    class MachinaStateControler
    {
        public List<String> Strings { get; set; }
        public MachinaStateControler()
        {
            Strings = new List<string>();
            this.addString("chaine 1");
            this.addString("chaine 2");
            this.addString("chaine 3");
        }
        public string addString(string s)
        {
            Strings.Add(s);
            return s;
        }

        public string updateStringAt(int index, string s)
        {
            //this.Strings.RemoveAt(index) = s;
            return s;
        }

        public void deleteStringAt(int index)
        {
            this.Strings.RemoveAt(index);
        }


    }
}
