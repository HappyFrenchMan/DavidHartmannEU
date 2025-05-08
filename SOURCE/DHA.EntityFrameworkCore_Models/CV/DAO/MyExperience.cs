using DHA.EntityFrameworkCore_Models.CV.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.EntityFrameworkCore_Models.CV.DAO
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
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                Experience lExperience = new Experience();
                lExperience.Name = pStrName;
                lExperience.Description = pStrDescription;

                ExperiencePeriod __experiencePeriod =
                    new ExperiencePeriod();
                __experiencePeriod.YearStart = pIntYearStart;
                __experiencePeriod.MonthStart = pIntMonthStart;
                __experiencePeriod.YearEnd = pIntYearEnd;
                __experiencePeriod.MonthEnd = pIntMonthEnd;

                lExperience.ExperiencePeriod = __experiencePeriod;

                City? lCity = MyCatalog.select_city(pIntCityCodePostal);
                if (lCity != null)
                {
                    lDHA_Db_Context.Attach<City>(lCity);
                    lExperience.City = lCity;
                }//if

                Firm? lFirm = MyCatalog.select_firm(pIntFirmId);
                if (lFirm != null)
                {
                    lDHA_Db_Context.Attach<Firm>(lFirm);
                    lExperience.Firm = lFirm;
                }//if

                foreach (int lIntActivity in pIntTabActivities)
                {
                    Activity? lActivity
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
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                Experience? lExperience = lDHA_Db_Context.Experiences.Where(x => x.ID == pIntActivityId).FirstOrDefault();
                Activity? lActivity = lDHA_Db_Context.Activities.Where(x => x.ID == pIntActivityId).FirstOrDefault();
                if (lExperience == null || lActivity == null)
                {
                    throw new Exception($"Error add_activity {pIntExperienceId} - {pIntActivityId}");
                }//if
                lExperience.Activities.Add(lActivity);
                lDHA_Db_Context.SaveChanges();
            }//using
        }//add_activity

        public static List<Experience> select_experiences_with_activities()
        {
            using (DHA_Db_Context lDHA_Db_Context = new DHA_Db_Context())
            {
                List<Experience> __lstExp =
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
