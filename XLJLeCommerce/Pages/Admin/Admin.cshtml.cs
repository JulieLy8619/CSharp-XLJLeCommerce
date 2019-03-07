using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace XLJLeCommerce.Pages.Admin
{
    [AllowAnonymous]
    public class AdminModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbcontext _context;

        public OrderController(UserManager<ApplicationUser> userManager, ApplicationDbcontext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public void OnGet()
        {
        }
       
    }
}