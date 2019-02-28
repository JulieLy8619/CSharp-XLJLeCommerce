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
    public class ProductController : Controller
    {
        private readonly Iproduct _product;
        private readonly ICart _cart;
        private readonly IShoppingCartItem _shoppingCartItem;
        private CreaturesDbcontext _context;

        public ProductController(Iproduct product, ICart cart, IShoppingCartItem shoppingCartItem, CreaturesDbcontext context)
        {
            _context = context;
            _cart = cart;
            _product = product;
            _shoppingCartItem = shoppingCartItem;
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

            var prod = await _product.GetProduct(id);
            ShoppingCartItem newCartItem = new ShoppingCartItem();
            newCartItem.CartID = 0; //have to figure out how to tell which shopping cart
            newCartItem.ProdID = prod.ID;
            newCartItem.ProdQty = 1; //we chose to default add one at cart entry and then then can update quantity on cart summary page later
            await _shoppingCartItem.CreateShoppingCartItem(newCartItem);
            return View(); //we probably actually will want to go to cart home page after we create that.
        }
    }
}
