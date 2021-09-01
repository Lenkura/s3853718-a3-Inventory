using Assignment3.Models;
using Assignment3.Models.DataManager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderedProductsController : ControllerBase
    {
        private readonly OrderedProductManager _repo;

        public OrderedProductsController(OrderedProductManager repo)
        {
            _repo = repo;
        }

        // GET: api/OrderedProducts
        [HttpGet]
        public IEnumerable<OrderedProduct> Get()
        {
            return _repo.GetAll();
        }

        // GET api/OrderedProducts/1
        // Returns all OrderedProducts with a specific Order ID
        [HttpGet("{id}")]
        public IEnumerable<OrderedProduct> Get(int id)
        {
            return _repo.Get(id);
        }
    }
}
