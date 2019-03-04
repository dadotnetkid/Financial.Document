using System;
using System.Collections.Generic;
using System.Text;

namespace FDTS.Mobile.Services
{
    public class IdentityResult
    {
        public bool isSucceed { get; set; }
    }



    public class JwtModel
    {
        public string Token { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public Users Users { get; set; }
        public IdentityResult IdentityResult { get; set; }
    }

    public class Users
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => this.FirstName ?? "" + " " + this.LastName ?? "";



    }
}
