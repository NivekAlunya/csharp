using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Vehicles
{
    /// <summary>
    /// Explicit inheritance with parent class : Vehicule
    /// </summary>
    public class Plane : Vehicle
    {
        #region properties
        public int Ceiling { get; set; }
        #endregion
        #region constructors
        public Plane(string fuel, int speed, int ceiling)
            :base(fuel,speed)
        {
            Ceiling = ceiling;
            State = "Ready";
            Debug.WriteLine("Plane parts constructed...");
        }
        #endregion
        #region methods
        public void climb()
        {
            this.State = "climbing";
            Debug.WriteLine(this.ToString() + " is climbing...");
        }
        public void descend()
        {
            this.State = "descending";
            Debug.WriteLine(this.ToString() + " is descending ...");
        }
        /// <summary>
        /// method take place of the parent's method
        /// </summary>
        public override void start()
        { 
            //replacing parent behaviour
            Debug.WriteLine("Plane starts ...");
            
            //completing parent behaviour
            base.start(); // call parent method with base keyword
            Debug.WriteLine("Plane starts ...");
            

        }
        /// <summary>
        /// redefine abstract methods of the parent class
        /// </summary>
        public override void brake()
        {
            Debug.WriteLine(this.ToString() + " is braking ...");
        }

        public override void accelerate()
        {
            Debug.WriteLine(this.ToString() + " is speeding up ...");
        }
        #endregion


    }
}
