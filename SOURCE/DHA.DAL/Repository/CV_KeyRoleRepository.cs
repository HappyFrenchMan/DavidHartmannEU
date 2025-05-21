using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class CV_KeyRoleRepository : Repository<CV_KeyRole>
    {
        public CV_KeyRoleRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
