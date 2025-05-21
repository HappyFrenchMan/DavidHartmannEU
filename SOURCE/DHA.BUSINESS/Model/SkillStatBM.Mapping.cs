using DHA.DAL.CV.Model;

namespace DHA.BUSINESS.Model
{
    public partial class SkillStatBM
    {
        public static SkillStatBM ToSkillStatBM(Tuple<string, TimeSpan, string> skillstat)
        {
            SkillStatBM __skillStatBM = new SkillStatBM();
            __skillStatBM.skill = skillstat.Item1.Split("[##]")[0];
            __skillStatBM.skilltype = skillstat.Item1.Split("[##]")[1];
            __skillStatBM.skillduration = skillstat.Item2;
            __skillStatBM.associatedexperience = skillstat.Item3.Split("##");
            return __skillStatBM;
        }//ToSkillStatBM
    }//class
}//namespace
