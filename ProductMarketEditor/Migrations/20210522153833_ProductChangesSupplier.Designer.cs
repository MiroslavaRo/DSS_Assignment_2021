﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductMarketEditor.Data;

namespace ProductMarketEditor.Migrations
{
    [DbContext(typeof(ProductMarketDBContext))]
    [Migration("20210522153833_ProductChangesSupplier")]
    partial class ProductChangesSupplier
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductMarketEditor.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductChangeId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductChangeId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ImageFileName = "1.jpg",
                            ProductChangeId = 1,
                            ProductName = "Prostokvashino Milk 3.2%",
                            SupplierId = 2
                        },
                        new
                        {
                            ProductId = 2,
                            ImageFileName = "2.jpg",
                            ProductChangeId = 2,
                            ProductName = "Prostokvashino Cottage Cheese 5 %",
                            SupplierId = 2
                        });
                });

            modelBuilder.Entity("ProductMarketEditor.Models.ProductChange", b =>
                {
                    b.Property<int>("ProductChangeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedOn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EditedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EditedOn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductChangeId");

                    b.ToTable("ProductChanges");

                    b.HasData(
                        new
                        {
                            ProductChangeId = 1,
                            CreatedBy = "LindaCole",
                            CreatedOn = "20/05/2021 23:30",
                            EditedBy = "LindaCole",
                            EditedOn = "20/05/2021 23:30"
                        },
                        new
                        {
                            ProductChangeId = 2,
                            CreatedBy = "LindaCole",
                            CreatedOn = "20/05/2021 23:30",
                            EditedBy = "LindaCole",
                            EditedOn = "20/05/2021 23:30"
                        });
                });

            modelBuilder.Entity("ProductMarketEditor.Models.ProductPhoto", b =>
                {
                    b.Property<int>("ProductPhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductPhotoId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPhotos");

                    b.HasData(
                        new
                        {
                            ProductPhotoId = 1,
                            FileName = "1.jpg",
                            ProductId = 1
                        },
                        new
                        {
                            ProductPhotoId = 2,
                            FileName = "2.jpg",
                            ProductId = 2
                        });
                });

            modelBuilder.Entity("ProductMarketEditor.Models.ProductType", b =>
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

            modelBuilder.Entity("ProductMarketEditor.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("ProductMarketEditor.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("SupplierId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SupplierId = 1,
                            Company = "Burum",
                            ProductTypeId = 11
                        },
                        new
                        {
                            SupplierId = 2,
                            Company = "Prostokvashino",
                            ProductTypeId = 3
                        },
                        new
                        {
                            SupplierId = 3,
                            Company = "H&S Bakery",
                            ProductTypeId = 4
                        },
                        new
                        {
                            SupplierId = 4,
                            Company = "Aryzita",
                            ProductTypeId = 4
                        },
                        new
                        {
                            SupplierId = 5,
                            Company = "Bacardi",
                            ProductTypeId = 6
                        },
                        new
                        {
                            SupplierId = 6,
                            Company = "Corona",
                            ProductTypeId = 6
                        },
                        new
                        {
                            SupplierId = 7,
                            Company = "Nescafe",
                            ProductTypeId = 5
                        },
                        new
                        {
                            SupplierId = 8,
                            Company = "Nesquik",
                            ProductTypeId = 5
                        },
                        new
                        {
                            SupplierId = 9,
                            Company = "Maruha Nichiro",
                            ProductTypeId = 11
                        },
                        new
                        {
                            SupplierId = 10,
                            Company = "Dairy Pure",
                            ProductTypeId = 3
                        },
                        new
                        {
                            SupplierId = 11,
                            Company = "Mowi",
                            ProductTypeId = 11
                        },
                        new
                        {
                            SupplierId = 12,
                            Company = "Prima",
                            ProductTypeId = 1
                        },
                        new
                        {
                            SupplierId = 13,
                            Company = "Prima",
                            ProductTypeId = 2
                        },
                        new
                        {
                            SupplierId = 14,
                            Company = "Tyson Product",
                            ProductTypeId = 10
                        });
                });

            modelBuilder.Entity("ProductMarketEditor.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Password = "TFgDmm",
                            RoleId = 2,
                            UserName = "Maria98"
                        },
                        new
                        {
                            UserId = 2,
                            Password = "HopeGg",
                            RoleId = 2,
                            UserName = "GrigorIus"
                        },
                        new
                        {
                            UserId = 3,
                            Password = "pasSword",
                            RoleId = 1,
                            UserName = "LindaCole"
                        },
                        new
                        {
                            UserId = 4,
                            Password = "YokH",
                            RoleId = 2,
                            UserName = "John Blitz"
                        });
                });

            modelBuilder.Entity("ProductMarketEditor.Models.Product", b =>
                {
                    b.HasOne("ProductMarketEditor.Models.ProductChange", null)
                        .WithMany("Products")
                        .HasForeignKey("ProductChangeId");

                    b.HasOne("ProductMarketEditor.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ProductMarketEditor.Models.ProductPhoto", b =>
                {
                    b.HasOne("ProductMarketEditor.Models.Product", "Product")
                        .WithMany("ProductPhotos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductMarketEditor.Models.Supplier", b =>
                {
                    b.HasOne("ProductMarketEditor.Models.ProductType", "ProductType")
                        .WithMany("Suppliers")
                        .HasForeignKey("ProductTypeId");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("ProductMarketEditor.Models.User", b =>
                {
                    b.HasOne("ProductMarketEditor.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ProductMarketEditor.Models.Product", b =>
                {
                    b.Navigation("ProductPhotos");
                });

            modelBuilder.Entity("ProductMarketEditor.Models.ProductChange", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ProductMarketEditor.Models.ProductType", b =>
                {
                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("ProductMarketEditor.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ProductMarketEditor.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
