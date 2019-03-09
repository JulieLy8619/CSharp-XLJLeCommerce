using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using XLJLeCommerce.Models;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Pages.Admin
{
    public class ManageModel : PageModel
    {
        private readonly Iproduct _product;
        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public Product Product { get; set; }

        public ManageModel(Iproduct product, IConfiguration configuration)
        {
            _product= product;

        }
        /// <summary>
        /// get the product with the ID, if not exsits create a new one
        /// </summary>
        /// <returns></returns>
        public async Task OnGet()
        {
            Product = await _product.GetProduct(ID.GetValueOrDefault()) ?? new Product();
        }

        /// <summary>
        /// update the product
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            
            var pro = await _product.GetProduct(ID.GetValueOrDefault()) ?? new Product();

            // set the data from the database to the new data from admin input
            pro.Name = Product.Name;
            pro.ImageURL = Product.ImageURL;
            pro.Price = Product.Price;
            pro.Sku = Product.Sku;

            // Save the product in the database
            await _product.UpdateProduct(pro);

            return RedirectToPage("Admin", new { id = pro.ID });
        }
        /// <summary>
        /// delete the product
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDelete()
        {
            await _product.DeleteProduct(ID.Value);
            return RedirectToPage("Admin");
        }

    }
}