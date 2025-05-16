using DHA.DAL;
using DHA.DAL.CV.DAO;
using DHA.DAL.CV.Entity;
using DHA.DAL.CV.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.CV.DA
{
    public class CVDataAdapter
    {
        public static List<TrainingM> readTrainingM()
        {
            List<TrainingM> __lstTrainingM = new List<TrainingM>();
            foreach (Training __training in MyTraining.select_Training())
            {
                List<string> __lstStringDetail = new List<string>();
                foreach (TrainingDetail __TrainingDetail in __training.TrainingDetails)
                {
                    __lstStringDetail.Add(__TrainingDetail.Detail.ToString());
                }

                TrainingM __trainingM = new TrainingM();
                __trainingM.year = __training.Year;
                __trainingM.location = __training.Location.ToString();
                __trainingM.details = __lstStringDetail.ToArray();
                __lstTrainingM.Add( __trainingM);
            }//foreach 

            return __lstTrainingM;
        }//readTrainingM

        public static List<SkillStatM> readSkillStatM()
        {
            List<SkillStatM> __lstSkillStatM = new List<SkillStatM>();
            foreach (Tuple<string, TimeSpan, string> skillstat in MyStatistic.select_skill_by_duration())
            {
                SkillStatM __skillStatM = new SkillStatM();
                __skillStatM.skill = skillstat.Item1.Split("[##]")[0];
                __skillStatM.skilltype = skillstat.Item1.Split("[##]")[1];
                __skillStatM.skillduration = skillstat.Item2;
                __skillStatM.associatedexperience = skillstat.Item3.Split("##");                

                __lstSkillStatM.Add( __skillStatM);
            }

            return __lstSkillStatM;
        }//readSkillStat

        public static List<ExperienceM> readExperienceM()
        {
            List<ExperienceM> __lstExpM_Result = new List<ExperienceM>();
            foreach (Experience __experience in MyExperience.select_experiences_with_activities())
            {
                ExperienceM __experienceM = new ExperienceM();
                __experienceM.period = 
                    $"{__experience.ExperiencePeriod.YearStart} / {__experience.ExperiencePeriod.MonthStart.ToString("D2")}";
                __experienceM.duration =
                    $"{__experience.ExperiencePeriod.Get_Duree_String()}";
                __experienceM.desc =
                    __experience.Description;
                __experienceM.firmname = __experience.Firm.Name;
                __experienceM.firmkey = __experience.Firm.Key;
                __experienceM.firmsector = __experience.Firm.Sector;
                __experienceM.cityinfo = __experience.City.ToString();                

                List<ExperienceM_Activities> __lstExperienceM_Activities = new List<ExperienceM_Activities>();
                foreach (Activity __activite in __experience.Activities)
                {
                    ExperienceM_Activities __ExperienceM_Activities = new ExperienceM_Activities();
                    __ExperienceM_Activities.proj = __activite.ProjectName;
                    __ExperienceM_Activities.subproj = __activite.SubProjectName;

                    // Job
                    Job __jobDetail = MyJobs.select_job(__activite.JobId);
                    __ExperienceM_Activities.job = __jobDetail.ToString();
                    __ExperienceM_Activities.contract = __jobDetail.ContractType.Name;
                    __ExperienceM_Activities.keyrole = __jobDetail.JobKeyRolesToString();

                    // ExperienceM_Activities.tabStrDetail
                    List<string> __lstStrActivityDetail = new List<string>();
                    foreach (ActivityDetail __ActiviteDetail in __activite.ActivityDetails)
                    {                        
                        __lstStrActivityDetail.Add(__ActiviteDetail.Detail);
                    }//foreach
                    __ExperienceM_Activities.tabStrDetail = __lstStrActivityDetail.ToArray();
                    // ExperienceM_Activities.tabStrSkills 
                    List<string> __lstStrActivitySkill = new List<string>();
                    foreach (string __strSkillName in __activite.ActivitySkills.Select(a => a.Skill.Name).ToArray<string>())
                    {
                        __lstStrActivitySkill.Add(__strSkillName);
                    }//for
                    __ExperienceM_Activities.tabStrSkills = __lstStrActivitySkill.ToArray();

                    __lstExperienceM_Activities.Add(__ExperienceM_Activities);
                }//foreach
                __experienceM.tabActivities = __lstExperienceM_Activities.ToArray();

                __lstExpM_Result.Add(__experienceM);
            }//foreach
            return __lstExpM_Result;
        }//readExperienceM
    }//class
}//namespace
