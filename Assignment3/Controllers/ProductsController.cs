﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment3.Data;
using Assignment3.Models;

namespace Assignment3.Controllers
{
    public class ProductsController : Controller
    {
        private readonly A3Context _context;

        public ProductsController(A3Context context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Name,Price")] Product product)
        {
            if (!IsDollarAmount(product.Price.ToString()))
                ModelState.AddModelError(nameof(product.Price), "Enter a dollar amount");

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id);
        }

        public bool IsDollarAmount(string s)
        {
            if (s.Contains("."))
            {
                if (s.Substring(s.IndexOf(".") + 1).Length < 3)
                    return true;
                else return false;
            }

            if (double.TryParse(s, out _) && Convert.ToDouble(s) > 0)
                return true;
            else
                return false;
        }
    }
}
