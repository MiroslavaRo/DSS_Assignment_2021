using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProductStoreEditor.Models
{
    public partial class ProductStoreDbContext : DbContext
    {
        public ProductStoreDbContext()
        {
        }

        public ProductStoreDbContext(DbContextOptions<ProductStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server= LAPTOP-R6T9OC7R\\SQLEXPRESS;Database=ProductStoreDb; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.SupplierId, "IX_Products_SupplierId");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasIndex(e => e.ProductTypeId, "IX_Suppliers_ProductTypeId");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.ProductTypeId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId, "IX_Users_EmployeeId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.EmployeeId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
