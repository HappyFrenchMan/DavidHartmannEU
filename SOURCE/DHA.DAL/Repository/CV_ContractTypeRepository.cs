using DHA.DAL.Entity;
using DHA.DAL.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.Repository
{
    public class CV_ContractTypeRepository : Repository<CV_ContractType>
    {
        public CV_ContractTypeRepository(Db_Context pDb_Context) : base(pDb_Context) { }//CV_ContractTypeRepository
    }//class

}
