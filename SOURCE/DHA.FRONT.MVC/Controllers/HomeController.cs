using DHA.DAL.CV.Model;
using DHA.DAL.CV.DAO;
using DHA.DAL.CV.Entity;
using DHA.FRONT.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using sys_diag_act = System.Diagnostics.Activity;
using DHA.UTIL.Log4Net;
using Microsoft.AspNetCore.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DHA.DAL.DOC.DAO;
using DHA.DAL.CV.DA;
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

        public IActionResult Training()
        {
            BusinessResult oBusinessResult;
            List<TrainingBM> trainingBMs = _icvReadService.readTrainingM(out oBusinessResult);
            RedirectToErrorPageIfBusinessError(oBusinessResult);
            

            SetTitrePage("Mon parcours universitaire");
            return View(trainingBMs);
        }//Formation

        public IActionResult Experience()
        {
            BusinessResult oBusinessResult;
            List<ExperienceBM> experienceBMs = _icvReadService.readExperienceM(out oBusinessResult);
            RedirectToErrorPageIfBusinessError(oBusinessResult);

            SetTitrePage("Mes expériences");            
            return View(experienceBMs);
        }//Experiences

        public IActionResult Skill()
        {
            BusinessResult oBusinessResult;
            List<SkillStatBM> skillStatBMs = _icvReadService.readSkillStatM(out oBusinessResult);
            RedirectToErrorPageIfBusinessError(oBusinessResult);

            SetTitrePage("Mes compétences");            
            return View(skillStatBMs);
        }//Competences

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

        public IActionResult Link()
        {
            SetTitrePage("Mes Liens");            
            return View(MyLinks.select_all_link());
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