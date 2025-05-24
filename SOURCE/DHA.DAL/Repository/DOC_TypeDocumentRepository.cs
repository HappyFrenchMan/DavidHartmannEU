using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class DOC_TypeDocumentRepository : Repository<DOC_TypeDocument>
    {
        public DOC_TypeDocumentRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
