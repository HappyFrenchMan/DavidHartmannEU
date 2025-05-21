using DHA.DAL.CV.DAO;
using DHA.DAL.CV.Model;
using DHA.DAL.Entity;

namespace DHA.BUSINESS.Model
{
    public partial class ExperienceBM
    {
        public static ExperienceBM ToExperienceBM(CV_Experience __experience)
        {
            ExperienceBM __experienceBM = new ExperienceBM();
            __experienceBM.period =
                $"{__experience.ExperiencePeriod.YearStart} / {__experience.ExperiencePeriod.MonthStart.ToString("D2")}";
            __experienceBM.duration =
                $"{__experience.ExperiencePeriod.Get_Duree_String()}";
            __experienceBM.desc =
                __experience.Description;
            __experienceBM.firmname = __experience.Firm.Name;
            __experienceBM.firmkey = __experience.Firm.Key;
            __experienceBM.firmsector = __experience.Firm.Sector;
            __experienceBM.cityinfo = __experience.City.ToString();

            List<ExperienceBM_Activities> __lstExperienceBM_Activities = new List<ExperienceBM_Activities>();
            foreach (CV_Activity __activite in __experience.Activities)
            {
                ExperienceBM_Activities __ExperienceBM_Activities = new ExperienceBM_Activities();
                __ExperienceBM_Activities.proj = __activite.ProjectName;
                __ExperienceBM_Activities.subproj = __activite.SubProjectName;

                // Job
                CV_Job __jobDetail = MyJobs.select_job(__activite.JobId);
                __ExperienceBM_Activities.job = __jobDetail.ToString();
                __ExperienceBM_Activities.contract = __jobDetail.ContractType.Name;
                __ExperienceBM_Activities.keyrole = __jobDetail.JobKeyRolesToString();

                // ExperienceM_Activities.tabStrDetail
                List<string> __lstStrActivityDetail = new List<string>();
                foreach (CV_ActivityDetail __ActiviteDetail in __activite.ActivityDetails)
                {
                    __lstStrActivityDetail.Add(__ActiviteDetail.Detail);
                }//foreach
                __ExperienceBM_Activities.tabStrDetail = __lstStrActivityDetail.ToArray();
                // ExperienceM_Activities.tabStrSkills 
                List<string> __lstStrActivitySkill = new List<string>();
                foreach (string __strSkillName in __activite.ActivitySkills.Select(a => a.Skill.Name).ToArray<string>())
                {
                    __lstStrActivitySkill.Add(__strSkillName);
                }//for
                __ExperienceBM_Activities.tabStrSkills = __lstStrActivitySkill.ToArray();

                __lstExperienceBM_Activities.Add(__ExperienceBM_Activities);
            }//foreach
            __experienceBM.tabActivities = __lstExperienceBM_Activities.ToArray();

            return __experienceBM;
        }//ToExperienceBM

    }//class
}//namespace
