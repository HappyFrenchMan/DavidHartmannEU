using DHA.EntityFrameworkCore_Models;
using DHA.EntityFrameworkCore_Models.CV.Entity;
using static DHA.EntityFrameworkCore_Models.CV.Entity.Job;

namespace DHA.EntityFrameworkCore_Models.CV.DAO
{
    public class MyJobs
    {

        public static int add(
            string pStrJobName,     
            CONST_ENUM_JOB_STATUS pJobStatus,
            params CONST_ENUM_JOB_ROLE[] pJobRole)
        {
            
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                List<CONST_ENUM_JOB_ROLE> lLstRole = new List<CONST_ENUM_JOB_ROLE>();
                foreach (CONST_ENUM_JOB_ROLE lRole in pJobRole) 
                { 
                    lLstRole.Add(lRole);
                } 

                bool lBoolAnalyst = lLstRole.Contains(Job.CONST_ENUM_JOB_ROLE.ANALYST);
                bool lBoolManager = lLstRole.Contains(Job.CONST_ENUM_JOB_ROLE.MANAGER);
                bool lBoolIsCP  = lLstRole.Contains(Job.CONST_ENUM_JOB_ROLE.CP);
                bool lBoolIsTE = lLstRole.Contains(Job.CONST_ENUM_JOB_ROLE.EXPERT);
                bool lBoolIsDEV = lLstRole.Contains(Job.CONST_ENUM_JOB_ROLE.DEV);

                Job lJob = new Job()
                {
                    JobName = pStrJobName,
                    IsAnalyst = lBoolAnalyst,
                    IsManager = lBoolManager,
                    IsCP = lBoolIsCP,
                    IsTechnicalExpert = lBoolIsTE,
                    IsDev = lBoolIsDEV,
                    JobStatus = pJobStatus.ToString()
                };

                lDHA_Db_Context.Jobs.Add(lJob);

                lDHA_Db_Context.SaveChanges();

                return lJob.ID;
            }//using
        }//add
    }//class
}//namespace
