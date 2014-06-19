using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor;
namespace EditorApp
{
    class Program2
    {
        static void Main(string[] args)
        {
            run();
            Console.ReadKey();
        }
        static void run()
        {
            testBook();
        }
        static void testBook()
        {
            Book[] books=new Book[2];
            Book book;
            book = new Book("titre 1", "auteur 1", "1111111111111", 1);
            books[0] = book;
            books[1] = new Book("titre 2", "auteur 2", "2222222222222", 2);

            displayBooks(books);
            Order order = new Order(
                new Client("Launay", "Kevin", "7 rue du clos d'hel", "44810", "LA CHEVALLERAIS")
                ,books
            );
            Console.WriteLine(order.Client.clientToString());
            displayBooks(order.Books);

        }
        static void displayBooks(Book[] books)
        {
            foreach (Book b in books)
            {
                if (null == b) continue;

                Console.WriteLine(b.bookToString());
            }

        }
    }
}
