using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        public async Task OnGet()
        {
          AppUser= await _userManager.GetUserAsync(User);

        }

    }
}