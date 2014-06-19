using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class Client
    {
        /**
         * CLASS MEMBERS 
         **/
        
        private static string eachWord2Upper(string s,char separator=' ')
        {
            int i = 0;
            char[] res = new char[s.Length];
            bool ucase = true;
            foreach (char c in s)
            {
                if (ucase)
                    res[i++] = char.ToUpper(c);
                else
                    res[i++] = c;
            
                if (separator == c)
                    ucase = true;
                else
                    ucase = false;
            }

            return new string(res);
        }

        /**
         * INSTANCE MEMBERS
         **/
        private string name =null, firstname=null, city = null;
        private int pc;
        public string PC
        {
            get{
                return pc.ToString();
            }
            set{
                int outvalue =0;
                if(!int.TryParse(value,out outvalue))
                    throw new Exception("[Error on assignment property][PC][" + value + "] Can t assign value : only accept numerical characters in this string");
                
                if (1000 > outvalue || 99999 < outvalue) throw new Exception("[Error on assignment property][PC][" + value + "] Can t assign value greater than 99999 or lower than 1000 to PC property");
                        pc = outvalue;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.Empty == value) throw new Exception("[Error on assignment property][Name][" + value + "] Can t assign Empty String to Name property");
                if (null != value)
                    name = value.ToUpper();
                else
                    name = value;
            }
        }
        
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                if (string.Empty == value) throw new Exception("[Error on assignment property][Firstname][" + value + "] Can t assign Empty String to Firstname property");
                if (null != value)
                    firstname = eachWord2Upper(value);
                else
                    firstname = value;
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (null == value) throw new Exception("[Error on assignment property][City][" + value + "] Can t assign null value to City property");
                if (string.Empty != value)
                {
                    char[] t = value.ToCharArray();
                    t[0] = char.ToUpper(t[0]);
                    this.city = new string(t);
                }
                else
                    city = value;
            }
        }
        
        public string Adresss {get;set;}
    
        public Client(string name,string firstname, string adress, string postalcode, string city)
            :base()
        {
            try
            {
                Adresss = adress;
                Name = name;
                Firstname = firstname;
                PC = postalcode;
                City = city;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string clientToString()
        {
            return (new StringBuilder()).AppendLine(this.Name).AppendLine(this.Firstname).AppendLine(this.Adresss).AppendLine(this.PC).AppendLine(this.City).ToString();
        }
    }
}
