namespace DHA.BUSINESS.Model
{
    public partial class SkillStatBM
    {
        public static SkillStatBM ToSkillStatBM((string name_desc, TimeSpan duration, string experience) skillstat)
        {
            SkillStatBM __skillStatBM = new SkillStatBM();
            __skillStatBM.skill = skillstat.name_desc.Split("[##]")[0];
            __skillStatBM.skilltype = skillstat.name_desc.Split("[##]")[1];
            __skillStatBM.skillduration = skillstat.duration;
            __skillStatBM.associatedexperience = skillstat.experience.Split("##");
            return __skillStatBM;
        }//ToSkillStatBM
    }//class
}//namespace
