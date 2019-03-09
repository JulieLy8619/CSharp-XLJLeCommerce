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

        /// <summary>
        /// access to other tables
        /// </summary>
        /// <param name="order">order table</param>
        /// <param name="ordereditems">ordereditems tables</param>
        /// <param name="authorizationService">roles table</param>
        public AdminModel(IOrder order, IOrderedItems ordereditems, IAuthorizationService authorizationService)
        {
            _order = order;
            _ordereditems = ordereditems;
            _AuthorizationService = authorizationService;
        }
        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public List<Order> Order { get; set; }

        /// <summary>
        /// gets last 10 orders of site
        /// </summary>
        /// <returns>the last 10 orders of the site</returns>
        public async Task OnGet()
        {
            Order = await _order.GetLastTenOrder(); 
        }
       
    }
}