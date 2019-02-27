using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ICart _cart;
        private CreaturesDbcontext _context { get; set; }

        public CartController(ICart cart, CreaturesDbcontext context)
        {
            _context = context;
            _cart = cart;
        }

        /// <summary>
        /// adds a cart
        /// </summary>
        /// <param name="cart">the cart</param>
        /// <returns>page</returns>
        [HttpPost]
        public async Task<IActionResult> AddCart([Bind("UserID, ProdID, ProdQty, TotalPrice")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                await _cart.Create(cart);
                return RedirectToPage("Details", "Product"); //022719JL- this may change where it redirects to after all, prolly page that displays all items in cart
            }
            return View(cart);

        }
    }
}
