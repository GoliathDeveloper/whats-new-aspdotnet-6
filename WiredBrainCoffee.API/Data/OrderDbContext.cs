using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.Models;
namespace WiredBrainCoffee.Api
{

    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    Description = "A coffee order",
                    PromoCode = "Wired123",
                    Created = DateTime.Now,
                    OrderNumber = 100,
                    Total = 25
                },
                new Order
                {
                    Id = 2,
                    Description = "A food order",
                    PromoCode = "Wired123",
                    Created = DateTime.Now,
                    OrderNumber = 125,
                    Total = 35
                }
            );
            
        }
    }
}
