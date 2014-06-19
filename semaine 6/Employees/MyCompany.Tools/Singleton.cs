using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Tools
{
    public interface ISingleton<T> where T:new()
    {
        T Instance { get; }        
        T getInstance();
    }

    public class Singleton
    {
        #region atrributes
        private static Singleton _singleton = null;
        #endregion
        #region constructors
        private Singleton()
        {

        }
        #endregion
        #region methods
        public static Singleton getInstance()
        {
            return null == _singleton ? _singleton = new Singleton() : _singleton;
        }
        #endregion
    }
}
