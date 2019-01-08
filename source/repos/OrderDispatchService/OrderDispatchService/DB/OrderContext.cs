using Microsoft.EntityFrameworkCore;
using OrderDispatchService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OrderDispatchService.DB.OrderContext;

namespace OrderDispatchService.DB
{

    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) :base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Order");
        }
    }
}
