using DHA.BUSINESS.Interface;
using DHA.BUSINESS.Result;
using DHA.DAL.Entity;
using DHA.DAL.QueryResult;

namespace DHA.BUSINESS.Service
{
    public class DOCReadService : ADALService, IDOCReadService
    {
        public List<DOC_Link> readDocLink(out BusinessResult oBusinessResult)
        {
            // Read Entities from DAL
            SelectResult oSelectResult = null;
            List<DOC_Link> __lstDOC_Link =
                MyDatabase.RepoDocSelect.select_link(out oSelectResult);
            if (!oSelectResult.IsSuccess)
            {
                oBusinessResult = new BusinessResult(oSelectResult);
                return null;
            }//if

            oBusinessResult = new BusinessResult(false);
            return __lstDOC_Link;
        }//readDocLink
    }//class
}//namespace
