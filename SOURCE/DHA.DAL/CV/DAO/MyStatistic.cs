using DHA.DAL.CV.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.CV.DAO
{
    public class MyStatistic
    {
        public static List<Tuple<string, TimeSpan, string>> select_skill_by_duration()
        {
            List<Tuple<string, TimeSpan, string>> __tupleResult = new List<Tuple<string, TimeSpan, string>>();

            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                List<Skill> __lstSkill = lDHA_Db_Context.Skills.Include(a => a.Type).ToList();
                List<ActivitySkill> __lstActivitySkill = lDHA_Db_Context.ActivitySkills.ToList();
                List<Activity> __lstActivity = lDHA_Db_Context.Activities.ToList();
                List<Experience> __lstExperience = lDHA_Db_Context.Experiences.ToList();
                List<int> __listIdExperienceFound = new List<int>();

                foreach (Skill __skill in __lstSkill)
                {
                    __listIdExperienceFound.Clear();
                    TimeSpan __tsDuration = new TimeSpan();
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (ActivitySkill __activitySkill in __lstActivitySkill)
                    {
                        if (__activitySkill.SkillId.Equals(__skill.ID))
                        {
                            foreach (Activity __activity in __lstActivity)
                            {
                                if (__activity.ID.Equals(__activitySkill.ActivityId))
                                {
                                    foreach (Experience __experience in __lstExperience)
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
                    Tuple<string, TimeSpan, string> __TupleNew 
                        = Tuple.Create( $"{__skill.Name}[##][{__skill.Type.Description}]",
                        __tsDuration,
                        stringBuilder.ToString());

                    __tupleResult.Add(__TupleNew);
                }//foreach
            }//using

            return __tupleResult.OrderByDescending( a => a.Item2).ToList();
        }//select_experiences

    }//class
}//namespace

