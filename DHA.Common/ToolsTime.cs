using System.IO;
using System.Text;
using System;

namespace DHA.Common
{
    public static class ToolsTime
    {
               
        public static string ToYearsMonthsAndDays(this TimeSpan span)
        {
            var result = string.Empty;
            var totalYears = span.Days / 364.25;
            var fullYears = Math.Floor(totalYears);

            var totalMonths = (span.Days - (365.24 * fullYears)) / 30;
            var fullMonths = Math.Floor(totalMonths);

            var sb = new StringBuilder();
            if (fullYears > 0)
            {
                if (sb.Length > 0)
                    sb.Append(", ");
                sb.Append(fullYears + " Années");
            }
            if (fullMonths > 0)
            {
                if (sb.Length > 0)
                    sb.Append(", ");
                sb.Append(fullMonths + " Mois");
            }
           
            return sb.ToString();
        }//ToYearsMonthsAndDays


    }//class
}//namespace
