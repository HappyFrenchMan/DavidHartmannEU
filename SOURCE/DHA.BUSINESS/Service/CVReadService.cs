using DHA.BUSINESS.Interface;
using DHA.BUSINESS.Model;
using DHA.DAL.Entity;
using DAH.DAL;
using System.Diagnostics;
using System.Text;
using DHA.DAL.Repository.Generic;

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
            foreach (Tuple<string, TimeSpan, string> skillstat in
                MyDatabase.CVStatCR.select_skill_by_duration())
            {
                __lstSkillStatM.Add(SkillStatBM.ToSkillStatBM(skillstat));
            }//foreach

            return __lstSkillStatM;
        }//readSkillStat

        public List<ExperienceBM> readExperienceM()
        {
            List<CV_Job> __listJob = MyDatabase.CVJobRepository.GetAll(new FindOptions() { IsAsNoTracking = true }).ToList();

            List<ExperienceBM> __lstExpM_Result = new List<ExperienceBM>();
            foreach (CV_Experience __experience in MyDatabase.CVExperienceRepository.select_experiences_with_activities())
            {
                __lstExpM_Result.Add(ExperienceBM.ToExperienceBM(__experience, __listJob));
            }//foreach
            return __lstExpM_Result;
        }//readExperienceM

    }//class
}//namespace
