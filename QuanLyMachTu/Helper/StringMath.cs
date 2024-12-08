using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;

namespace QuanLyMachTu.Helper
{
    public static class StringMath
    {
        public static string Increment(string org)
        {
            int lastIndex = org.Length - 1;

            while (lastIndex >= 0 && char.IsDigit(org[lastIndex]))
            {
                lastIndex--;
            }

            int startIndex = lastIndex + 1;
            string stringPart = org.Substring(0, startIndex);
            string numericPart = org.Substring(startIndex);
            int digit;

            if (int.TryParse(numericPart, out digit))
            {
                digit++;
                return stringPart + digit.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
