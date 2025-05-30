using DAH.DAL;
using DHA.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.CrossRepo
{
    public class CV_FeedCR
    {
        private MyDb _myDbRef;

        private CV_FeedCR() { }

        public CV_FeedCR(MyDb pMyDb) { _myDbRef = pMyDb;  }

        public int add_experience(
            string pStrNameExperience,
            string? pStrDescription,
            int pIntCityCodePostal,
            string pStrFirmKey,
            int pIntYearStart, int pIntMonthStart,
            int pIntYearEnd, int pIntMonthEnd,
            params int[] pIntTabActivities)
        {            
            //  Gest associated element
            CV_City lCity
                = _myDbRef.CVCityRepository.FindOne(a => a.PostalCode == pIntCityCodePostal);
            CV_Firm lFirm
                = _myDbRef.CVFirmRepository.FindOne(a => a.Key == pStrFirmKey);

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

            _myDbRef.CVExperienceRepository.Add(lExperience);

            return lExperience.ID;
        }//add

        public void add_skill(string pStrSkillKey,string pStrSkillTypeKey,string pStrName,string pStrDetail = "")
        {
            CV_SkillType __cvSkillType =  _myDbRef.CVSkillTypeRepository.FindOne(a => a.Key == pStrSkillTypeKey);
            CV_Skill lSkill = new CV_Skill()
            {
                Key = pStrSkillKey,
                Type = __cvSkillType,
                Name = pStrName,
                Detail = pStrDetail
            };
            _myDbRef.CVSkillRepository.Add(lSkill);
        }//add_skill

        public void add_training(int pIntCodePostal,int pIntYear,params string[] pStrTabDetail)
        {
            CV_City? __City = _myDbRef.CVCityRepository.Find(a => a.PostalCode==pIntCodePostal).FirstOrDefault();
                         
            CV_Training __Training = new CV_Training();
            __Training.Year = pIntYear;
            __Training.CV_CityId = __City.ID;
            List<CV_TrainingDetail> __listTD = new List<CV_TrainingDetail>();
            _myDbRef.CVTrainingRepository.Add(__Training);
            
            foreach (string lStrDetail in pStrTabDetail)
            {
                    CV_TrainingDetail __TrainingDetail = new CV_TrainingDetail();
                    __TrainingDetail.Detail = lStrDetail;
                    __TrainingDetail.Training = __Training;
                    _myDbRef.CVTrainingDetailRepository.Add(__TrainingDetail);            
            }//foreach                

         }//add_training

        public int add_job(string pStrJobName,
                              string pStrContractTypeKey,
                              params string[] pStrTabKeyRole)
        {
            CV_ContractType? lContractType = _myDbRef.CVContractTypeRepository.FindOne(a => a.Key==pStrContractTypeKey);
            if (lContractType == null)
            {
                throw new Exception($"add / JobName : {pStrJobName} - ContractType : {pStrContractTypeKey}");
            }//if

            CV_Job __Cv_Job = new CV_Job()
            {
                Name = pStrJobName,
                CV_ContractTypeKey = lContractType.Key
            };
            _myDbRef.CVJobRepository.Add(__Cv_Job);
            
            foreach (string lStrkeyRole in pStrTabKeyRole)
            {
                CV_KeyRole? lKeyRole = _myDbRef.CVKeyRoleRepository.FindOne(a => a.Key==lStrkeyRole);

                if (lKeyRole == null || lKeyRole == null)
                {
                    throw new Exception($"add_keyrole / JobId : {__Cv_Job.ID} - SkillCode : {lStrkeyRole}");
                }//if

                CV_JobKeyRole __cvJobKeyRole = new CV_JobKeyRole();
                __cvJobKeyRole.JobId = __Cv_Job.ID;
                __cvJobKeyRole.KeyRoleKey = lKeyRole.Key;

                _myDbRef.CVJobKeyRoleRepository.Add(__cvJobKeyRole);
            }//foreach


            return __Cv_Job.ID;
        }//add_job

        public int add_activity(
             int pIntExperienceId,
             int pIntJobId,
             string pStrCode,
             string pStrProjectName,
             string pStrSubProjectName,
             params string[] pStrActivityDetail)
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
            _myDbRef.CVActivityRepository.Add(lActivity);

            add_activity_detail(lActivity.ID, pStrActivityDetail);

            return lActivity.ID;
        }//add_activity

        public void add_activity_detail(
            int pIntActivityId,
            params string[] pStrActivityDetail)
        {
            List<CV_ActivityDetail> lLstAD = new List<CV_ActivityDetail>();

            foreach (string lStrDetail in pStrActivityDetail)
            {
                CV_ActivityDetail lActivityDetail = new CV_ActivityDetail();
                lActivityDetail.Detail = lStrDetail;
                lActivityDetail.ActivityId = pIntActivityId;
                _myDbRef.CVActivityDetailRepository.Add(lActivityDetail);
            }//foreach

        }//add_activity_detail

        public void add_skills(int pIntActivityId,
            params string[] pStrTabSkillCode)
        {
            CV_Activity?
                lActivity = _myDbRef.CVActivityRepository.FindOne(a=>a.ID==pIntActivityId);

            foreach (string lStrSkillCode in pStrTabSkillCode)
            {
                CV_Skill? lSkill = _myDbRef.CVSkillRepository.FindOne(a=>a.Key==lStrSkillCode);

                if (lActivity == null || lSkill == null)
                {
                    throw new Exception(
                        $"add_skill / ActivityId : {pIntActivityId} - SkillCode : {lStrSkillCode}");
                }//if

                CV_ActivitySkill lActivitySkill =
                    new CV_ActivitySkill();
                lActivitySkill.ActivityId = pIntActivityId;
                lActivitySkill.SkillId = lSkill.ID;

                _myDbRef.CVActivitySkillRepository.Add(lActivitySkill);
            }//foreach
        }//add_skill


    }//class

}//namespace
