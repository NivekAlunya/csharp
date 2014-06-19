using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Vehicles;
using Model;
namespace AppVehicles
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
            Vehicle vehicle;
            //Vehicule is an abstract class
            //vehicule = new Vehicule("diesel",150);
            //vehicule = new Vehicule();
            //by inheritance, vehicule gets public behaviours of its mother class
            //Console.WriteLine(vehicule.ToString());
            //vehicule.start();

            Plane plane = new Plane("kerosene",540,8000);
            plane.Speed = 540;
            plane.Fuel = "Kerosene";
            plane.start();
            plane.climb();
            plane.descend();
            plane.accelerate();
            plane.brake();

            Car car = new Car("diesel", 196, 120);
            car.start();
            car.drive();
            car.accelerate();
            car.brake();
            vehicle = car; //after that, only public members of the vehicle class can be accessed . we lose accessibility to car members
            vehicle.start(); //if start has redefinition in child classes so child method will be called too
            ((Car)vehicle).drive(); // restore the view of the object through a car
            //always test the type before value cast 'conversion)
            if (vehicle is Plane)
            {
                ((Plane)vehicle).climb();
                Plane p = (Plane)vehicle;
                p.climb();
                Plane p2 = vehicle as Plane;
                p2.climb();
            }

            Vehicle[] vehicles = new Vehicle[10];
            vehicles[0] = car;
            vehicles[1] = plane;

            Car[] cars = new Car[10];
            cars[0] = new Car("diesel", 196, 120);
            cars[0].Quotation = 150;
            cars[0].Quotation = 100;
            cars[0].isRising();
            cars[1] = new Car("diesel", 196, 90);
            cars[2] = new Car("diesel", 196, 20);
            cars[3] = new Car("super", 196, 250);
            cars[4] = new Car("nitro", 196, 1000);
            cars[5] = new Car("diesel", 196, 154);
            cars[6] = new Car("super", 196, 157);

            ICotable[] cotables = new ICotable[3];
            cotables[0] = new Artwork();
            cotables[0].Quotation = 150000;
            cotables[0].Quotation = 145000;

            cotables[1] = cars[0];
            

            int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 5, 4, 8, 6, 3, 9, 7 };
            Array.Sort(integers);
            foreach (int i in integers)
                Debug.WriteLine(i);

            Array.Sort(cars);

        }

    }
}
