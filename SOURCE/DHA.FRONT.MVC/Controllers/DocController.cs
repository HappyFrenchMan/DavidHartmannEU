using DHA.BUSINESS.Interface;
using DHA.BUSINESS.Result;
using DHA.DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DHA.FRONT.MVC.Controllers
{
    public class DocController : BaseController
    {
        IDOCReadService _idocReadService;

        public DocController(IDOCReadService pIDocReadService)
        {
            _idocReadService = pIDocReadService;
        }
    

        public IActionResult Link()
        {
            SetTitrePage("Mes Liens");
            BusinessResult oBusinessResult;
            List<DOC_Link> __lstDocLink = _idocReadService.readDocLink(out oBusinessResult);
            RedirectToErrorPageIfBusinessError(oBusinessResult);

            
            return View(__lstDocLink);
        }

        public IActionResult ErrorTest()
        {
            throw new Exception();
        }

      

      
    }
}