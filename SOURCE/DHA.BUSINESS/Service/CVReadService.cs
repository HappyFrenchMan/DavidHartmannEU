using DHA.BUSINESS.Interface;
using DHA.BUSINESS.Model;
using DHA.DAL.Entity;
using DAH.DAL;
using System.Diagnostics;
using System.Text;
using DHA.DAL.QueryResult;
using DHA.BUSINESS.Result;

namespace DHA.BUSINESS.Service
{
    public class CVReadService : ADALService,ICVReadService
    {
        public List<TrainingBM> readTrainingM(out BusinessResult oBusinessResult)
        {
            // Read Entities from DAL
            SelectResult oSelectResult = null;
            List<CV_Training> __lstCVTraining =
                MyDatabase.RepoCVSelect.select_training_with_details_and_city(out oSelectResult, false);
            if (!oSelectResult.IsSuccess)
            {
                oBusinessResult = new BusinessResult(oSelectResult);
                return null;
            }//if

            // Convert it to Training BM
            try
            {
                List<TrainingBM> __lstTrainingM = new List<TrainingBM>();
                foreach (CV_Training __CV_Training in __lstCVTraining)
                {
                    __lstTrainingM.Add(TrainingBM.ToTrainingBM(__CV_Training));
                }//foreach 

                oBusinessResult = new BusinessResult(false);
                return __lstTrainingM;
            }//try
            catch (Exception __ex)
            {
                oBusinessResult = new BusinessResult(true,"Error while building Training BM!", __ex);
                return null;
            }//catch
            
        }//readTrainingM

        public List<SkillStatBM> readSkillStatM(out BusinessResult oBusinessResult)
        {
            // Read Entities from DAL
            SelectResult oSelectResult = null;
            List<(string name_desc, TimeSpan duration, string experience)>
                __lstStat = 
                MyDatabase.RepoCVSelect.select_skill_by_duration(out oSelectResult);
            if (!oSelectResult.IsSuccess)
            {
                oBusinessResult = new BusinessResult(oSelectResult);
                return null;
            }//if

            // Convert it to Training BM
            try
            {
                List<SkillStatBM> __lstSkillStatM = new List<SkillStatBM>();
                foreach ((string name_desc, TimeSpan duration, string experience) skillstat in __lstStat)
                {
                    __lstSkillStatM.Add(SkillStatBM.ToSkillStatBM(skillstat));
                }//foreach
                oBusinessResult = new BusinessResult(false);

                return __lstSkillStatM;
            }//try
            catch (Exception __ex)
            {
                oBusinessResult = new BusinessResult(true, "Error in readSkillStatM!", __ex);
                return null;
            }//catch



        }//readSkillStat

        public List<ExperienceBM> readExperienceM(out BusinessResult oBusinessResult)
        {
            // Read Entities from DAL
            SelectResult oSelectResult = null;
            List<CV_Experience> __lstExperience =
                MyDatabase.RepoCVSelect.select_experiences_with_activities(out oSelectResult);
            if (!oSelectResult.IsSuccess)
            {
                oBusinessResult = new BusinessResult(oSelectResult);
                return null;
            }//if
            List<CV_Job> __lstJobs =
                MyDatabase.RepoCVSelect.Read_All_Job_With_Contract_And_KeyRoles(out oSelectResult);
            if (!oSelectResult.IsSuccess)
            {
                oBusinessResult = new BusinessResult(oSelectResult);
                return null;
            }//if

            // Convert it to ExperienceBM
            try
            { 
                List<ExperienceBM> __lstExpM_Result = new List<ExperienceBM>();
                foreach (CV_Experience __experience in __lstExperience)
                {
                    __lstExpM_Result.Add(ExperienceBM.ToExperienceBM(__experience, __lstJobs));
                }//foreach
                oBusinessResult = new BusinessResult(false);

                return __lstExpM_Result;                
            }//try
            catch (Exception __ex)
            {
                oBusinessResult = new BusinessResult(true, "Error in readExperienceM!", __ex);
                return null;
            }//catch

        }//readExperienceM

    }//class
}//namespace
