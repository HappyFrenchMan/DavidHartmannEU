using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class DOC_SubTypeDocumentRepository : Repository<DOC_SubTypeDocument>
    {
        public DOC_SubTypeDocumentRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
