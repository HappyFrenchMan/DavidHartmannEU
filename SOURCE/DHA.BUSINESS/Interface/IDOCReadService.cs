using DHA.BUSINESS.Model;
using DHA.BUSINESS.Result;
using DHA.DAL.Entity;

namespace DHA.BUSINESS.Interface
{
    public interface IDOCReadService
    {
        List<DOC_Link> readDocLink(out BusinessResult oBusinessResult);
    }
}
