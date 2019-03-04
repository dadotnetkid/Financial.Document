using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FDTS.Models.Startup;
using Microsoft.AspNet.Identity;

namespace FDTS.Models
{

    public partial class Users : IUser<string>
    {

        public virtual string FullName => FirstName + " " + LastName;


        public string _UserRole
        {
            get
            {


                return string.Join(",", this.UserRoles.Select(m => m.Name));

            }
        }
        public string userRole { get; set; }
        public string Password { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Users, string> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("FullName", this.FullName));
            userIdentity.AddClaim(new Claim("Email", this.Email));
            userIdentity.AddClaim(new Claim("UserRoles", this._UserRole));
            userIdentity.AddClaim(new Claim("DepartmentId", this.DepartmentId.ToString()));
            return userIdentity;
        }

       
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("FullName", this.FullName));
            userIdentity.AddClaim(new Claim("Email", this.Email));
            userIdentity.AddClaim(new Claim("UserRoles", this._UserRole));
            userIdentity.AddClaim(new Claim("DepartmentId", this.DepartmentId.ToString()));
            return userIdentity;
        }
    }

    public partial class Users
    {
    }

}