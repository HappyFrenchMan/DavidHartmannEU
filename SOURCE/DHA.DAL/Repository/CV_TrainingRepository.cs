using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DHA.DAL.Repository
{
    public class CV_TrainingRepository : Repository<CV_Training>
    {
        public CV_TrainingRepository(Db_Context pDb_Context) : base(pDb_Context) { }

        public List<CV_Training>  select_training_with_details_and_city()
        {
            IQueryable<CV_Training> __iqa = GetAll();
            __iqa.Include("TrainingDetails").Include("CV_City");
            return __iqa.ToList();
        }//select_training_with_details
    }//class
}//namespace
