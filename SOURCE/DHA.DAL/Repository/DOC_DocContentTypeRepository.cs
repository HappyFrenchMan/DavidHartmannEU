using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class DOC_DocContentTypeRepository : Repository<DOC_DocContentType>
    {
        public DOC_DocContentTypeRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
