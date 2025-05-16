using DHA.FRONT.MVC.Config;
using Microsoft.AspNetCore.Mvc;

namespace DHA.FRONT.MVC.Controllers
{
    public class BaseController : Controller
    {
 

        public void SetTitrePage(string pStrPage)
        {
            ViewData["Title"] = pStrPage;
        }
    }
}
