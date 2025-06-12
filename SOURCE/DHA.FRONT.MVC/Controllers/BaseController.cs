using DHA.BUSINESS.Result;
using Microsoft.AspNetCore.Mvc;

namespace DHA.FRONT.MVC.Controllers
{
    public class BaseController : Controller
    {
 

        public void SetTitrePage(string pStrPage)
        {
            ViewData["Title"] = pStrPage;
        }

        protected void RedirectToErrorPageIfBusinessError(BusinessResult pBusinessResult)
        {
            if (pBusinessResult != null)
            {
                if (!pBusinessResult.IsSuccess)
                {
                    Response.Redirect("Error?message=Error in Business Layer :");
                }
            }
        }
    }
}
