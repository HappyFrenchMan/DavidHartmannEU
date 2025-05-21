namespace DHA.BUSINESS.Model
{
    public partial class ExperienceBM
    {
        public string period { get; set; }
        public string duration { get; set; }
        public string desc { get; set; }
        public string firmkey { get; set; }
        public string firmname { get; set; }
        public string firmsector { get; set; }
        public string cityinfo { get; set; }

        public ExperienceBM_Activities[]  tabActivities  { get; set; }

    }//class

    public class ExperienceBM_Activities
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
