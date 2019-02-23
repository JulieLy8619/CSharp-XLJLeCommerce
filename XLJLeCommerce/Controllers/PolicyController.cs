﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Data;
using XLJLeCommerce.Models.Interfaces;

namespace XLJLeCommerce.Controllers
{
    public class PolicyController : Controller
    {
        private readonly Iproduct _product;
        private CreaturesDbcontext _context { get; set; }

        public PolicyController(Iproduct product)
        {
            _product = product;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> VIPProd()
        {
            return View(await _product.GetAllProducts());
        }
    }
}
