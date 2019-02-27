using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ICart _cart;
        private CreaturesDbcontext _context { get; set; }

        public CartController(ICart cart, CreaturesDbcontext context)
        {
            _context = context;
            _cart = cart;
        }

        [HttpPost]
        public async Task<IActionResult> Add([Bind("UserID,ProdID, ProdQty, TotalPrice")] Cart cart)
        {
            if (ModelState.IsValid)
            {

            }
            return RedirectToAction();


        }
    }
