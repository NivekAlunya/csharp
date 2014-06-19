using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * Project type of Library : output assembly of type DLL
 * Define project namespace  : Shapes
 * Refine namespace in Shapes.Unit
 */

namespace Shapes.Unit
{
    public class Point
    {
        /**
         * Define members 
         */
        //attributes of the instance
        //for each instance (object)
        private int abscissa;
        private int ordinate;
        public string position;
        //readonly attribute of an instance only can be initialize in constructor methods or in declaration
        private readonly ConsoleColor color = ConsoleColor.White;
        
        //attributes of the class
        public const char symbol = '*'; //implicite static access 
        private static int pointCounter;//initialize at first object creation 

        //properties of the class
        public static int PointCounter {
            get 
            { 
                //static member only deal with static members
                return pointCounter;
            }
        }

        //constructors
        //take care of if a constructor is defined then the default constructor is not availlable anymore.
        private Point()
            :base() //explicit call to the default constructor
        {
            color = ConsoleColor.Blue;
            pointCounter++; //instance method can interact with class members (attr,props,methods)
        }

        public Point(int abscissa, int ordinate)
            :this() // call this constructor
        {
            this.abscissa = abscissa;
            this.ordinate = ordinate;
        }

        public Point(int abscissa, int ordinate, bool displayable)
            : this(abscissa,ordinate) // call this constructor
        {
            this.Displayable = displayable;
        }

        //properties of the intance
        public int Ordinate { 
            get { return ordinate; } 
            set {
                //some validations before assignment
                if (0 > value) 
                    throw new Exception("Positive value expected for ordinate "); 
                ordinate = value; 
            }
        }
        //ReadWrite properties
        public int Abscissa { get { return abscissa; } set { abscissa = value; } }
        public string Position { get { return Abscissa+ "," + Ordinate; } }
        //Readonly properties
        public ConsoleColor Color { get { return color; } }
        //define quick property
        public bool Displayable { get; set; }

        //properties of the class

        //behaviours of the instance

        public void draw()
        {
            Console.SetCursorPosition(Abscissa, Ordinate);
            if (Displayable) Console.Write(".");
        }

        public void move(int abscissa, int ordinate)
        {
            this.Abscissa = abscissa;
            this.Ordinate = ordinate;
        }
        //method overloads
        public void move(float coef)
        {
            this.Abscissa = (int)(this.Abscissa * coef);
            this.Ordinate = (int)(this.Ordinate * coef);
        }

        //behaviours of the class

        public void test(out IntPtr a)
        {
            a = (IntPtr)abscissa;
        }

        //destructor
        ~Point()
        {

        }

    }
}
