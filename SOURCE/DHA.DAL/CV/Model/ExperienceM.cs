using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.CV.Model
{
    public class ExperienceM
    {
        public string period { get; set; }
        public string duration { get; set; }
        public string desc { get; set; }
        public string firmkey { get; set; }
        public string firmname { get; set; }
        public string firmsector { get; set; }
        public string cityinfo { get; set; }

        public ExperienceM_Activities[]  tabActivities  { get; set; }

    }//class

    public class ExperienceM_Activities
    {
        public string proj { get; set; }
        public string subproj { get; set; }
        public string job { get; set; }
        public string contract { get; set; }
        public string keyrole { get; set; }

        public string [] tabStrDetail { get; set; }
        public string [] tabStrSkills { get; set; }
    }//ExperienceM_Activities
}//namespace
