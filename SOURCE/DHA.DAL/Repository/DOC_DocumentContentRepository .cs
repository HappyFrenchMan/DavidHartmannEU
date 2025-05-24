using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class DOC_DocumentContentRepository : Repository<DOC_DocumentContent>
    {
        public DOC_DocumentContentRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
