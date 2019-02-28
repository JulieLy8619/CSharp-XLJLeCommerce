using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IShoppingCartItem _shoppingCartItem;
        private UserManager<ApplicationUser> _userManager;
        private CreaturesDbcontext _context { get; set; }

        public CartController(ICart cart, IShoppingCartItem shoppingCartItem, UserManager<ApplicationUser> userManager, CreaturesDbcontext context)
        {
            _context = context;
            _cart = cart;
            _userManager = userManager;
            _shoppingCartItem = shoppingCartItem;
        }

        public async Task<IActionResult> Index()

        {
            //find userID
            string userEmail = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user != null)
            {
                string userID = user.Id;
                //int userIDNum = Convert.ToInt32(userID);

                //so can find their carts
                var cartid = await _context.Carts.FirstOrDefaultAsync(i => i.UserID == userID);
                return View(await _shoppingCartItem.GetAllShoppingCartItems(cartid));
            }
            else //user not in DB
            {
                //should we redirect to log in or register?
                return RedirectToAction("Register", "Account");
            }

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
