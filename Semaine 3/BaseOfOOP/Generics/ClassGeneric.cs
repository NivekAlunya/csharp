using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;
namespace Generics
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ClassGeneric<T>
    {
        #region
        private T _generic;
        #endregion
        #region properties
        public T Generic { get { return _generic; } set { _generic = value; } }
        #endregion
        #region methods
        public void fn()
        { 
        
        }
        #endregion

    }

    public class ClassGeneric2<T> where T: struct
    {
        #region
        private T _generic;
        #endregion
        #region properties
        public T Generic { get { return _generic; } set { _generic = value; } }
        #endregion
        #region methods
        public void fn()
        {

        }
        #endregion

    }

    public class ClassGeneric3<T> where T : Vehicle
    {
        #region
        private T _generic;
        #endregion
        #region properties
        public T Generic { get { return _generic; } set { _generic = value; } }
        #endregion
        #region methods
        public void fn()
        {

        }
        #endregion

    }

    public class ClassGeneric4<T>: ClassGeneric3<T> where T : Car
    {
        #region
        private T _generic;
        #endregion
        #region properties
        public T Generic { get { return _generic; } set { _generic = value; } }
        #endregion
        #region methods
        public void fn2()
        {
            fn();
        }
        #endregion

    }


}
