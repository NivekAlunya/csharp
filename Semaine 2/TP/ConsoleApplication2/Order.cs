using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class Order
    {
        public enum OrderState { 
            inprogress,
            sent,
            received
        }
        
        #region attributes
        private DateTime dt;
        private Client client;
        private Book[] books;
        private const int TAILLE = 10;
        #endregion

        #region properties
        public Client Client {
            get
            {
                return client;
            }
            private set
            {
                if (null == value) throw new Exception("[Order][Property][Client] Can't assign null value to property Client");
                client = value;
            }
        }
        public DateTime Date { get; set; }
        public OrderState State { get; set; }
        public Book[] Books {
            get
            {
                return books;
            }
            private set {
                if (null == value) throw new Exception("[Order][Property][Books] Can't assign null value to property Client");
                int i=0;
                books = new Book[TAILLE];
                foreach (Book b in value)
                {
                    if (null == b) 
                        throw new Exception("[Order][Property][Books] Can't contain null value in this array");
                    books[i++] = b;
                }
            }
        }
        public decimal  Sum { get; set; }
        #endregion
        
        #region constructors
        public Order(Client c, Book[] bs)
            :this(c,bs,DateTime.Now)
        {

        }
        public Order(Client c, Book[] bs, DateTime dt)
            :base()
        {
            Date = dt;
            Client = c;
            Books = bs;
        }
        #endregion
        
        #region methods
        public void addBook(Book book)
        { 
            for(int i =0;i<this.Books.Length;++i)
            {
                if (null != this.Books[i]) continue;
                this.Books[i] = book;
                break;
            }
        }
        #endregion
    }

}
