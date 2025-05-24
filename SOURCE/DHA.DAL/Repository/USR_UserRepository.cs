using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class USR_UserRepository : Repository<USR_User>
    {
        public USR_UserRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
