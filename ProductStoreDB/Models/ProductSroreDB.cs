using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDB.Models
{
   public partial class ProductSroreDB : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server= LAPTOP-R6T9OC7R\SQLEXPRESS;Database=ProductSroreDB; Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
        
        }
    }
}
