using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XLJLeCommerce.Models;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Pages.Admin
{
    public class ProductdetailModel : PageModel
    {
        private readonly Iproduct _product;
        public ProductdetailModel(Iproduct product)
        {
            _product = product;
        }

        [FromRoute]
        public int ID { get; set; }

        public Product Product { get; set; }

        /// <summary>
        /// get that specific product by ID
        /// </summary>
        /// <returns>the product</returns>
        public async Task OnGet()
        {

            Product = await _product.GetProduct(ID);
        }
    }
}