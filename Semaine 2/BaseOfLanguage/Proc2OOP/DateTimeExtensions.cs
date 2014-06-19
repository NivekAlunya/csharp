using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{

    public static class DateTimeExtensions
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

    }
}