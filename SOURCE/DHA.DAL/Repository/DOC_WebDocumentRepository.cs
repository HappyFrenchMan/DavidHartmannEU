using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class DOC_WebDocumentRepository : Repository<DOC_WebDocument>
    {
        public DOC_WebDocumentRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
