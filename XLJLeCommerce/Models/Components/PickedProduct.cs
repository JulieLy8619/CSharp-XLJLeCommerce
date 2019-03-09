using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Models.Components
{
    public class PickedProduct:ViewComponent
    {
        private readonly ICart _cart;
        private readonly IShoppingCartItem _shoppingCartItem;
        private UserManager<ApplicationUser> _userManager;
        private CreaturesDbcontext _context { get; set; }

        public PickedProduct(ICart cart, IShoppingCartItem shoppingCartItem, UserManager<ApplicationUser> userManager, CreaturesDbcontext context)
        {
            _context = context;
            _cart = cart;
            _userManager = userManager;
            _shoppingCartItem = shoppingCartItem;
        }
        /// <summary>
        /// invoke the viewcomponents action here, using the useremail to find the user and find user's cart and get all the items in the cart,show them on the page
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            if (User.Identity.Name != null)
            {
                string userEmail = User.Identity.Name;
                var user = await _userManager.FindByEmailAsync(userEmail);

                string userID = user.Id;
                var cart = _context.Carts.FirstOrDefault(i => i.UserID == userID);
                              
                var pro = await _shoppingCartItem.GetAllShoppingCartItems(cart.ID);
                return View(pro);
                
            }
            else {
                return View();
            }
        }

    }
}
