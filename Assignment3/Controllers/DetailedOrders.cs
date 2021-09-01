using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class DetailedOrders : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
