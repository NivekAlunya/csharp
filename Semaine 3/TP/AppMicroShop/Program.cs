using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroShop.Products;
namespace AppMicroShop
{
    class Program
    {
        /**
         * Trier par le nom du fabricant asc
         *  Puis par type asc
         *      Puis par ref desc
         **/
        static void Main(string[] args)
        {
            run();
            Console.ReadKey();
        }

        static void run()
        {
            int cpt = 0;
            Product[]  catalog = new Product[100];
            catalog[cpt++] = new Mouse(cpt, 10m, "Mouse 1", 50,"3 BUTTONS","USB", .9, new Manufacturer("Manufacturer 1", new Adress("France", "Street 1", "NANTES")));
            catalog[cpt++] = new Memory(cpt, 68m, "RAM 1", 5,"DRR2",2000,16000, .9, new Manufacturer("Manufacturer 2", new Adress("France", "Street 1", "NANTES")));
            catalog[cpt++] = new Processor(cpt, 300m, "PROC 1", 150,"AMD",2500, .95, new Manufacturer("Manufacturer 1", new Adress("France", "Street 1", "NANTES")));
            catalog[cpt++] = new HardDisk(cpt, 100m, "HD 1", 50,"HD",4000, .7, new Manufacturer("Manufacturer 4"));
            catalog[cpt++] = new Mouse(cpt, 15m, "Mouse 2", 500, "1 BUTTONS", "USB", .98, new Manufacturer("Manufacturer 5", new Adress("France", "Street 1", "NANTES")));
            catalog[cpt++] = new Mouse(cpt, 20m, "Mouse 3", 200, "2 BUTTONS", "USB", .9);
            catalog[cpt++] = new Mouse(cpt, 20m, "Mouse 3", 580, "12 BUTTONS", "PS-2", .9);
            catalog[cpt++] = new HardDisk(cpt, 100m, "HD 2", 80, "SSD", 128);
            catalog[cpt++] = new Processor(cpt, 300m, "PROC 2", 1, "AMD", 2500);
            catalog[cpt++] = new Processor(cpt, 300m, "PROC 3", 5, "INTEL", 4500);
            catalog[cpt++] = new Processor(cpt, 300m, "PROC 4", 50, "QUALCOM", 500, m: new Manufacturer("Manufacturer 3", new Adress("France", "Street 1", "NANTES")));
            Array.Sort(catalog);
            
            Console.WriteLine("\n## CATALOG ##");
            displayCatalog(catalog);

            Console.WriteLine("\n## CATALOG USING GENERIC ##");
            displayCatalog<Product>(catalog);
            Console.WriteLine("\n## Mouses ##");
            displayCatalog<Mouse>(catalog);
            Console.WriteLine("\n## Processors ##");
            displayCatalog<Processor>(catalog);
            Console.WriteLine("\n## Hard Disk ##");
            displayCatalog<HardDisk>(catalog);
            Console.WriteLine("\n## Memory ##");
            displayCatalog<Memory>(catalog);
        }

        static void displayCatalog(Product[] catalog)
        { 
            foreach(Product p in catalog)
            {
                if(null != p)Console.WriteLine(p.ToString());
            }
        }

        static void displayCatalog<T>(Product[] catalog) where T : Product
        {
            foreach (Product p in catalog)
            {
                if (null != p && p is T) Console.WriteLine(((T)p).ToString());
            }
        }

    }
}
