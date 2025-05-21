using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class CV_ExperienceRepository : Repository<CV_Experience>
    {
        public CV_ExperienceRepository(Db_Context pDb_Context) : base(pDb_Context) { }//CV_ActivityRepository
    }//class
}//namespace
