using DHA.Config;
using Microsoft.AspNetCore.Mvc;

namespace DHA.Controllers
{
    public class BaseController : Controller
    {
 

        public void SetTitrePage(string pStrPage)
        {
            ViewData["Title"] = pStrPage;
        }
    }
}
