using System;
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
    public class OrderedProductsController : Controller
    {
        private readonly A3Context _context;

        public OrderedProductsController(A3Context context)
        {
            _context = context;
        }

        // GET: OrderedProducts
        public async Task<IActionResult> Index(string searchString) 
        {
            var a3Context = from o in _context.OrderedProduct
                            select o;

            if (!String.IsNullOrEmpty(searchString))
            {
                a3Context = a3Context.Where(n => n.Product.Name.Contains(searchString));
            }

            return View(await a3Context.ToListAsync());
        }
    }
}
