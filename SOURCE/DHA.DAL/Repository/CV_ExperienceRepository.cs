using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;
using Microsoft.EntityFrameworkCore;


namespace DHA.DAL.Repository
{
    public class CV_ExperienceRepository : Repository<CV_Experience>
    {
        public CV_ExperienceRepository(Db_Context pDb_Context) : base(pDb_Context) { }

        public List<CV_Experience> select_experiences_with_activities()
        {
            return
                    _myDBContext.Experiences
                    .Include(exp => exp.City)
                    .Include(exp => exp.Firm)
                    .Include(exp => exp.Activities)
                    .ThenInclude(act => act.ActivityDetails)
                    .Include(exp => exp.Activities)
                    .ThenInclude(act => act.ActivitySkills)
                    .ThenInclude(sk => sk.Skill)
                    .AsNoTracking() /* don't track all database info ! */
                    .ToList();

        }//select_experiences
    }//class
}//namespace
