using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class USR_RoleRepository : Repository<USR_Role>
    {
        public USR_RoleRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
