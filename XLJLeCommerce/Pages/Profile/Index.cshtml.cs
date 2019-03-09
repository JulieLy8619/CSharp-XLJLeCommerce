using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XLJLeCommerce.Models;

namespace XLJLeCommerce.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager
       )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [BindProperty]
        public ApplicationUser AppUser { get; set; }

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string Address { get; set; }

        /// <summary>
        /// gets the signed in user
        /// </summary>
        /// <returns>the user</returns>
        public async Task OnGet()
        {
          AppUser= await _userManager.GetUserAsync(User);
        }

        /// <summary>
        /// updates the user's info
        /// </summary>
        /// <returns>the profile index page</returns>
        public async Task<IActionResult> OnPost()
        {
           
            var user = await _userManager.GetUserAsync(User);
          var cc=User.Claims.FirstOrDefault(c => c.Type == "FullName");
            var add = User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.StreetAddress);
            await _signInManager.UserManager.RemoveClaimAsync(user, cc);
            await _signInManager.UserManager.RemoveClaimAsync(user, add);
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Address = Address;

            await _userManager.UpdateAsync(user);
            Claim fn= new Claim("FullName", $"{user.FirstName} {user.LastName}");
            Claim adr =new Claim(ClaimTypes.StreetAddress, $"{ user.Address }");
            await _signInManager.UserManager.AddClaimAsync(user, fn);
            await _signInManager.UserManager.AddClaimAsync(user, adr);
            return RedirectToPage("/Profile/Index");
        }

    }
}