using DHA.DAL.Entity;
using DHA.DAL.QueryResult;

namespace DHA.DAL.Repository
{
    public class CV_Update_Repo : ARepo
    {
        internal CV_Update_Repo(MyDbContext pMyDbCtx) : base(pMyDbCtx) {   }

        public int add_experience(

            //a finir
            out UpdateResult oUpdateResult,
            string pStrNameExperience,
            string? pStrDescription,
            int pIntCityCodePostal,
            string pStrFirmKey,
            int pIntYearStart, int pIntMonthStart,
            int pIntYearEnd, int pIntMonthEnd,
            params int[] pIntTabActivities)
        {
            try
            {
                //  Gest associated element
                CV_City lCity
                    = MyDbCtx.Cities.First(a => a.PostalCode == pIntCityCodePostal);
                CV_Firm lFirm
                    = MyDbCtx.Firms.First(a => a.Key == pStrFirmKey);

                CV_Experience lExperience = new CV_Experience();
                lExperience.Name = pStrNameExperience;
                lExperience.Description = pStrDescription;
                // owned by CV_Experience
                CV_ExperiencePeriod __experiencePeriod =
                    new CV_ExperiencePeriod();
                __experiencePeriod.YearStart = pIntYearStart;
                __experiencePeriod.MonthStart = pIntMonthStart;
                __experiencePeriod.YearEnd = pIntYearEnd;
                __experiencePeriod.MonthEnd = pIntMonthEnd;
                lExperience.ExperiencePeriod = __experiencePeriod;
                lExperience.CityId = lCity.ID;
                lExperience.FirmId = lFirm.ID;

                MyDbCtx.Experiences.Add(lExperience);

                int __intEntityUpdated = MyDbCtx.SaveChanges();

                oUpdateResult = new UpdateResult(true, __intEntityUpdated);

                return lExperience.ID;
            }//if
            catch (Exception ex)
            {
                oUpdateResult= new UpdateResult(ex);
                return -1;
            }//catch

        }//add

        public UpdateResult add_skill(string pStrSkillKey, string pStrSkillTypeKey, string pStrName, string pStrDetail = "")
        {
            List<CV_SkillType> __LstCvSkillType = MyDbCtx.Skill_Types.Where(a => a.Key == pStrSkillTypeKey).ToList();
            
            if (__LstCvSkillType.Count!=1)
            {
                return new UpdateResult("Skill Type not found");
            }

            CV_Skill lSkill = new CV_Skill()
            {
                Key = pStrSkillKey,
                Type = __LstCvSkillType[0],
                Name = pStrName,
                Detail = pStrDetail
            };
            return add_entity(lSkill);
        }//add_skill

        public UpdateResult add_training(int pIntCodePostal, int pIntYear, params string[] pStrTabDetail)
        {
            try
            {
                CV_City? __City = MyDbCtx.Cities.First(a => a.PostalCode == pIntCodePostal);

                CV_Training __Training = new CV_Training();
                __Training.Year = pIntYear;
                __Training.CV_CityId = __City.ID;
                List<CV_TrainingDetail> __listTD = new List<CV_TrainingDetail>();
                MyDbCtx.Trainings.Add(__Training);

                foreach (string lStrDetail in pStrTabDetail)
                {
                    CV_TrainingDetail __TrainingDetail = new CV_TrainingDetail();
                    __TrainingDetail.Detail = lStrDetail;
                    __TrainingDetail.Training = __Training;
                    MyDbCtx.TrainingDetails.Add(__TrainingDetail);
                }//foreach

                int __intRowsUpdated = MyDbCtx.SaveChanges();

                return new UpdateResult(true, __intRowsUpdated);
            }//try
            catch (Exception __ex)
            {
                return new UpdateResult(__ex);
            }//catch
        }//add_training

        public UpdateResult add_job(out int oOutJobId,
                                    string pStrJobName,string pStrContractTypeKey,params string[] pStrTabKeyRole)
        {
            try
            {

                CV_ContractType? lContractType = MyDbCtx.ContractTypes.First(a => a.Key == pStrContractTypeKey);
                if (lContractType == null)
                {
                    throw new Exception($"add / JobName : {pStrJobName} - ContractType : {pStrContractTypeKey}");
                }//if

                CV_Job __Cv_Job = new CV_Job()
                {
                    Name = pStrJobName,
                    CV_ContractTypeKey = lContractType.Key
                };
                MyDbCtx.Jobs.Add(__Cv_Job);
                int __intRowsUpdated = MyDbCtx.SaveChanges();

                foreach (string lStrkeyRole in pStrTabKeyRole)
                {
                    CV_KeyRole? lKeyRole = MyDbCtx.KeyRoles.First(a => a.Key == lStrkeyRole);

                    if (lKeyRole == null || lKeyRole == null)
                    {
                        throw new Exception($"add_keyrole / JobId : {__Cv_Job.ID} - SkillCode : {lStrkeyRole}");
                    }//if

                    CV_JobKeyRole __cvJobKeyRole = new CV_JobKeyRole();
                    __cvJobKeyRole.JobId = __Cv_Job.ID;
                    __cvJobKeyRole.KeyRoleKey = lKeyRole.Key;
                    MyDbCtx.JobKeyRoles.Add(__cvJobKeyRole);

                    __intRowsUpdated += MyDbCtx.SaveChanges();
                }//foreach

                // Commit                
                oOutJobId = __Cv_Job.ID;
                return new UpdateResult(true, __intRowsUpdated);

            }//try
            catch (Exception __ex)
            {
                oOutJobId = -1;
                return new UpdateResult(__ex);
            }//catch
        }//add_job

