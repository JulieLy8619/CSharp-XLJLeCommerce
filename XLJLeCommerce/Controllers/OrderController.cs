using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Controllers
{
    public class OrderController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private CreaturesDbcontext _context;

        public OrderController(UserManager<ApplicationUser> userManager, CreaturesDbcontext context)
        {
            _userManager = userManager;
            _context = context;
        }
        /// <summary>
        /// find what user it is now, and find the user's order with the email
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            string userEmail = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user != null)
            {
                string userID = user.Id;
                //await _order.GetOrder(userID);
                var res = _context.OrderTable.Where(o => o.UserID == userID);
                return View(res);
            }

            return View();
        }
    }
}