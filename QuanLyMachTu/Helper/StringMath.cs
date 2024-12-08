using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;

namespace QuanLyMachTu.Helper
{
    public static class StringMath
    {
        public static string GetLastContinuousDigits(string org)
        {
            int i = org.Length - 1;
            string result = "";           

            while (i > -1 && Char.IsDigit(org[i]) == true)
            {                
                result = org[i] + result;
                i--;                
            }

            return result;
        }        
        public static string? Increment(string org)
        {
            string digits = GetLastContinuousDigits(org);            
            string alpha = org.Substring(0, org.Length - digits.Length);            
            long number;
            bool isDigit = long.TryParse(digits, out number);

            if(isDigit == true)
            {
                number++;
                digits = number.ToString($"D{digits.Length}");                
                return alpha + digits;
            }
            else
            {
                return null;
            }
        }
    }
}
