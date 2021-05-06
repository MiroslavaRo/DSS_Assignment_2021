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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = LAPTOP-R6T9OC7R\SQLEXPRESS; Database = BookStoreDB; Trusted_Connection = True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
        
        }
    }
}
