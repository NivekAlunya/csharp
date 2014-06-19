using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Vehicles
{
    /// <summary>
    /// implicit inheritance with Object class
    /// keyword sealed : prevents (forbids) inheritance from this class
    /// keyword abstract : can t instanciate this class, only non abstract child class were instanciable
    /// </summary>
    public abstract class Vehicle
    {
        #region properties
        public string Fuel {get;set;}
        public int Speed { get; set; }
        //protected visibilty: only access in this class or her childs
        protected string State { get; set;}
        #endregion
        #region constructors
        /// <summary>
        /// explicit call to constructor of inehrited class : Object
        /// </summary>
        /// <param name="fuel"></param>
        /// <param name="speed"></param>
        public Vehicle(string fuel, int speed)
            :base()
        {
            Fuel = fuel;
            Speed = speed;
            Debug.WriteLine("Vehicule parts constructed...");
        }
        #endregion

        #region methods
        /// <summary>
        /// virtual : child class can redefine this  methods
        /// </summary>
        public virtual void start()
        {
            this.State = "Started";
            Debug.WriteLine(this.ToString() + " starts");
        }
        
        /// <summary>
        /// abstract methods : make mandatory the redefinition of these methods in the child class
        /// </summary>
        public abstract void brake();
        public abstract void accelerate();

        public override string ToString()
        {
            return base.ToString() + "(" + this.Fuel + "," + this.Speed + ")";
        }
        #endregion
    }
}
