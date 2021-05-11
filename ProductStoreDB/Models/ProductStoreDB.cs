using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDB.Models
{
    public partial class ProductStoreDB : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server= LAPTOP-R6T9OC7R\SQLEXPRESS;Database=ProductStoreDB; Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ProductType>()
                .HasData(new ProductType { ProductTypeId = 1, ProductTypeName = "Vegetables" });
            modelBuilder.Entity<ProductType>()
               .HasData(new ProductType { ProductTypeId = 2, ProductTypeName = "Fruits" });
            modelBuilder.Entity<ProductType>()
              .HasData(new ProductType { ProductTypeId = 3, ProductTypeName = "Dairy" });
            modelBuilder.Entity<ProductType>()
               .HasData(new ProductType { ProductTypeId = 4, ProductTypeName = "Bakery" });
            modelBuilder.Entity<ProductType>()
             .HasData(new ProductType { ProductTypeId = 5, ProductTypeName = "Hot drinks" });
            modelBuilder.Entity<ProductType>()
            .HasData(new ProductType { ProductTypeId = 6, ProductTypeName = "Alcohol" });
            modelBuilder.Entity<ProductType>()
                .HasData(new ProductType { ProductTypeId = 7, ProductTypeName = "Snacks" });
            modelBuilder.Entity<ProductType>()
                .HasData(new ProductType { ProductTypeId = 8, ProductTypeName = "Nuts" });
            modelBuilder.Entity<ProductType>()
                .HasData(new ProductType { ProductTypeId = 9, ProductTypeName = "Sweets" });
            modelBuilder.Entity<ProductType>()
               .HasData(new ProductType { ProductTypeId = 10, ProductTypeName = "Meat" });
            modelBuilder.Entity<ProductType>()
                .HasData(new ProductType { ProductTypeId = 11, ProductTypeName = "Seafood" });
            modelBuilder.Entity<ProductType>()
               .HasData(new ProductType { ProductTypeId = 12, ProductTypeName = "Cereals" });
            
            /*

            modelBuilder.Entity<Supplier>()
                .HasData(new Supplier { SupplierID = 1, SupplierName = "Burum", ProductTypeId = 11, LogoFileName = "D:\\VUM STUDY\\1 year 2 semester\\DDS\\Assignment\\Logos\\burum.jpg" });
            modelBuilder.Entity<Supplier>()
               .HasData(new Supplier { SupplierID = 2, SupplierName = "Prostokvashino", ProductTypeId = 3 });
            */
        }
    }
}