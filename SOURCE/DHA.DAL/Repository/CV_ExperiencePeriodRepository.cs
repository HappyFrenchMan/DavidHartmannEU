using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class CV_ExperiencePeriodRepository : Repository<CV_ExperiencePeriod>
    {
        public CV_ExperiencePeriodRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
