using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class CV_CityRepository : Repository<CV_City>
    {
        public CV_CityRepository(Db_Context pDb_Context) : base(pDb_Context) { }//CV_CityRepository
    }//class
}//namespace
