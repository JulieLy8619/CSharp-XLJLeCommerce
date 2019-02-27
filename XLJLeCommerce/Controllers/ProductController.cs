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
        private CreaturesDbcontext _context;

        public ProductController(Iproduct product, ICart cart, CreaturesDbcontext context)
        {
            _context = context;
            _cart = cart;
            _product = product;
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
        /// gets the details of a specific product
        /// </summary>
        /// <param name="id">id of specific product</param>
        /// <returns>details page</returns>
        public async Task<IActionResult> Details(int id)
        {
            var prod = await _product.GetProduct(id);

            return View(prod);
        }

        //we won't have a create product because a a user can't add any

        //we won't have a delete product because a user can't delete any

        [HttpPost]
        public async Task<IActionResult> AddtoCart([Bind("ID, Name, Sku, Price, Description, ImageURL, VIPItem")] Product product)
        {
            product.CartID = await _context.Carts.Where(p => p.ProdID == product.ID)
                                                .Select(c => c.ID)
                                                .FirstOrDefaultAsync();
            await _product.Create(product);
            return RedirectToAction("Index", "Cart");

        }
    }
}
