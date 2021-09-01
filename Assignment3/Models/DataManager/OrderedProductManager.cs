using Assignment3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models.DataManager
{
    public class OrderedProductManager
    {
        private readonly A3Context _context;
        public OrderedProductManager(A3Context context)
        {
            _context = context;
        }

        public IEnumerable<OrderedProduct> Get(int id)
        {
            return _context.OrderedProduct.Where(o => o.OrderID == id).ToList();
        }

        public IEnumerable<OrderedProduct> GetAll()
        {
            return _context.OrderedProduct.ToList();
        }
  
    }
}
