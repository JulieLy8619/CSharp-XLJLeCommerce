using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using XLJLeCommerce.Models;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrder _order;
        private readonly IShoppingCartItem _shoppingCartItem;
        private readonly ICart _cart;
        private readonly IOrderedItems _ordereditems;
        private UserManager<ApplicationUser> _userManager;

        public CheckoutController(ICart cart, IShoppingCartItem shoppingCartItem, IOrder order, UserManager<ApplicationUser> userManager, IOrderedItems ordereditems)
        {
            _ordereditems = ordereditems;
            _cart = cart;
            _order = order;
            _shoppingCartItem = shoppingCartItem;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Receipt()
        {
            //get user ID
            string userEmail = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userEmail);
            string userID = user.Id;

            //create order
            Order ord = new Order();
            ord.UserID = userID;
            await _order.CreateOrder(ord);

            //move all shopping items in cart to order items
                //find their carts
            Cart cartObj = await _cart.GetCart(userID);
                //get all the items in the cart
            IEnumerable<ShoppingCartItem> cartitems = await _shoppingCartItem.GetAllShoppingCartItems(cartObj.ID);
                //convert it to orderitem
            foreach (var item in cartitems)
            {
                OrderedItems tempOrdItem = new OrderedItems();
                tempOrdItem.OrderID = ord.ID;
                tempOrdItem.ShoppingCartItemID = item.ID;
                await _ordereditems.CreateOrderedItem(tempOrdItem);
                //then delete it from shopping cart or wait to do this when we pay
            }

            return View();
        }
    }
}
