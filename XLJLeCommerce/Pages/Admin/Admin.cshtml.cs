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
    [Authorize(Policy = "IsAdmin")]
    public class AdminModel : PageModel
    {
        private readonly IOrder _order;
        private readonly IOrderedItems _ordereditems;
        protected IAuthorizationService _AuthorizationService { get; }


        public AdminModel(IOrder order, IOrderedItems ordereditems, IAuthorizationService authorizationService)
        {
            _order = order;
            _ordereditems = ordereditems;
            _AuthorizationService = authorizationService;
        }

        public Order Order { get; set; }

        public async Task OnGet()
        {
            Order = await _order.GetAllOrder();
        }
       
    }
}