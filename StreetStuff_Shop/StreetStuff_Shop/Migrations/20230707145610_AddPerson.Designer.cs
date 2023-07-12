﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StreetStuff_Shop;

#nullable disable

namespace StreetStuff_Shop.Migrations
{
    [DbContext(typeof(StreetStuffContext))]
    [Migration("20230707145610_AddPerson")]
    partial class AddPerson
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StreetStuff_Shop.DAL.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("AdminID");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id")
                        .HasName("PK__Admin__719FE4E8EFAC5227");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id")
                        .HasName("[PK__Cart__3214EC073730AA0B]");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("CategoryId")
                        .HasName("PK__Category__19093A0B0475C28E");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("ColorName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ColorId")
                        .HasName("PK__Color__8DA7674D7597AB82");

                    b.ToTable("Color", (string)null);
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Liked", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id")
                        .HasName("PK__Liked__3214EC07955FC03E");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Liked", (string)null);
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("OrderId")
                        .HasName("PK__Orders__C3905BAF97A72355");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<string>("Brand")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Photo")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("ImageURL");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("ProductName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("SexId")
                        .HasColumnType("int");

                    b.Property<int?>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("ProductId")
                        .HasName("PK__Products__B40CC6ED2DB1C02B");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ColorId");

                    b.HasIndex("SexId");

                    b.HasIndex("SizeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Sex", b =>
                {
                    b.Property<int>("SexId")
                        .HasColumnType("int");

                    b.Property<string>("SexName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("SexId")
                        .HasName("PK__Sex__75622D967B4FA58B");

                    b.ToTable("Sex", (string)null);
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Size", b =>
                {
                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.Property<string>("SizeName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("SizeId")
                        .HasName("PK__Size__83BD097A7814E691");

                    b.ToTable("Size", (string)null);
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Photo")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ShippingAddress")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__Users__1788CCAC35132386");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Cart", b =>
                {
                    b.HasOne("StreetStuff_Shop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__Cart__ProductID__4E88ABD4");

                    b.HasOne("StreetStuff_Shop.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Cart__UserID__4F7CD00D");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Liked", b =>
                {
                    b.HasOne("StreetStuff_Shop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__Liked__ProductID__68487DD7");

                    b.HasOne("StreetStuff_Shop.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Liked__UserID__693CA210");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Order", b =>
                {
                    b.HasOne("StreetStuff_Shop.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Orders__UserID__52593CB8");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Product", b =>
                {
                    b.HasOne("StreetStuff_Shop.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__Products__Catego__6383C8BA");

                    b.HasOne("StreetStuff_Shop.Models.Color", "Color")
                        .WithMany("Products")
                        .HasForeignKey("ColorId")
                        .HasConstraintName("FK__Products__ColorI__66603565");

                    b.HasOne("StreetStuff_Shop.Models.Sex", "Sex")
                        .WithMany("Products")
                        .HasForeignKey("SexId")
                        .HasConstraintName("FK__Products__SexId__6477ECF3");

                    b.HasOne("StreetStuff_Shop.Models.Size", "Size")
                        .WithMany("Products")
                        .HasForeignKey("SizeId")
                        .HasConstraintName("FK__Products__SizeId__656C112C");

                    b.Navigation("Category");

                    b.Navigation("Color");

                    b.Navigation("Sex");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Color", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Sex", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.Size", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StreetStuff_Shop.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}