using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class CV_JobRepository : Repository<CV_Job>
    {
        public CV_JobRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
