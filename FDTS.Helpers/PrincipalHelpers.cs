﻿using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using FDTS.Models.Repository;
using Microsoft.AspNet.Identity;

namespace FDTS.Helpers
{
    public static class PrincipalHelpers
    {


       

        public static bool IsInRoles(this IPrincipal principal, params string[] roles)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var userId = principal.Identity.GetUserId();
            var user = unitOfWork.UsersRepo.Find(m => m.Id == userId);
            if (principal == null)
                return false;
            if (user == null)
                return false;
            if (string.IsNullOrEmpty(userId))
                return false;
            return user.UserRoles.Any(m => roles.Contains(m.Name));
        }

        public static bool UserIsInRoles(string userId, params string[] roles)
        {
            UnitOfWork unitOfWork = new UnitOfWork();

            var user = unitOfWork.UsersRepo.Find(m => m.Id == userId);

            if (user == null)
                return false;
            if (string.IsNullOrEmpty(userId))
                return false;
            return user.UserRoles.Any(m => roles.Contains(m.Name));
        }
    }
}
