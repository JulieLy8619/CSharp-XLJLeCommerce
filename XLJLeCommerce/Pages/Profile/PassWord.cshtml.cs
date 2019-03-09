using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XLJLeCommerce.Models;

namespace XLJLeCommerce.Pages.Profile
{
    public class PassWordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public PassWordModel(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string CurrPassword { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation do not match")]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public async Task OnGet()
        {
            ApplicationUser = await _userManager.GetUserAsync(User);
        }

        public async Task<IActionResult> OnPost()
        {
            ApplicationUser = await _userManager.GetUserAsync(User);
            await _userManager.ChangePasswordAsync(ApplicationUser, CurrPassword, Password);



            return RedirectToPage("/Profile/Index");
        }
    }
}