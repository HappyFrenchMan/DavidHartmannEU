using DHA.BUSINESS.Interface;
using DHA.DAL.CV.DAO;
using DHA.BUSINESS.Model;
using DHA.DAL.Entity;
using DHA.DAL.CV.Model;
using DAH.DAL;
using System.Diagnostics;
using System.Text;

namespace DHA.BUSINESS.Service
{
    public class CVReadService : ADALService,ICVService
    {
        public List<TrainingBM> readTrainingM()
        {
            List<TrainingBM> __lstTrainingM = new List<TrainingBM>();
            foreach (CV_Training __CV_Training in MyDatabase.CVTrainingRepository.select_training_with_details_and_city())
            {               
                __lstTrainingM.Add(TrainingBM.ToTrainingBM(__CV_Training));
            }//foreach 

            return __lstTrainingM;
        }//readTrainingM

        public List<SkillStatBM> readSkillStatM()
        {
            List<SkillStatBM> __lstSkillStatM = new List<SkillStatBM>();
            foreach (Tuple<string, TimeSpan, string> skillstat in MyStatistic.select_skill_by_duration())
            {
                __lstSkillStatM.Add(SkillStatBM.ToSkillStatBM(skillstat));
            }//foreach


            public static List<Tuple<string, TimeSpan, string>> select_skill_by_duration()
        {
            List<Tuple<string, TimeSpan, string>> __tupleResult = new List<Tuple<string, TimeSpan, string>>();

            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                List<Skill> __lstSkill = lDHA_Db_Context.Skills.Include(a => a.Type).ToList();
                List<ActivitySkill> __lstActivitySkill = lDHA_Db_Context.ActivitySkills.ToList();
                List<Activity> __lstActivity = lDHA_Db_Context.Activities.ToList();
                List<Experience> __lstExperience = lDHA_Db_Context.Experiences.ToList();
                List<int> __listIdExperienceFound = new List<int>();

                foreach (Skill __skill in __lstSkill)
                {
                    __listIdExperienceFound.Clear();
                    TimeSpan __tsDuration = new TimeSpan();
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (ActivitySkill __activitySkill in __lstActivitySkill)
                    {
                        if (__activitySkill.SkillId.Equals(__skill.ID))
                        {
                            foreach (Activity __activity in __lstActivity)
                            {
                                if (__activity.ID.Equals(__activitySkill.ActivityId))
                                {
                                    foreach (Experience __experience in __lstExperience)
                                    {
                                        if (__experience.ID.Equals(__activity.ExperienceId)
                                            && !__listIdExperienceFound.Contains(__activity.ExperienceId))
                                        {
                                            __tsDuration += __experience.ExperiencePeriod.DureeExperience();

                                            if (stringBuilder.Length > 0)
                                            {
                                                stringBuilder.Append("##");
                                            }//if
                                            stringBuilder.Append(__experience.Name + "-" + __experience.Description);
                                            __listIdExperienceFound.Add(__experience.ID);
                                        }//if
                                    }//foreach
                                }//if
                            }//foreach                          
                        }//if
                    }//foreach
                    Tuple<string, TimeSpan, string> __TupleNew
                        = Tuple.Create($"{__skill.Name}[##][{__skill.Type.Description}]",
                        __tsDuration,
                        stringBuilder.ToString());

                    __tupleResult.Add(__TupleNew);
                }//foreach
            }//using

            return __tupleResult.OrderByDescending(a => a.Item2).ToList();
        }//select_experiences

            return __lstSkillStatM;
        }//readSkillStat

        public List<ExperienceBM> readExperienceM()
        {
            List<ExperienceBM> __lstExpM_Result = new List<ExperienceBM>();
            foreach (CV_Experience __experience in MyExperience.select_experiences_with_activities())
            {
                __lstExpM_Result.Add(ExperienceBM.ToExperienceBM(__experience));
            }//foreach
            return __lstExpM_Result;
        }//readExperienceM

    }//class
}//namespace