        public UpdateResult add_activity(
             out int oOutActivityId,
             int pIntExperienceId,
             int pIntJobId,
             string pStrCode,
             string pStrProjectName,
             string pStrSubProjectName,
             params string[] pStrActivityDetail)
        {
            try
            {
                //First add Activity
                CV_Activity lActivity = new CV_Activity()
                {
                    Code = pStrCode,
                    ProjectName = pStrProjectName,
                    SubProjectName = pStrSubProjectName,
                    ExperienceId = pIntExperienceId,
                    JobId = pIntJobId
                };
                MyDbCtx.Activities.Add(lActivity);
                int __intRowsUpdated = MyDbCtx.SaveChanges();

                __intRowsUpdated += add_activity_detail(lActivity.ID, pStrActivityDetail);

                oOutActivityId = lActivity.ID;
               
                return new UpdateResult(true, __intRowsUpdated);
            }//try
            catch (Exception __ex)
            {
                oOutActivityId = -1;
                return new UpdateResult(__ex);
            }//catch}

        }//add_activity

        private int add_activity_detail(
            int pIntActivityId,
            params string[] pStrActivityDetail)
        {
            // exceptions généré dans parent

            List<CV_ActivityDetail> lLstAD = new List<CV_ActivityDetail>();

            foreach (string lStrDetail in pStrActivityDetail)
            {
                CV_ActivityDetail lActivityDetail = new CV_ActivityDetail();
                lActivityDetail.Detail = lStrDetail;
                lActivityDetail.ActivityId = pIntActivityId;
                MyDbCtx.ActivitiesDetail.Add(lActivityDetail);
            }//foreach

            return MyDbCtx.SaveChanges();

        }//add_activity_detail

        public UpdateResult add_skills(int pIntActivityId,
            params string[] pStrTabSkillCode)
        {
            try
            {

                CV_Activity?
                lActivity = MyDbCtx.Activities.First(a => a.ID == pIntActivityId);

                foreach (string lStrSkillCode in pStrTabSkillCode)
                {
                    CV_Skill? lSkill = MyDbCtx.Skills.First(a => a.Key == lStrSkillCode);

                    if (lActivity == null || lSkill == null)
                    {
                        throw new Exception(
                            $"add_skill / ActivityId : {pIntActivityId} - SkillCode : {lStrSkillCode}");
                    }//if

                    CV_ActivitySkill lActivitySkill =
                        new CV_ActivitySkill();
                    lActivitySkill.ActivityId = pIntActivityId;
                    lActivitySkill.SkillId = lSkill.ID;

                    MyDbCtx.ActivitySkills.Add(lActivitySkill);
                }//foreach

                int __intRowsUpdated = MyDbCtx.SaveChanges();
                return new UpdateResult(true, __intRowsUpdated);
            }//try
            catch (Exception __ex)
            {
                return new UpdateResult(__ex);
            }//catch

        }//add_skill

        public UpdateResult add_contract_type(string pStrKey, string pStrValue)
        {
            try
            {
                MyDbCtx.ContractTypes.Add(
                    new CV_ContractType() { Key = pStrKey, Name = pStrValue });

                int __intRowsUpdated = MyDbCtx.SaveChanges();
                return new UpdateResult(true, __intRowsUpdated);
            }//try
            catch (Exception __ex)
            {
                return new UpdateResult(__ex);
            }//catch
        }//add_contract_type 

        public UpdateResult add_key_role(string pStrKey, string pStrValue)
        {
            try
            {
                MyDbCtx.KeyRoles.Add(
                    new CV_KeyRole() { Key = pStrKey, Name = pStrValue });

                int __intRowsUpdated = MyDbCtx.SaveChanges();
                return new UpdateResult(true, __intRowsUpdated);
            }//try
            catch (Exception __ex)
            {
                return new UpdateResult(__ex);
            }//catch
        }//add_key_role

    }//class

}//namespace
