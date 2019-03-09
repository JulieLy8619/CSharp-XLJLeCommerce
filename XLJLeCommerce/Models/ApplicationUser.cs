using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime RegisteredDate { get; set; }
    }
    /// <summary>
    /// define two roles here
    /// </summary>
    public static class ApplicationRoles
    {
        public const string Admin = "Admin";
        public const string Member = "Member";
    }
}
