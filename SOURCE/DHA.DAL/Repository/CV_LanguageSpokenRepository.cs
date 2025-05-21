using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class CV_LanguageSpokenRepository : Repository<CV_LanguageSpoken>
    {
        public CV_LanguageSpokenRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
