using Assignment3.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<A3Context>();
            if (context.Product.Any())
                return;

            Product widget = new()
            {
                Name = "Widgets",
                Price = 12.50M,
            };
            Product thingymajig = new()
            {
                Name = "Thingymajig",
                Price = 5,
            };
            Product sprockets = new()
            {
                Name = "Sprockets",
                Price = 2.50M,
            };
            Product contraption = new()
            {
                Name = "Contraption",
                Price = 10,
            };

            context.Product.AddRange(widget, thingymajig, sprockets, contraption);

            const string format = "dd/MM/yyyy hh:mm:ss tt";

            Order order1 = new()
            {
                OrderDate = DateTime.ParseExact("25/08/2021 01:00:00 PM", format, null),
                CustomerName = "Bob Roberts",
                DeliveryAddress = "123 Here St Melbourne",
                DeliveredDate = DateTime.ParseExact("01/09/2021 03:45:00 PM", format, null)
            };
            Order order2 = new()
            {
                OrderDate = DateTime.ParseExact("01/09/2021 04:00:00 PM", format, null),
                CustomerName = "Polly Polaroid",
                DeliveryAddress = "987 There St Melbourne"  
            };

            context.Order.AddRange(order1, order2);

            context.OrderedProduct.AddRange(
                new OrderedProduct
                {
                    Order = order1,
                    Product = widget,
                    Quantity = 10,
                },
                new OrderedProduct
                {
                    Order = order1,
                    Product = contraption,
                    Quantity = 1,
                },
                new OrderedProduct
                {
                    Order = order2,
                    Product = sprockets,
                    Quantity = 3,
                },
                 new OrderedProduct
                 {
                     Order = order2,
                     Product = thingymajig,
                     Quantity = 2,
                 }
                );
            context.SaveChanges();
        }
    }
}
