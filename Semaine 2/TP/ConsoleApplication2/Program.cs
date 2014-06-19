using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor;
using System.Diagnostics;

namespace EditorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            run();
            Console.ReadKey();
        }
        static void run()
        {
            testBook();
            testClient();
        }
        /// <summary>
        /// 
        /// </summary>
        static void testBook()
        {
            Book book = null;
            try
            {
                Console.WriteLine((book = new Editor.Book("my book", "my author", "1-234-5678-9012-3", 20)).bookToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message, "EditorApp");
            }
            book = null;
            try
            {
                Console.WriteLine((book = new Editor.Book("my book", "my author", "A-234-5678-9012-3", 200)).bookToString());
            }
            catch (Exception e)
            {
                if (null == book) Debug.WriteLine("object book is null", "EditorApp");
                Debug.WriteLine(e.Message, "EditorApp");
            }

            try
            {
                Console.WriteLine((new Editor.Book("my book", "my author", "1-234-567", 60)).bookToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message,"EditorApp");
            }

            try
            {
                Console.WriteLine((new Editor.Book("my book", "my author", "0000000000000123456", 40)).bookToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message,"EditorApp");
            }
        }

        static void testClient()
        {
            
            try
            {
                Console.WriteLine((new Editor.Client("launay", "jean kévin", "7 rue du clos d'hel", "44810", "la chevallerais")).clientToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message,"EditorApp");
            }
            try
            {
                Console.WriteLine((new Editor.Client("", "kévin", "7 rue du clos d'hel", "44810", "la chevallerais")).clientToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message,"EditorApp");
            }
            try
            {
                Console.WriteLine((new Editor.Client(null, "kévin", "7 rue du clos d'hel", "44810", "la chevallerais")).clientToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message,"EditorApp");
            }

            try
            {
                Console.WriteLine((new Editor.Client("launay","", "7 rue du clos d'hel", "44810", "la chevallerais")).clientToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message, "EditorApp");
            }
            try
            {
                Console.WriteLine((new Editor.Client("launay",null, "7 rue du clos d'hel", "44810", "la chevallerais")).clientToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message, "EditorApp");
            }

            try
            {
                Console.WriteLine((new Editor.Client("launay", "kévin", "7 rue du clos d'hel", "44810", "")).clientToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message,"EditorApp");
            }
            try
            {
                Console.WriteLine((new Editor.Client("launay", "kévin", "7 rue du clos d'hel","44810", null)).clientToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message,"EditorApp");
            }
            try
            {
                Console.WriteLine((new Editor.Client("launay", "kévin", "7 rue du clos d'hel", "481", "la chevallerais")).clientToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message,"EditorApp");
            }
            try
            {
                Console.WriteLine((new Editor.Client("launay", "kévin", "7 rue du clos d'hel", "448100", "la chevallerais")).clientToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message, "EditorApp");
            }
            try
            {
                Console.WriteLine((new Editor.Client("launay", "kévin", "7 rue du clos d'hel", "xxxxx", "la chevallerais")).clientToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message, "EditorApp");
            }
            try
            {
                Console.WriteLine((new Editor.Client("launay", "kévin", "7 rue du clos d'hel", null, "la chevallerais")).clientToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message, "EditorApp");
            }

        }
    }
}
