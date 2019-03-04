using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace FDTS.Models.Repository
{
    public static class IdentityExtension
    {
        public static string GetFullName(this IIdentity user)
        {
            return user is ClaimsIdentity claimIdent && claimIdent.HasClaim(c => c.Type == "FullName")
                ? claimIdent.FindFirst("FullName").Value
                : string.Empty;
        }

        public static int? GetDepartmentId(this IIdentity user)
        {

            if (user is ClaimsIdentity claimIdent && claimIdent.HasClaim(c => c.Type == "DepartmentId"))
            {
                return Convert.ToInt32(claimIdent.FindFirst("DepartmentId").Value);
            }

            return null;

        }

        public static string GetEmail(this IIdentity user)
        {
            return user is ClaimsIdentity claimIdent && claimIdent.HasClaim(c => c.Type == "Email")
                ? claimIdent.FindFirst("Email").Value
                : string.Empty;
        }
        public static string GetUserRoles(this IIdentity user)
        {
            return user is ClaimsIdentity claimIdent && claimIdent.HasClaim(c => c.Type == "UserRoles")
                ? claimIdent.FindFirst("UserRoles").Value
                : string.Empty;
        }

        public static bool IsInUserRoles(this IIdentity user, params string[] userRoles)
        {
            var roles = GetUserRoles(user).Split(',');
            return roles.Any() && roles.Any(userRoles.Contains);
        }
    }
}
