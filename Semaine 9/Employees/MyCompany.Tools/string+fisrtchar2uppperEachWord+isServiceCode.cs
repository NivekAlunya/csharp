using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MyCompany.Tools
{
    public static class StringExtention
    {
        public static string fisrtChar2uppperForEachWord(this string _string)
        {
            char[] c = _string.ToCharArray();
            for (int i = 0; i < c.Length; ++i)
                if (0 == i || !c[i - 1].isLetter())
                    c[i] = c[i].toUpper();
                else
                    c[i] = c[i].toLower();
            return new string(c);
        }

        public static bool isServiceCode(this string _string)
        {
            return new Regex(@"^[a-zA-Z0-9\-_]{5}$").IsMatch(_string);
        }

        public static string escapeXmlString(this string _string)
        {
            return _string.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("\'", "&apos;");
        }
    }
}
