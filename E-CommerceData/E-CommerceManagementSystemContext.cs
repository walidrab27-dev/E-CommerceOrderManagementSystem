using E_CommerceData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceData
{
    public class E_CommerceManagementSystemContext : DbContext
    {
        private string _connectionString = @"Server=walidrab27\SQLEXPRESS;Database=E_CommerceManagementSystemDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public override int SaveChanges()
        {
            var models = ChangeTracker.Entries()
                .Where(e => e.Entity is Entities.BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach (var model in models)
            {
                var context = new ValidationContext(model.Entity);
                Validator.ValidateObject(model.Entity, context, validateAllProperties: true);
            }
            var entities = ChangeTracker.Entries<BaseEntity>();
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entity.State == EntityState.Modified)
                {
                    entity.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }  
    }
}
