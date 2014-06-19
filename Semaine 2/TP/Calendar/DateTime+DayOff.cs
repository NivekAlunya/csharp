using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    static class DateTime_DayOff
    {
        public static DateTime dayOfEaster(this DateTime _date)
        {
            //Algo de Oudin
            int g = _date.Year % 19;
            int c = _date.Year / 100;
            int e = (8 * c + 13) / 25;
            int h = (19 * g + c - c / 4 - e + 15) % 30;
            int k = h / 28;
            int p = 29 / (h + 1);
            int q = (21 - g) / 11;
            int i = (k * p * q - 1) * k + h;
            int b = _date.Year / 4 + _date.Year;
            int j1 = b + i + 2 + c / 4 - c;
            int j2 = j1 % 7;
            int r = 28 + i - j2;
            
            return new DateTime(_date.Year, 3, 1).AddDays(r - 1);
        }

        public static DateTime dayOfAscension(this DateTime _date)
        {
            return _date.dayOfEaster().AddDays(36);
        }

        public static DateTime dayOfPentecost(this DateTime _date)
        {
            return _date.dayOfEaster().AddDays(49);
        }

        public static DateTime[] daysOff(this DateTime _date)
        {
            DateTime[] dts = new DateTime[11];
            dts[0] = new DateTime(_date.Year, 1, 1);
            dts[1] = _date.dayOfEaster().AddDays(1);
            dts[2] = new DateTime(_date.Year, 5, 1);
            dts[3] = new DateTime(_date.Year, 5, 8);
            dts[4] = _date.dayOfAscension();
            dts[5] = _date.dayOfPentecost();
            dts[6] = new DateTime(_date.Year, 7, 14);
            dts[7] = new DateTime(_date.Year, 8, 15);
            dts[8] = new DateTime(_date.Year, 11, 1);
            dts[9] = new DateTime(_date.Year, 11, 11);
            dts[10] = new DateTime(_date.Year, 12, 25);
            return dts;
        }

        public static bool isDayOff(this DateTime _date,DateTime[] daysOff)
        {
            for (int j = 0; j < daysOff.Length; ++j)
            {
                int compare = _date.CompareTo(daysOff[j]);
                if (0 >= compare) // if current dayoff is greater then current displaying date we go out the for with a break cause tab daysoff is sorted by asc
                {
                    if (0 == compare) return true;
                    break;
                }
            }

            return false;
        }

        public static bool isDayOff(this DateTime _date)
        {
            return _date.isDayOff(_date.daysOff());
        }

    }
}
