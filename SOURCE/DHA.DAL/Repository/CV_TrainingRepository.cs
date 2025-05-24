using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class CV_TrainingRepository : Repository<CV_Training>
    {
        public CV_TrainingRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
