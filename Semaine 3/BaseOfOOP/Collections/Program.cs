using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Vehicles;
namespace Collections
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
            playWithArrayList();
            playWithHashTable();
        }

        static void playWithHashTable()
        {
            Hashtable ht2 = new Hashtable(){
                {"key1", "value1"},
                {"key2", "value2"}
            };
            Hashtable ht = new Hashtable();
            ht.Add("obj1", new Car("diesel",150,120));
            ht["toto"]= "toto";

            ht.Remove("toto");
            foreach (Object obj in ht.Keys)
                Console.WriteLine(ht[obj]);
        }
        static void playWithArrayList()
        {
            ArrayList lst = new ArrayList() {1,2,3};
            Debug.WriteLine("capacity {0}", lst.Capacity);
            Debug.WriteLine("count {0}", lst.Count);
            int a = 0;
            lst.Add(a = 15);
            lst.Add(null);
            lst.Add(new Car("diesel", 150, 200));
            lst.Add(10.25f);
            Debug.WriteLine("capacity {0}", lst.Capacity);
            Debug.WriteLine("count {0}", lst.Count);
            lst.Insert(2, "insert");
            lst.Add(15);
            Debug.WriteLine("capacity {0}", lst.Capacity);
            Debug.WriteLine("count {0}", lst.Count);
            lst.RemoveAt(1);
            lst.Add(a);
            lst.Remove(a);
            lst.Remove(15);
            Debug.WriteLine("capacity {0}", lst.Capacity);
            Debug.WriteLine("count {0}", lst.Count);
            Console.WriteLine(lst.IndexOf(15));

            foreach (Object obj in lst)
                Console.WriteLine(obj);

        }
    }
}
