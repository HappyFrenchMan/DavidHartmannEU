using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;

namespace DHA.DAL.Repository
{
    public class CV_SkillTypeRepository : Repository<CV_SkillType>
    {
        public CV_SkillTypeRepository(Db_Context pDb_Context) : base(pDb_Context) { }
    }//class
}//namespace
