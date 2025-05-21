using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class CV_ActivityDetailRepository : Repository<CV_ActivityDetail>
    {
        public CV_ActivityDetailRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
