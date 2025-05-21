using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class CV_ActivityRepository : Repository<CV_Activity>
    {
        public  CV_ActivityRepository(Db_Context pDb_Context) : base(pDb_Context) { }//CV_ActivityRepository
    }//class
}//namespace
