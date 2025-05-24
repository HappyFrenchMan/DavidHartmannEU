using DAH.DAL;
using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class CV_SkillRepository : Repository<CV_Skill>
    {
        public CV_SkillRepository(Db_Context pDb_Context) : base(pDb_Context) { }       


    }//class
}//namespace
