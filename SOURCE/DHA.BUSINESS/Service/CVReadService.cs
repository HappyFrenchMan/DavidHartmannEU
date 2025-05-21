using DHA.BUSINESS.Interface;
using DHA.DAL.CV.DAO;
using DHA.BUSINESS.Model;
using DHA.DAL.Entity;
using DHA.DAL.CV.Model;

namespace DHA.BUSINESS.Service
{
    public class CVReadService : ADALService,ICVService
    {
        public List<TrainingBM> readTrainingM()
        {
            List<TrainingBM> __lstTrainingM = new List<TrainingBM>();
            foreach (CV_Training __CV_Training in MyTraining.select_Training())
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
