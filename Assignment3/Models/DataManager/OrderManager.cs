using Assignment3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models.DataManager
{
    public class OrderManager
    {
        private readonly A3Context _context;
        public OrderManager(A3Context context)
        {
            _context = context;
        }

        public Order Get(int id)
        {
            return _context.Order.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Order.ToList();
        }
  
    }
}
