using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;
using Shapes.Unit;//we link POOProjectLibrary in the references of the POOProject > access in solution explorer


namespace POOProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            run();
            Console.ReadKey();
        }

        static void run()
        {
            new Shapes.Unit.Circle();
            new Shapes.Circle();
            new Shapes.Unit.Point(0,0);
            new Shapes.Rectangle();
            Point pt = new Point(0,0);
            //now we can access to all public members of instance or class
            Point.symbol.ToString();
            pt.position = pt.Abscissa + "," + pt.Ordinate;
            pt.Ordinate = 10;
            pt.Abscissa = 20;
            IntPtr a;
            pt.test(out a);
            a = (IntPtr)8;

            Console.WriteLine(a);
            try
            {
                pt.Ordinate = -1;
            }
            catch (Exception e)
            {

                Console.Write(e.Message);
            }
            pt.Displayable = true;
            pt.draw();
            pt.move(10, 10);
            pt.draw();
            pt.move(1.5f);
            pt.draw();
            Console.WriteLine("\nCreated > " + Point.PointCounter);

        }
    }
}
