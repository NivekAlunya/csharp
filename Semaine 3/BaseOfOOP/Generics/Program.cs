using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;
namespace Generics
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
            //playWithClassGeneric();
            //playWithList();
            playWithExtendedList();
        }
        static void playWithClassGeneric()
        {
            ClassGeneric<Car> cg = new ClassGeneric<Car>();
            cg.Generic = new Car("diesel",150,200);
            cg.Generic.drive();
            cg.fn();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        static void playWithExtendedList()
        {
            List<int> ints = new List<int>() { 1, 3, 2, 4, 5 };
            ExtendedList<int> extendedints = new ExtendedList<int>(ints);
            List<Car> cars = new List<Car>() { new Car("diesel", 280, 500)
                , new Car("diesel", 20, 50)
                , new Car("super", 200, 100)
                , new Car("diesel", 2, 5)
                , new Car("electric", 300, 750)
                , new Car("GPL", 100, 50)
            };
            ExtendedList<Car> extendedcars = new ExtendedList<Car>(cars);

        }


        static void playWithList()
        {
            List<int> ints = new List<int>() { 1,2,3,4,5};
            Car markedCar,tmpCar;
            List<Car> cars = new List<Car>() { new Car("diesel", 280, 500)
                , new Car("diesel", 20, 50)
                , (markedCar = new Car("super", 200, 100))
                , new Car("diesel", 2, 5)
                , new Car("electric", 300, 750)
                , new Car("GPL", 100, 50)
            };
            ints.Sort();
            cars.Sort();

            if (search<Car>(cars, tmpCar = new Car("diesel", 280, 500)))
                Console.WriteLine(tmpCar + " 200 found...");
            else
                Console.WriteLine(tmpCar + " 404 not  found...");

            if (search<Car>(cars, markedCar))
                Console.WriteLine(markedCar + " 200 found...");
            else
                Console.WriteLine(markedCar + " 404 not  found...");

            if (search<int>(ints, 3))
                Console.WriteLine(3 + " 200 found...");
            else
                Console.WriteLine(3 + " 404 not  found...");

            if (search<int>(ints, 15))
                Console.WriteLine(15 + " 200 found...");
            else
                Console.WriteLine(15 + " 404 not  found...");


        }

        static bool search<T>(List<T> l, T searched)
        { 

            return l.IndexOf(searched) < 0 ? false : true;
        }

        static bool search(List<int> l, int searched)
        {
            return l.IndexOf(searched) < 0 ? false : true;

        }
    }
}
