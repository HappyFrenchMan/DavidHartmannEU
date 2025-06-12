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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string ErrorMessage)
        {
            // \Views\Shared\Error.cshtml
            var pathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            Exception? exception = pathFeature?.Error; // Here will be the exception details.

            if (exception != null)
            {
                sLog4NetLogger.Error("Error in Business Layer : "+ ErrorMessage);
            }

            return View(new ErrorViewModel { RequestId = sys_diag_act.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // \Views\Shared\Error.cshtml
            var pathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            Exception? exception = pathFeature?.Error; // Here will be the exception details.

            if (exception != null)
            {
                sLog4NetLogger.Error("APP_CRASH Exception not expected ! Catched in Error Page !", exception);
            }

            return View(new ErrorViewModel { RequestId = sys_diag_act.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}