using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models;
using XLJLeCommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace XLJLeCommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly Iproduct _product;
        private readonly ICart _cart;
        private readonly IShoppingCartItem _shoppingCartItem;
        private UserManager<ApplicationUser> _userManager;

        public ProductController(Iproduct product, ICart cart, IShoppingCartItem shoppingCartItem, UserManager<ApplicationUser> userManager)
        {
            _cart = cart;
            _product = product;
            _shoppingCartItem = shoppingCartItem;
            _userManager = userManager;
        }

        /// <summary>
        /// gets all the products to display on a page
        /// </summary>
        /// <returns>page</returns>
        public async Task<IActionResult> Index()

        {
            return View(await _product.GetAllProducts());
        }

        /// <summary>
        /// calls the details page
        /// </summary>
        /// <param name="id">id of the specific product</param>
        /// <returns>the page of the product</returns>

        public async Task<IActionResult> Details(int id)
        {
            var prod = await _product.GetProduct(id);

            return View(prod);
        }

        //we won't have a create product because a a user can't add any

        //we won't have a delete product because a user can't delete any

        /// <summary>
        /// adds a shopping cart item to the cart
        /// </summary>
        /// <param name="id">id of which product one wants to add</param>
        /// <returns>page after task completed</returns>
        public async Task<IActionResult> AddToCart(int id)
        {
            //check if have shopping cart, if not then add cart
            //added cart at registration and we said only one cart to user


            var prod = await _product.GetProduct(id);
            ShoppingCartItem newCartItem = new ShoppingCartItem();

            //find userID
            string userEmail = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user != null)
            {
                string userID = user.Id;
                //int userIDNum = Convert.ToInt32(userID);

                //so can find their carts
                Cart cartObj = await _cart.GetCart(userID);

                //set item to cart
                newCartItem.CartID = cartObj.ID;
                newCartItem.ProductID = prod.ID;
                newCartItem.ProdQty = 1; //we chose to default add one at cart entry and then then can update quantity on cart summary page later
                await _shoppingCartItem.CreateShoppingCartItem(newCartItem);
                return RedirectToAction("Index", "Cart"); 
            }
            else //user not in DB
            {
                return RedirectToAction("Register", "Account");
            }
        }
    }
}
