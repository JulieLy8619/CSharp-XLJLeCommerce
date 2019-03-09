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

        public async Task OnGet()
        {
          AppUser= await _userManager.GetUserAsync(User);
        }

        public async Task<IActionResult> OnPost()
        {
           
            var user = await _userManager.GetUserAsync(User);
          var cc=User.Claims.FirstOrDefault(c => c.Type == "FullName");
            await _signInManager.UserManager.RemoveClaimAsync(user, cc);
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Address = Address;

            await _userManager.UpdateAsync(user);
            Claim fn= new Claim("FullName", $"{user.FirstName} {user.LastName}");
           await _signInManager.UserManager.AddClaimAsync(user, fn);
            return RedirectToPage("/Profile/Index");
        }

    }
}