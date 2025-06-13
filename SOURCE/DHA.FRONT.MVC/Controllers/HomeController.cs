using DHA.FRONT.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using sys_diag_act = System.Diagnostics.Activity;
using DHA.UTIL.Log4Net;
using Microsoft.AspNetCore.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DHA.BUSINESS.Interface;
using DHA.BUSINESS.Result;
using DHA.BUSINESS.Model;


namespace DHA.FRONT.MVC.Controllers
{
    public class HomeController : BaseController
    {
        ICVReadService _icvReadService;

        public HomeController(ICVReadService pICVReadService)
        {
            _icvReadService = pICVReadService;
        }

        public IActionResult Index()
        {
            SetTitrePage("Accueil");            
            return View();
        }//Index

        public IActionResult About()
        {
            SetTitrePage("About");            
            return View();
        }

        public IActionResult Contact()
        {
            SetTitrePage("Contact");            
            return View();
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