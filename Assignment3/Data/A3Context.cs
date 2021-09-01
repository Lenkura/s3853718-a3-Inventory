using Assignment3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Data
{
    public class A3Context: DbContext
    {
        public A3Context(DbContextOptions<A3Context> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderedProduct> OrderedProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Set check constraints (cannot be expressed with data annotations).
            builder.Entity<OrderedProduct>().HasKey("OrderID");
            builder.Entity<OrderedProduct>().HasKey("ProductID");
        }
    }
}
