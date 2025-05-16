using DHA.UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.CV.Model
{
    public class SkillStatM
    {
        public string skill { get; set; }
        public string skilltype { get; set; }
        public TimeSpan skillduration { get; set; }
        public string skilldurationToString
        { 
            get
            {
                return ToolsTime.ToYearsMonthsAndDays(skillduration);
            }
        }   
        public string[] associatedexperience { get; set; }
    }//class
}//namespace
