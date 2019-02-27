using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ICart _context;

        public CartController(ICart context)
        {
            _context = context;
        }

    }
}
