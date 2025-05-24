using DAH.DAL;
using DHA.DAL.Entity;
using System;
using System.Collections.Generic;
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

        public void addTraining(int pIntCodePostal,int pIntYear,params string[] pStrTabDetail)
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

        }//class

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
        }//add_keyrole

    }//class

}//namespace
