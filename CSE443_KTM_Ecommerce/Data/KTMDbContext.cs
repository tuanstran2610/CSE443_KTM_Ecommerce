using CSE443_KTM_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CSE443_KTM_Ecommerce.Data
{
    public class KTMDbContext : DbContext

    {

        public KTMDbContext(DbContextOptions<KTMDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and other settings here if needed
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(
               new Role {  Id=1, Name="CUSTOMER"},
               new Role { Id=2, Name ="ADMIN"},
               new Role { Id=3, Name="MANAGER"});

            modelBuilder.Entity<Delivery>().HasData(
                new Delivery {Id=1, Name = "Standard Delivery", Description = "Delivered in 3–5 days", DeliveryFees = 2.99M },
                new Delivery {Id=2, Name = "Express Delivery", Description = "Delivered in 1–2 days", DeliveryFees = 5.99M },
               new Delivery {Id=3, Name = "Pickup In-Store", Description = "Pick up from store for free", DeliveryFees = 1.02M });

            modelBuilder.Entity<ProductImage>().HasData(    
                
            );
        }

    }
}
