using DHA.Models;
using DHA.EntityFrameworkCore_Models.CV.DAO;
using DHA.EntityFrameworkCore_Models.CV.Entity;
using Microsoft.AspNetCore.Mvc;
using sys_diag_act = System.Diagnostics.Activity;
using DHA.Common.Log4Net;
using Microsoft.AspNetCore.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DHA.EntityFrameworkCore_Models.DOC.DAO;
using DAH.DAL.CV.Model;
using DAH.DAL.CV.DA;


namespace DHA.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
           

            SetTitrePage("Accueil");

            
            return View();
        }//Index

        public IActionResult Training()
        {
            SetTitrePage("Mon parcours universitaire");
            return View(CVDataAdapter.readTrainingM());
        }//Formation

        public IActionResult Experiences()
        {
            SetTitrePage("Mes expériences");            
            return View(MyExperience.select_experiences());
        }//Experiences

        public IActionResult Competences()
        {
           

            SetTitrePage("Mes compétences");
            List<Tuple<string, TimeSpan, string>> __tupleSkills = MyStatistic.select_skill_by_duration();

            
            return View(__tupleSkills);
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