using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class ExtendedList<T> : List<T> where T:IComparable
    {
        public bool Add(T v)
        {
            foreach (T o in this)
            {
                if (v.Equals(o)) return false;
            }
            base.Add(v);
            this.Sort();
            
            return true;
        }
        public ExtendedList(List<T> l)
        {
            foreach(T o in l)
            {
                Add(o);
            }
        }

    }
}
