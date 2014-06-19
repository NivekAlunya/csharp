using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppException
{
    class WTFException : Exception
    {
        protected DateTime  dtDisplayed { get; set; }
        public override string Message
        {
            get
            {
                dtDisplayed = DateTime.Now;
                return dtDisplayed.ToShortTimeString() + " > WTF!!! " + base.Message;
            }
        }
    }
}
