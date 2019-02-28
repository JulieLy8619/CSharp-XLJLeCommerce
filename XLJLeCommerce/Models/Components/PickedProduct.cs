using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Data;

namespace XLJLeCommerce.Models.Components
{
    public class PickedProduct:ViewComponent
    {
        private CreaturesDbcontext _context;

        public PickedProduct(CreaturesDbcontext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = _context.ShoppingCartTable.OrderByDescending(a => a.ID)
                .ToList();
            return View(products);
        }

    }
}
