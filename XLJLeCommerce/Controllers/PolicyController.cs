using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Controllers
{
    [Authorize(Policy = "Over3minOnly")]
    public class PolicyController : Controller
    {
        private readonly Iproduct _product;
        private CreaturesDbcontext _context { get; set; }

        public PolicyController(Iproduct product)
        {
            _product = product;
        }

        /// <summary>
        /// calls the index page for vip users
        /// </summary>
        /// <returns>the page</returns>
        public IActionResult Index()
        {
            return RedirectToAction("VIPProd", "Policy");
        }

        /// <summary>
        /// gets the vip page for vip users
        /// </summary>
        /// <returns>the page</returns>
        [Authorize]
        public async Task<IActionResult> VIPProd()
        {
            return View(await _product.GetAllProducts());
        }
    }
}
