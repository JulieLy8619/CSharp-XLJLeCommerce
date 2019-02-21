using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Controllers
{
    public class ProductController
    {
        private readonly Iproduct _context;

        public ProductController(Iproduct context)
        {
            _context = context;
        }

        //display all products on page
        public async Task<IActionResult> Index(int id)
        {
            //should un red line after next pull because Xia did the table and services
            return View(await _Products.GetAllProducts());
        }

        //display details for just one
        public async Task<IActionResult> Details(int id)
        {
            var prod = await _context.GetProduct(id);

            return View(prod);
        }

        //we won't have a create product because a a user can't add any

        //we won't have a delete product because a user can't delete any
    }
}
