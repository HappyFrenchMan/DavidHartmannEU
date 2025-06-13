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
    public class CVController : BaseController
    {
        ICVReadService _icvReadService;

        public CVController(ICVReadService pICVReadService)
        {
            _icvReadService = pICVReadService;
        }
        
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

    }
}