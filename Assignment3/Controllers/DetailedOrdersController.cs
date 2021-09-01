using Assignment3.Models;
using Assignment3.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class DetailedOrdersController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient Client => _clientFactory.CreateClient();

        public DetailedOrdersController(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<IActionResult> Index()
        {
            var response = await Client.GetAsync("api/Orders");

            if (!response.IsSuccessStatusCode)
                throw new Exception();
            var result = await response.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<List<Order>>(result);

            List<DetailedOrderViewModel> detailedorders = new();

            foreach (var o in orders)
            {
                response = await Client.GetAsync($"api/OrderedProducts/{o.OrderID}");
                if (!response.IsSuccessStatusCode)
                    throw new Exception();
                result = await response.Content.ReadAsStringAsync();
                var orderedProducts = JsonConvert.DeserializeObject<List<OrderedProduct>>(result);
                int productTotal = 0;
                foreach (var p in orderedProducts)
                    productTotal += p.Quantity;
                detailedorders.Add
                    (
                    new DetailedOrderViewModel
                    {
                        OrderDate = o.OrderDate,
                        CustomerName = o.CustomerName,
                        DeliveryAddress = o.DeliveryAddress,
                        DeliveredDate = o.DeliveredDate,
                        TotalProducts = productTotal
                    }
                    );
            }

            return View(detailedorders);
        }
    }
}
