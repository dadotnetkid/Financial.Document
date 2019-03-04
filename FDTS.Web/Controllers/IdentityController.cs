using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using FDTS.Models.Repository;
using FDTS.Models.Startup;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace FDTS.Web.Controllers
{
    public class IdentityController : Controller
    {
        public string UserId => User.Identity.GetUserId();
        public int? DepartmentId => User.Identity.GetDepartmentId();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        private UnitOfWork unitOfWork;//= new UnitOfWork();

        [Route("Logout")]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Users");
        }

        public ActionResult UsersPartial([ModelBinder(typeof(DevExpressEditorsBinder))]string userId)
        {
            ViewBag.UserId = userId;
            return PartialView("_UsersPartial", unitOfWork.UsersRepo.Fetch());
        }

    }
}
