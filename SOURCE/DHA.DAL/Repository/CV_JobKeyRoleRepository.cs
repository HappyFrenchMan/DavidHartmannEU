using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class CV_JobKeyRoleRepository : Repository<CV_JobKeyRole>
    {
        public CV_JobKeyRoleRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
