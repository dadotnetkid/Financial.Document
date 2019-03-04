using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using FDTS.Models;
using FDTS.Models.Repository;
using FDTS.Models.Startup;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
namespace FDTS.Web.Controllers
{
    public class AuthenticationController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.Request.GetOwinContext().Get<ApplicationSignInManager>();
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
                return _userManager ?? HttpContext.Current.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        [Route("login-barcode/{id?}")]
        public async Task<IHttpActionResult> Get(int? Id)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var user = unitOfWork.UsersRepo.Find(m => m.EmployeeId == Id);

            if (user == null)
                return Ok();


            var handler = new JwtSecurityTokenHandler();

            var claims = new Claim[] { new Claim(JwtRegisteredClaimNames.Sub, user.Id), new Claim("UserName", user.UserName), new Claim("UserId", user.Id), new Claim("FullName", user.FullName), new Claim("DepartmentId", user.DepartmentId.ToString()) };
            var token = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                Audience = Startup.EnvironmentVariables.Website,
                Issuer = Startup.EnvironmentVariables.Website,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Startup.EnvironmentVariables.SigningKey)), SecurityAlgorithms.HmacSha256)
            });
            var signedAndEncodedToken = handler.WriteToken(token);

            return Ok(new
            {
                Token = signedAndEncodedToken,
                ValidFrom = token.ValidFrom,
                ValidTo = token.ValidTo,
                Users = new
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = user.Id,
                    Departmentid = user.DepartmentId,
                    UserName = user.UserName,
                    Email = user.Email,
                    EmployeeId = user.EmployeeId,

                },
                IdentityResult = new
                {
                    isSuccess = user != null ? 1 : 0
                }

            });
        }
    }
}
