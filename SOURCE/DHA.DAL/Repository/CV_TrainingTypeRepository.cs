using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class CV_TrainingTypeRepository : Repository<CV_TrainingType>
    {
        public CV_TrainingTypeRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
