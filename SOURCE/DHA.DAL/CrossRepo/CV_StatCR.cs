using DAH.DAL;
using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.CrossRepo
{
    public class CV_StatCR
    {
        private MyDb _myDbRef;

        private CV_StatCR() { }

        public CV_StatCR(MyDb pMyDb) { _myDbRef = pMyDb;  }

        public List<Tuple<string, TimeSpan, string>> select_skill_by_duration()
        {
            FindOptions __findOptionsNoTracking = new FindOptions() { IsAsNoTracking = true };

            List<Tuple<string, TimeSpan, string>> __tupleResult = new List<Tuple<string, TimeSpan, string>>();

            List<CV_Skill> __lstSkill = _myDbRef.CVSkillRepository.Read_All_Skill_With_Type(false);
            List<CV_ActivitySkill> __lstActivitySkill = _myDbRef.CVActivitySkillRepository.GetAll(__findOptionsNoTracking).ToList();
            List<CV_Activity> __lstActivity = _myDbRef.CVActivityRepository.GetAll(__findOptionsNoTracking).ToList();
            List<CV_Experience> __lstExperience = _myDbRef.CVExperienceRepository.GetAll(__findOptionsNoTracking).ToList();
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
                Tuple<string, TimeSpan, string> __TupleNew
                    = Tuple.Create($"{__skill.Name}[##][{__skill.Type.Description}]",
                    __tsDuration,
                    stringBuilder.ToString());

                __tupleResult.Add(__TupleNew);
            }//foreach


            return __tupleResult.OrderByDescending(a => a.Item2).ToList();
        }//select_skill_by_duration
    }//class

}//namespace
