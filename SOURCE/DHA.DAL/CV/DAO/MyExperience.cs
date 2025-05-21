using DHA.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.CV.DAO
{
    public class MyExperience
    {
        public static int add(
            string pStrName,
            string? pStrDescription,
            int pIntCityCodePostal,
            int pIntFirmId,
            int pIntYearStart, int pIntMonthStart,
            int pIntYearEnd, int pIntMonthEnd,
            params int[] pIntTabActivities)
        {
            using (Db_Context lDHA_Db_Context = new Db_Context())
            {
                CV_Experience lExperience = new CV_Experience();
                lExperience.Name = pStrName;
                lExperience.Description = pStrDescription;

                CV_ExperiencePeriod __experiencePeriod =
                    new CV_ExperiencePeriod();
                __experiencePeriod.YearStart = pIntYearStart;
                __experiencePeriod.MonthStart = pIntMonthStart;
                __experiencePeriod.YearEnd = pIntYearEnd;
                __experiencePeriod.MonthEnd = pIntMonthEnd;

                lExperience.ExperiencePeriod = __experiencePeriod;

                CV_City? lCity = MyCatalog.select_city(pIntCityCodePostal);
                if (lCity != null)
                {
                    lDHA_Db_Context.Attach<CV_City>(lCity);
                    lExperience.City = lCity;
                }//if

                CV_Firm? lFirm = MyCatalog.select_firm(pIntFirmId);
                if (lFirm != null)
                {
                    lDHA_Db_Context.Attach<CV_Firm>(lFirm);
                    lExperience.Firm = lFirm;
                }//if

                foreach (int lIntActivity in pIntTabActivities)
                {
                    CV_Activity? lActivity
                        = MyActivity.select_activity(lIntActivity);

                    if (lActivity != null)
                    {
                        lExperience.Activities.Add(lActivity);
                    }//if
                    else
                    {
                        throw new Exception("select_activity error");
                    }//else
                }//foreach

                lDHA_Db_Context.Experiences.Add(lExperience);
                lDHA_Db_Context.SaveChanges();

                return lExperience.ID;
            }//using
        }//add

        public static void add_activity(int pIntExperienceId, int pIntActivityId)
        {
            using (Db_Context lDHA_Db_Context = new Db_Context())
            {
                CV_Experience? lExperience = lDHA_Db_Context.Experiences.Where(x => x.ID == pIntActivityId).FirstOrDefault();
                CV_Activity? lActivity = lDHA_Db_Context.Activities.Where(x => x.ID == pIntActivityId).FirstOrDefault();
                if (lExperience == null || lActivity == null)
                {
                    throw new Exception($"Error add_activity {pIntExperienceId} - {pIntActivityId}");
                }//if
                lExperience.Activities.Add(lActivity);
                lDHA_Db_Context.SaveChanges();
            }//using
        }//add_activity

        public static List<CV_Experience> select_experiences_with_activities()
        {
            using (Db_Context lDHA_Db_Context = new Db_Context())
            {
                List<CV_Experience> __lstExp =
                    lDHA_Db_Context.Experiences
                    .Include(exp => exp.City)
                    .Include(exp => exp.Firm)
                    .Include(exp => exp.Activities)
                    .ThenInclude(act => act.ActivityDetails)
                    .Include(exp => exp.Activities)
                    .ThenInclude(act => act.ActivitySkills)
                    .ThenInclude(sk => sk.Skill)
                    .ToList();

                return __lstExp;
            }//using
        }//select_experiences
    }//class
}//namespace
