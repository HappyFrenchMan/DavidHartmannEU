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




            List<Tuple<string, TimeSpan, string>> __tupleResult = new List<Tuple<string, TimeSpan, string>>();


            List<CV_Skill> __lstSkill = MyDatabase.CVSkillRepository.GetAll().Include("Type").ToList();
            List<CV_ActivitySkill> __lstActivitySkill = MyDatabase.CVActivitySkillRepository.GetAll().ToList();
            List<CV_Activity> __lstActivity = MyDatabase.CVActivityRepository.GetAll().ToList();
            List<CV_Experience> __lstExperience = MyDatabase.CVExperienceRepository.GetAll().ToList();
            List<int> __listIdExperienceFound = new List<int>();

            foreach (CV_Skill __skill in __lstSkill)
            {
                __listIdExperienceFound.Clear();
                TimeSpan __tsDuration = new TimeSpan();
                StringBuilder stringBuilder = new StringBuilder();
                foreach (CV_ActivitySkill __activitySkill in __lstActivitySkill)
                {
                    if (__activitySkill.SkillId.Equals(__skill.ID))
                    {
                        foreach (CV_Activity __activity in __lstActivity)
                        {
                            if (__activity.Id.Equals(__activitySkill.ActivityId))
                            {
                                foreach (CV_Experience __experience in __lstExperience)
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

            List<SkillStatBM> __lstSkillStatM = new List<SkillStatBM>();
            foreach (Tuple<string, TimeSpan, string> skillstat in __tupleResult)
            {
                __lstSkillStatM.Add(SkillStatBM.ToSkillStatBM(skillstat));
            }//foreach

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
