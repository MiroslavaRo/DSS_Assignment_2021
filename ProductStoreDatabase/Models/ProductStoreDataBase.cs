using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDatabase.Models
{
    public partial class ProductStoreDataBase : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }        
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server= LAPTOP-R6T9OC7R\SQLEXPRESS;Database=ProductStoreDataBase; Trusted_Connection=True");
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


            
            modelBuilder.Entity<Supplier>()
                .HasData(new Supplier { SupplierId = 1, Company = "Burum", ProductTypeId = 11});
            modelBuilder.Entity<Supplier>()
               .HasData(new Supplier { SupplierId = 2, Company = "Prostokvashino", ProductTypeId = 3 });
            modelBuilder.Entity<Supplier>()
              .HasData(new Supplier { SupplierId = 3, Company = "H&S Bakery", ProductTypeId = 4 });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 4, Company = "Aryzita", ProductTypeId = 4 });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 5, Company = "Bacardi", ProductTypeId = 6 });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 6, Company = "Corona", ProductTypeId = 6 });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 7, Company = "Nescafe", ProductTypeId = 5 });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 8, Company = "Nesquik", ProductTypeId = 5 });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 9, Company = "Maruha Nichiro", ProductTypeId = 11 });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 10, Company = "Dairy Pure", ProductTypeId = 3 });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 11, Company = "Mowi", ProductTypeId = 11 });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 12, Company = "Prima", ProductTypeId = 1 });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 13, Company = "Prima", ProductTypeId = 2 });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 14, Company = "Tyson Product", ProductTypeId = 10 });


            
            modelBuilder.Entity<Product>()
             .HasData(new Product { ProductId = 1, ProductName = "Prostokvashino Milk 3.2%", SupplierId = 2});
            modelBuilder.Entity<Product>()
             .HasData(new Product { ProductId = 2, ProductName = "Prostokvashino Cottage Cheese 5 %", SupplierId = 2});
            



        }
    }
}