using DHA.DAL.CV.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.CV.DAO
{
    public class MyActivity
    {
        //public string Code { get; set; }
        //public string ProjectName { get; set; }
        //public string SubProjectName { get; set; }

        public static int add_activity(
            int pIntExperienceId,
            int pIntJobId,            
            string pStrCode,
            string pStrProjectName,
            string pStrSubProjectName,      
            params string[] pStrActivityDetail)
        {
            //First add Activity
            int lIntActivityID = -1;
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                Activity lActivity = new Activity()
                {
                    Code = pStrCode,
                    ProjectName = pStrProjectName,
                    SubProjectName = pStrSubProjectName,
                    ExperienceId = pIntExperienceId,
                    JobId = pIntJobId
                };
                lDHA_Db_Context.Activities.Add(lActivity);
                lDHA_Db_Context.SaveChanges();

                lIntActivityID = lActivity.ID;
            }//using            

            add_activity_detail(lIntActivityID, pStrActivityDetail);

            return lIntActivityID;
        }//add_activity

        private static void add_activity_detail(
            int pIntActivityId,
            params string[] pStrActivityDetail)
        {
            //Then Add Activity Detail
            List<ActivityDetail> lLstAD = new List<ActivityDetail>();
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                foreach (string lStrDetail in pStrActivityDetail)
                {
                    ActivityDetail lActivityDetail = new ActivityDetail();
                    lActivityDetail.Detail = lStrDetail;
                    lActivityDetail.ActivityId = pIntActivityId;
                    lDHA_Db_Context.ActivitiesDetail.Add(lActivityDetail);
                    lLstAD.Add(lActivityDetail);
                }//foreach

                lDHA_Db_Context.SaveChanges();
            }//using
        }//add_activity_detail

        public static void add_skills(int pIntActivityId, 
            params string [] pStrTabSkillCode)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                Activity?
                    lActivity = select_activity(pIntActivityId);
                
                foreach (string lStrSkillCode in pStrTabSkillCode)
                {
                    Skill? lSkill = MyCatalog.select_skill(lStrSkillCode);
               
                    if (lActivity == null || lSkill == null)
                    {
                        throw new Exception(
                            $"add_skill / ActivityId : {pIntActivityId} - SkillCode : {lStrSkillCode}");
                    }//if

                    ActivitySkill lActivitySkill =
                        new ActivitySkill();
                    lActivitySkill.ActivityId = pIntActivityId;
                    lActivitySkill.SkillId = lSkill.ID;
                    lDHA_Db_Context.ActivitySkills.Add(lActivitySkill);
                }//foreach

                lDHA_Db_Context.SaveChanges();
            }//using
        }//add_skill

        public static Activity? select_activity(int pIntActiviyId)
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                return
                    lDHA_Db_Context.Activities.Where(
                        p => p.ID.Equals(pIntActiviyId)
                        ).FirstOrDefault();
            }//using
        }//select_activity

    }//class
}//namespace
