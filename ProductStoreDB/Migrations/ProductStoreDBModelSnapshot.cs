﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductStoreDB.Models;

namespace ProductStoreDB.Migrations
{
    [DbContext(typeof(ProductStoreDB))]
    partial class ProductStoreDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductStoreDB.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ProductStoreDB.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhotoFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductStoreDB.Models.ProductType", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductTypeId");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            ProductTypeId = 1,
                            ProductTypeName = "Vegetables"
                        },
                        new
                        {
                            ProductTypeId = 2,
                            ProductTypeName = "Fruits"
                        },
                        new
                        {
                            ProductTypeId = 3,
                            ProductTypeName = "Dairy"
                        },
                        new
                        {
                            ProductTypeId = 4,
                            ProductTypeName = "Bakery"
                        },
                        new
                        {
                            ProductTypeId = 5,
                            ProductTypeName = "Hot drinks"
                        },
                        new
                        {
                            ProductTypeId = 6,
                            ProductTypeName = "Alcohol"
                        },
                        new
                        {
                            ProductTypeId = 7,
                            ProductTypeName = "Snacks"
                        },
                        new
                        {
                            ProductTypeId = 8,
                            ProductTypeName = "Nuts"
                        },
                        new
                        {
                            ProductTypeId = 9,
                            ProductTypeName = "Sweets"
                        },
                        new
                        {
                            ProductTypeId = 10,
                            ProductTypeName = "Meat"
                        },
                        new
                        {
                            ProductTypeId = 11,
                            ProductTypeName = "Seafood"
                        },
                        new
                        {
                            ProductTypeId = 12,
                            ProductTypeName = "Cereals"
                        });
                });

            modelBuilder.Entity("ProductStoreDB.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("SupplierId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ProductStoreDB.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProductStoreDB.Models.Product", b =>
                {
                    b.HasOne("ProductStoreDB.Models.ProductType", null)
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductStoreDB.Models.Supplier", null)
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductStoreDB.Models.Supplier", b =>
                {
                    b.HasOne("ProductStoreDB.Models.ProductType", null)
                        .WithMany("Suppliers")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductStoreDB.Models.User", b =>
                {
                    b.HasOne("ProductStoreDB.Models.Employee", null)
                        .WithMany("Users")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductStoreDB.Models.Employee", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ProductStoreDB.Models.ProductType", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("ProductStoreDB.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}