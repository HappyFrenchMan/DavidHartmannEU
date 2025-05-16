using DHA.DAL;
using DHA.DAL.CV.Entity;
using log4net.Core;
using Microsoft.EntityFrameworkCore;
using static DHA.DAL.CV.Entity.Job;

namespace DHA.DAL.CV.DAO
{
    public class MyJobs
    {

        public static int add(string pStrJobName,
                              string pStrContractTypeKey,
                              params string[] pStrTabKeyRole)
        {
            ContractType? lContractType = MyCatalog.select_contractType(pStrContractTypeKey);
            if (lContractType == null)
            {
                throw new Exception($"add / JobName : {pStrJobName} - ContractType : {pStrContractTypeKey}");
            }//if

            int lIntJobId = -1;
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                Job lJob = new Job()
                {
                    Name = pStrJobName,
                    ContractTypeKey = lContractType.Key
                };

                lDHA_Db_Context.Jobs.Add(lJob);
                lDHA_Db_Context.SaveChanges();
                lIntJobId = lJob.ID;
            }//using

            add_keyrole(lIntJobId, pStrTabKeyRole);

            return lIntJobId;
        }//add

        public static void add_keyrole(int pIntJobId, params string[] pStrTabKeyRole)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                Job? lJob = select_job(pIntJobId);

                foreach (string lStrkeyRole in pStrTabKeyRole)
                {
                    KeyRole? lKeyRole = MyCatalog.select_keyrole(lStrkeyRole);

                    if (lKeyRole == null || lKeyRole == null)
                    {
                        throw new Exception($"add_keyrole / JobId : {pIntJobId} - SkillCode : {lStrkeyRole}");
                    }//if

                    JobKeyRole lJobKeyRole = new JobKeyRole();
                    lJobKeyRole.JobId = pIntJobId;
                    lJobKeyRole.KeyRoleKey = lKeyRole.Key;
                    
                    lDHA_Db_Context.JobKeyRoles.Add(lJobKeyRole);
                }//foreach

                lDHA_Db_Context.SaveChanges();
            }//using
        }//add_skill


        public static Job? select_job(int pIntJobId)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                return lDHA_Db_Context.Jobs
                    .Include(c => c.ContractType)
                    .Include(j => j.JobKeyRoles)
                    .ThenInclude(k => k.KeyRole)
                    .Where(p => p.ID.Equals(pIntJobId)).FirstOrDefault();
            }//using
        }//select_activity


    }//class
}//namespace
