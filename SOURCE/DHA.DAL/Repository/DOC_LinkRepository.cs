using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class DOC_LinkRepository : Repository<DOC_Link>
    {
        public DOC_LinkRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
