using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// define ICotable services
    /// </summary>
    public interface ICotable
    {
        /// <summary>
        /// store the quotation
        /// </summary>
        decimal Quotation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>true if object quotation is rising</returns>
        bool isRising();
    }
}
