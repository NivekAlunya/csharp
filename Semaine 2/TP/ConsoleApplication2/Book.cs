using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class Book
    {
        private string auteur;
        private long isbn;
        private int nbpages;

        public int NbPages { 
            get{
                return nbpages;
            }
            set{
                if (0 >= value) throw new Exception("[Error on assignment property][NbPages][" + value + "] Number of pages for a book must be greater than 0");

                nbpages = value;
            } 
        }

        public string ISBN {
            get{
                return long2Isbn(this.isbn);
            }
            set{
                try
                {
                    isbn = isbn2Long(value);
                }
                catch
                {

                    throw new Exception("[Error on assignment property][ISBN][" + isbn + "] Wrong string format provided expected ###-#-####-####-# where # is numeric [0-9]");
                }
            } 
        }
        public string Auteur {
            get{
                return auteur;
            }
            set{
                auteur = value;
            } 
        }
        public string Title{ get; set; }
        public decimal Price { 
            get {
                return (decimal)(NbPages * .5f) + (decimal)10;
            }
        } 

        private static long isbn2Long(string isbn)
        {
            //validate separators
            Exception e = new Exception("[ISBN][" + isbn + "] Wrong string format provided expected ###-#-####-####-# where # is numeric [0-9]");
            //not enough characters in this string to build the right long value 
            if (13 > isbn.Length) throw e;

            long outlong = 0L;
            long i = 1000000000000L;
            foreach (char c in isbn)
            {
                if (!char.IsNumber(c) && '-' != c) throw e;
                if (char.IsNumber(c)) 
                {
                    outlong += ((int)c-48) *i;
                    //each time we pass here, we divide by 10 the multiplicator
                    i=i/10;
                }
            }
            //not enough numeric characters for isbn building 
            if (i > 1) throw e; 
            return outlong;
        }

        private static string long2Isbn(long isbn)
        {
            string work = (isbn + 10000000000000).ToString();// this will make 0 padding right
            return work.Substring(1, 3)
                + "-" + work.Substring(4, 1)
                + "-" + work.Substring(5, 4)
                + "-" + work.Substring(9, 4)
                + "-" + work.Substring(13, 1)
            ;
        }


        public Book(string title,string auteur, string isbn, int nbpages)
            :base()
        {
            try
            {
                this.ISBN = isbn;
            }
            catch (Exception e)
            {

                throw e;
            }
            this.Title = title;
            this.Auteur = auteur;
            this.NbPages = nbpages;
        }

        public string bookToString()
        {
            return ((new StringBuilder())
                    .AppendLine(this.Title)
                    .AppendLine(this.Auteur)
                    .AppendLine(this.ISBN)
                    .AppendLine(this.NbPages.ToString())
                    .AppendLine(this.Price.ToString())
                    ).ToString();
        }

    }
}
