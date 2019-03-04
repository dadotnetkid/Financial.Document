using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDTS.Web.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        [Route("error-message")]
        public ActionResult ErrorMessage()
        {
            var errorMessage = Request.Cookies["application-error"]?.Value;
            if (errorMessage == null)
                return RedirectToAction("index", "home");

            ViewBag.ErrorMessage = errorMessage;

            return PartialView();
        }
    }
}