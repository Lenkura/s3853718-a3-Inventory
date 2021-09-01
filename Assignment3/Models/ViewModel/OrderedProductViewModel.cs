using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models.ViewModel
{
    public class OrderedProductViewModel
    {
        public List<OrderedProduct> OrderedProductsList { get; set; }
        public List<SelectListItem> ProductList { get; set; }
    }
}
