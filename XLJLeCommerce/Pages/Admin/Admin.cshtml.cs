using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Pages.Admin
{
    public class AdminModel : PageModel
    {
        //I think I am getting ahead of myself than this user story
        //private UserManager<ApplicationUser> _userManager;
        //private readonly IOrder _order;
        //private readonly IOrderedItems _ordereditems;
        //protected IAuthorizationService _AuthorizationService { get; }


        //public AdminModel(UserManager<ApplicationUser> userManager, IConfiguration configuration, IOrder order, IOrderedItems ordereditems, IAuthorizationService authorizationService)
        //{
        //    _userManager = userManager;
        //    _order = order;
        //    _ordereditems = ordereditems;
        //    _AuthorizationService = authorizationService;
        //}
        public void OnGet()
        {
        }
       
    }
}