using DAH.DAL;
using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace DHA.DAL.Repository
{
    public class CV_SkillRepository : Repository<CV_Skill>
    {
        public CV_SkillRepository(Db_Context pDb_Context) : base(pDb_Context) { }       

        public List<CV_Skill> Read_All_Skill_With_Type(bool pBoolTracking=true)
        {
            var __iqa = _myDBContext.Skills.Include(a => a.Type);
            if (!pBoolTracking)
            {
                return __iqa.AsNoTracking().ToList();
            }
            return __iqa.ToList();
        }//Read_All_Skill_With_Type

    }//class
}//namespace
