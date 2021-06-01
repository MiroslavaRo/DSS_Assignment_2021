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
    [Migration("20210601123744_FixedChangeLog")]
    partial class FixedChangeLog
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

                    b.ToTable("ProductChange");

                    b.HasData(
                        new
                        {
                            ProductChangeId = 1,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
                        },
                        new
                        {
                            ProductChangeId = 2,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
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

                    b.Property<string>("ImageFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierChangeId")
                        .HasColumnType("int");

                    b.HasKey("SupplierId");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("SupplierChangeId");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SupplierId = 1,
                            Company = "Burum",
                            ImageFile = "burum.jpg",
                            ProductTypeId = 11,
                            SupplierChangeId = 1
                        },
                        new
                        {
                            SupplierId = 2,
                            Company = "Prostokvashino",
                            ImageFile = "prostokvashino.jpg",
                            ProductTypeId = 3,
                            SupplierChangeId = 2
                        },
                        new
                        {
                            SupplierId = 3,
                            Company = "H&S Bakery",
                            ImageFile = "h&s bakery.jpg",
                            ProductTypeId = 4,
                            SupplierChangeId = 3
                        },
                        new
                        {
                            SupplierId = 4,
                            Company = "Aryzita",
                            ImageFile = "ARYZTA.jpg",
                            ProductTypeId = 4,
                            SupplierChangeId = 4
                        },
                        new
                        {
                            SupplierId = 5,
                            Company = "Bacardi",
                            ImageFile = "bacardi.jpg",
                            ProductTypeId = 6,
                            SupplierChangeId = 5
                        },
                        new
                        {
                            SupplierId = 6,
                            Company = "Corona",
                            ImageFile = "Corona.jpg",
                            ProductTypeId = 6,
                            SupplierChangeId = 6
                        },
                        new
                        {
                            SupplierId = 7,
                            Company = "Nescafe",
                            ImageFile = "nescafe.jpg",
                            ProductTypeId = 5,
                            SupplierChangeId = 7
                        },
                        new
                        {
                            SupplierId = 8,
                            Company = "Nesquik",
                            ImageFile = "nesquik.jpg",
                            ProductTypeId = 5,
                            SupplierChangeId = 8
                        },
                        new
                        {
                            SupplierId = 9,
                            Company = "Maruha Nichiro",
                            ImageFile = "maruhanichiro.jpg",
                            ProductTypeId = 11,
                            SupplierChangeId = 9
                        },
                        new
                        {
                            SupplierId = 10,
                            Company = "Dairy Pure",
                            ImageFile = "DairyPure.jpg",
                            ProductTypeId = 3,
                            SupplierChangeId = 10
                        },
                        new
                        {
                            SupplierId = 11,
                            Company = "Mowi",
                            ImageFile = "MOWI.jpg",
                            ProductTypeId = 11,
                            SupplierChangeId = 11
                        },
                        new
                        {
                            SupplierId = 12,
                            Company = "Prima",
                            ImageFile = "prima.jpg",
                            ProductTypeId = 1,
                            SupplierChangeId = 12
                        },
                        new
                        {
                            SupplierId = 13,
                            Company = "Prima",
                            ImageFile = "prima.jpg",
                            ProductTypeId = 2,
                            SupplierChangeId = 13
                        },
                        new
                        {
                            SupplierId = 14,
                            Company = "Tyson Product",
                            ImageFile = "tysonproduct.jpg",
                            ProductTypeId = 10,
                            SupplierChangeId = 14
                        });
                });

            modelBuilder.Entity("ProductMarketEditor.Models.SupplierChange", b =>
                {
                    b.Property<int>("SupplierChangeId")
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

                    b.HasKey("SupplierChangeId");

                    b.ToTable("SupplierChange");

                    b.HasData(
                        new
                        {
                            SupplierChangeId = 1,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
                        },
                        new
                        {
                            SupplierChangeId = 2,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
                        },
                        new
                        {
                            SupplierChangeId = 3,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
                        },
                        new
                        {
                            SupplierChangeId = 4,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
                        },
                        new
                        {
                            SupplierChangeId = 5,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
                        },
                        new
                        {
                            SupplierChangeId = 6,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
                        },
                        new
                        {
                            SupplierChangeId = 7,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
                        },
                        new
                        {
                            SupplierChangeId = 8,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
                        },
                        new
                        {
                            SupplierChangeId = 9,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
                        },
                        new
                        {
                            SupplierChangeId = 10,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
                        },
                        new
                        {
                            SupplierChangeId = 11,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
                        },
                        new
                        {
                            SupplierChangeId = 12,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
                        },
                        new
                        {
                            SupplierChangeId = 13,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
                        },
                        new
                        {
                            SupplierChangeId = 14,
                            CreatedBy = "LindaCole",
                            CreatedOn = "2021/05/20 11:30:30 AM",
                            EditedBy = "LindaCole",
                            EditedOn = "2021/05/20 11:30:30 AM"
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
                    b.HasOne("ProductMarketEditor.Models.ProductChange", "ProductChange")
                        .WithMany("Products")
                        .HasForeignKey("ProductChangeId");

                    b.HasOne("ProductMarketEditor.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");

                    b.Navigation("ProductChange");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ProductMarketEditor.Models.Supplier", b =>
                {
                    b.HasOne("ProductMarketEditor.Models.ProductType", "ProductType")
                        .WithMany("Suppliers")
                        .HasForeignKey("ProductTypeId");

                    b.HasOne("ProductMarketEditor.Models.SupplierChange", "SupplierChange")
                        .WithMany("Suppliers")
                        .HasForeignKey("SupplierChangeId");

                    b.Navigation("ProductType");

                    b.Navigation("SupplierChange");
                });

            modelBuilder.Entity("ProductMarketEditor.Models.User", b =>
                {
                    b.HasOne("ProductMarketEditor.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
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

            modelBuilder.Entity("ProductMarketEditor.Models.SupplierChange", b =>
                {
                    b.Navigation("Suppliers");
                });
#pragma warning restore 612, 618
        }
    }
}