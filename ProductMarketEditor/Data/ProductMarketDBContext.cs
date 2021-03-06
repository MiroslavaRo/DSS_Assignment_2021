using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductMarketEditor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMarketEditor.Data
{
    public class ProductMarketDBContext : DbContext
    {
        public ProductMarketDBContext(DbContextOptions<ProductMarketDBContext> options) : base(options)
        { }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }        
        public DbSet<User> Users { get; set; }
        public DbSet<ProductChange> ProductChanges { get; set; }
        public DbSet<SupplierChange> SupplierChanges { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =(local)\\sqlexpress; Database = ProductMarketDB; Trusted_Connection = True; MultipleActiveResultSets = True; ");
        }
        */
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
                .HasData(new Supplier { SupplierId = 1, Company = "Burum", ProductTypeId = 11, SupplierChangeId=1, ImageFile= "burum.jpg" });
            modelBuilder.Entity<Supplier>()
               .HasData(new Supplier { SupplierId = 2, Company = "Prostokvashino", ProductTypeId = 3, SupplierChangeId = 2, ImageFile = "prostokvashino.jpg" });
            modelBuilder.Entity<Supplier>()
              .HasData(new Supplier { SupplierId = 3, Company = "H&S Bakery", ProductTypeId = 4, SupplierChangeId = 3, ImageFile = "h&s bakery.jpg" });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 4, Company = "Aryzita", ProductTypeId = 4, SupplierChangeId = 4, ImageFile = "ARYZTA.jpg" });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 5, Company = "Bacardi", ProductTypeId = 6, SupplierChangeId = 5, ImageFile = "bacardi.jpg" });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 6, Company = "Corona", ProductTypeId = 6, SupplierChangeId = 6, ImageFile = "Corona.jpg" });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 7, Company = "Nescafe", ProductTypeId = 5, SupplierChangeId = 7, ImageFile = "nescafe.jpg" });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 8, Company = "Nesquik", ProductTypeId = 5, SupplierChangeId = 8, ImageFile = "nesquik.jpg" });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 9, Company = "Maruha Nichiro", ProductTypeId = 11, SupplierChangeId = 9, ImageFile = "maruhanichiro.jpg" });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 10, Company = "Dairy Pure", ProductTypeId = 3, SupplierChangeId = 10, ImageFile = "DairyPure.jpg" });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 11, Company = "Mowi", ProductTypeId = 11, SupplierChangeId = 11, ImageFile = "MOWI.jpg" });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 12, Company = "Prima", ProductTypeId = 1, SupplierChangeId = 12, ImageFile = "prima.jpg" });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 13, Company = "Prima", ProductTypeId = 2, SupplierChangeId = 13, ImageFile = "prima.jpg" });
            modelBuilder.Entity<Supplier>()
             .HasData(new Supplier { SupplierId = 14, Company = "Tyson Product", ProductTypeId = 10, SupplierChangeId = 14, ImageFile = "tysonproduct.jpg" });

            modelBuilder.Entity<SupplierChange>()
                .HasData(new SupplierChange { SupplierChangeId = 1, CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
            modelBuilder.Entity<SupplierChange>()
               .HasData(new SupplierChange { SupplierChangeId = 2, CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
            modelBuilder.Entity<SupplierChange>()
               .HasData(new SupplierChange { SupplierChangeId = 3, CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
            modelBuilder.Entity<SupplierChange>()
                .HasData(new SupplierChange { SupplierChangeId = 4, CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
            modelBuilder.Entity<SupplierChange>()
                .HasData(new SupplierChange { SupplierChangeId = 5, CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
            modelBuilder.Entity<SupplierChange>()
                 .HasData(new SupplierChange { SupplierChangeId = 6, CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
            modelBuilder.Entity<SupplierChange>()
               .HasData(new SupplierChange { SupplierChangeId = 7, CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
            modelBuilder.Entity<SupplierChange>()
               .HasData(new SupplierChange { SupplierChangeId = 8, CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
            modelBuilder.Entity<SupplierChange>()
                .HasData(new SupplierChange { SupplierChangeId = 9, CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
            modelBuilder.Entity<SupplierChange>()
                .HasData(new SupplierChange { SupplierChangeId = 10, CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
            modelBuilder.Entity<SupplierChange>()
              .HasData(new SupplierChange { SupplierChangeId = 11, CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
            modelBuilder.Entity<SupplierChange>()
               .HasData(new SupplierChange { SupplierChangeId = 12, CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
            modelBuilder.Entity<SupplierChange>()
               .HasData(new SupplierChange { SupplierChangeId = 13, CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
            modelBuilder.Entity<SupplierChange>()
                .HasData(new SupplierChange { SupplierChangeId = 14, CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
         

            modelBuilder.Entity<Product>()
             .HasData(new Product { ProductId = 1, ProductChangeId = 1, ProductName = "Prostokvashino Milk 3.2%", SupplierId = 2, ImageFileName = "1.jpg" });
            modelBuilder.Entity<Product>()
             .HasData(new Product { ProductId = 2, ProductChangeId = 2, ProductName = "Prostokvashino Cottage Cheese 5 %", SupplierId = 2, ImageFileName= "2.jpg" });
        
          
            

            modelBuilder.Entity<Role>()
            .HasData(new Role { RoleId=1, RoleName="Admin"});
            modelBuilder.Entity<Role>()
             .HasData(new Role { RoleId = 2, RoleName = "User" });


            
            modelBuilder.Entity<ProductChange>()
           .HasData(new ProductChange { ProductChangeId = 1,  CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
            modelBuilder.Entity<ProductChange>()
             .HasData(new ProductChange { ProductChangeId = 2,  CreatedBy = "LindaCole", EditedBy = "LindaCole", CreatedOn = "2021/05/20 11:30:30 AM", EditedOn = "2021/05/20 11:30:30 AM" });
            
            /*
            UserNames: Passwords 
            
             Maria98: TFgDmm  
            GrigorIus: HopeGg
            LindaCole:  pasSword   -admin
            John Blitz:  YokH
             
             */

            modelBuilder.Entity<User>()
         .HasData(new User { UserId=1, UserName= "Maria98", Password= "TFgDmm", RoleId=2});
            modelBuilder.Entity<User>()
         .HasData(new User { UserId = 2, UserName = "GrigorIus", Password = "HopeGg", RoleId = 2 });
            modelBuilder.Entity<User>()
         .HasData(new User { UserId = 3, UserName = "LindaCole", Password = "pasSword", RoleId = 1 });
            modelBuilder.Entity<User>()
         .HasData(new User { UserId = 4, UserName = "John Blitz", Password = "YokH", RoleId = 2 });

                   


        }
    }
}