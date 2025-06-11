using DAH.DAL;
using DHA.DAL.Entity;
using DHA.DAL.QueryResult;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace DHA.DAL.Repository
{
    public class CV_Select_Repo : ARepo
    {
        internal CV_Select_Repo(MyDbContext pMyDbCtx) : base(pMyDbCtx) { }

        /// <summary>
        /// Stat
        /// </summary>
        /// <returns>Returns skill , duration and associated experience</returns>
        public List<(string name_desc, TimeSpan duration, string experience)> select_skill_by_duration(out SelectResult oOutSelectResult)
        {
            List<(string name_desc, TimeSpan duration, string experience)> __tupleResult
                = new List<(string name_desc, TimeSpan duration, string experience)>();

            try
            {
                List<CV_Skill> __lstSkill = MyDbCtx.Skills.Include(a => a.Type).AsNoTracking().ToList();
                List<CV_ActivitySkill> __lstActivitySkill = MyDbCtx.ActivitySkills.AsNoTracking().ToList();
                List<CV_Activity> __lstActivity = MyDbCtx.Activities.AsNoTracking().ToList();
                List<CV_Experience> __lstExperience = MyDbCtx.Experiences.AsNoTracking().ToList();
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
                                if (__activity.ID.Equals(__activitySkill.ActivityId))
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
                    __tupleResult.Add(($"{__skill.Name}[##][{__skill.Type.Description}]", __tsDuration, stringBuilder.ToString()));
                }//foreach

                oOutSelectResult = new SelectResult(true);
                return __tupleResult.OrderByDescending(a => a.duration).ToList();

            }//try
            catch (Exception ex)
            {
                oOutSelectResult = new SelectResult(ex);
                return null;
            }//catch
        }//select_skill_by_duration


        public List<CV_Experience> select_experiences_with_activities(out SelectResult oOutSelectResult)
        {
            oOutSelectResult = new SelectResult(true);
            try
            { 
                return
                        MyDbCtx.Experiences
                        .Include(exp => exp.City)
                        .Include(exp => exp.Firm)
                        .Include(exp => exp.Activities)
                        .ThenInclude(act => act.ActivityDetails)
                        .Include(exp => exp.Activities)
                        .ThenInclude(act => act.ActivitySkills)
                        .ThenInclude(sk => sk.Skill)
                        .AsNoTracking() /* don't track all database info ! */
                        .ToList();                
            }//try
            catch (Exception ex)
            {
                oOutSelectResult = new SelectResult(ex);
                return null;
            }//catch

        }//select_experiences_with_activities


        public CV_Firm select_firm(string pStrKey,out SelectResult oOutSelectResult)
        {
            oOutSelectResult = new SelectResult(true);
            try
            {
                return
                        MyDbCtx.Firms
                        .Where(a => a.Key==pStrKey)
                        .AsNoTracking() /* don't track all database info ! */
                        .ToList()[0];
            }//try
            catch (Exception ex)
            {
                oOutSelectResult = new SelectResult(ex);
                return null;
            }//catch

        }//select_firm


        public List<CV_Skill> Read_All_Skill_With_Type(out SelectResult oOutSelectResult, bool pBoolTracking = true)
        {
            oOutSelectResult = new SelectResult(true);
            try
            {
                var __iqa = MyDbCtx.Skills.Include(a => a.Type);
                if (!pBoolTracking)
                {
                    return __iqa.AsNoTracking().ToList();
                }
                return __iqa.ToList();
            }//try
            catch (Exception ex)
            {
                oOutSelectResult = new SelectResult(ex);
                return null;
            }//catch
        }//Read_All_Skill_With_Type

        public List<CV_Training> select_training_with_details_and_city(out SelectResult oOutSelectResult, bool pBoolTracking = true)
        {
            oOutSelectResult = new SelectResult(true);
            try
            {
                IQueryable<CV_Training> __iqa = MyDbCtx.Trainings;
                __iqa.Include("TrainingDetails").Include("CV_City");
                if (!pBoolTracking)
                {
                    return __iqa.AsNoTracking().ToList();
                }
                return __iqa.ToList();
            }//try
            catch (Exception ex)
            {
                oOutSelectResult = new SelectResult(ex);
                return null;
            }//catch
        }//select_training_with_details

        public List<CV_Job> Read_All_Job_With_Contract_And_KeyRoles(out SelectResult oOutSelectResult)
        {
            oOutSelectResult = new SelectResult(true);
            try
            {
                var __iqa = MyDbCtx.Jobs.Include(a => a.CV_ContractType).Include(b => b.JobKeyRoles);
                return __iqa.AsNoTracking().ToList();
                
            }//try
            catch (Exception ex)
            {
                oOutSelectResult = new SelectResult(ex);
                return null;
            }//catch
        }//Read_All_Skill_With_Type


    }//class

}//namespace
