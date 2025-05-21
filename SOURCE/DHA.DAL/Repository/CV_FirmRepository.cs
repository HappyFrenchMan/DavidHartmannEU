using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class CV_FirmRepository : Repository<CV_Firm>
    {
        public CV_FirmRepository(Db_Context pDb_Context) : base(pDb_Context) { }//CV_FirmRepository
    }//class
}//namespace
