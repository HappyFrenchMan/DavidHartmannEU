using DHA.UTIL;

namespace DHA.BUSINESS.Model
{
    public partial class SkillStatBM
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
