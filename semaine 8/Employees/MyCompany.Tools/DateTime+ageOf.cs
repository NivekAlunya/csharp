using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Tools
{
    public static class DateTimeExtention
    {
        /// <summary>
        /// compute the age in year of this datetime object to a date
        /// </summary>
        /// <param name="_dt">object DateTime to work with</param>
        /// <param name="dtEnd">ending date</param>
        /// <returns>integer represents the age in years</returns>
        public static int ageOf(this DateTime _dt,DateTime dtEnd)
        {
            if(dtEnd>_dt)
                return dtEnd.Year - _dt.Year - (dtEnd.DayOfYear - (DateTime.IsLeapYear(dtEnd.Year) & dtEnd.DayOfYear > 59 ? 1 : 0) > _dt.DayOfYear - (DateTime.IsLeapYear(_dt.Year) & _dt.DayOfYear > 59 ? 1 : 0) ? 0 : 1);
            else
                return dtEnd.Year - _dt.Year + (dtEnd.DayOfYear - (DateTime.IsLeapYear(dtEnd.Year) & dtEnd.DayOfYear <= 59 ? 1 : 0) <= _dt.DayOfYear - (DateTime.IsLeapYear(_dt.Year) & _dt.DayOfYear <= 59 ? 1 : 0) ? 0 : 1);
        }
    }
}
