using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Model;

namespace Vehicles
{
    public class Car : Vehicle,ICotable,IComparable,IComparable<Car>//implements ICOtable Interface : this class now should define all methods of this interface
    {
        #region attributes
        decimal _quotation;
        bool _isRising;
        #endregion
        #region properties
        public int Power { get; set; }
        #endregion

        #region constructors
        public Car(string fuel, int speed, int power)
            : base(fuel, speed)
        {
            Power = power;
        }
        #endregion
        #region methods
        public override void brake()
        {
            Debug.WriteLine(this.ToString() + " is braking...");
        }

        public override void accelerate()
        {
            Debug.WriteLine(this.ToString() + " is speeding up ...");
        }

        public void drive()
        {
            Debug.WriteLine(this.ToString() + " is driving ...");
        
        }
        #endregion

        #region interface ICotable
        public decimal Quotation
        {
            get
            {
                return this._quotation;
            }
            set
            {
                _isRising = value > this._quotation ? true : false;
                this._quotation = value;
            }
        }

        public bool isRising()
        {

            return this._isRising;
        }
        #endregion

        #region interface IComparable
        public int CompareTo(object obj)
        {
            return !(obj is Car) || (obj as Car).Power > this.Power ? -1 : (obj as Car).Power < this.Power ? 1 : 0;
        }

        #endregion
        #region interface generic IComparable<> 

        public int CompareTo(Car other)
        {
            return CompareTo((Object)other);
        }
        #endregion
        #region overrides
        public override bool Equals(object obj)
        {
            bool r = false;
            if (r = base.Equals(obj)) return r;
            if (!(obj is Car)) return false;
            if (this.Power == ((Car)obj).Power) return true;
            
            return false;
        }
        #endregion

    }
}
