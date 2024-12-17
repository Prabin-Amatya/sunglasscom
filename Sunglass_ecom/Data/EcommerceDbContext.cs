using Sunglass_ecom.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Data;

namespace Sunglass_ecom.Data
{


    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext()
        {
        }

        // Constructor for dependency injection
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
            : base(options) { }

        // DbSet for each table
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<Product>()
                .HasMany(o => o.OrderItems)
                .WithOne(p => p.Product)
                .HasForeignKey(q => q.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Product)
            .HasForeignKey(q => q.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
             .HasOne(p => p.Cart)
             .WithOne(c => c.User)
             .HasForeignKey<User>(q => q.cartId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cart>()
            .HasMany(p => p.OrderItems)
            .WithOne(c => c.Cart)
            .HasForeignKey(q => q.CartId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
    
}

          
    



