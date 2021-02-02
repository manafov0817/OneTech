﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OneTech.Data.Concrete.EfCore;

namespace OneTech.Data.Migrations
{
    [DbContext(typeof(OneTechDbContext))]
    [Migration("20201224100745_RelateAdded")]
    partial class RelateAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("OneTech.Entity.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("OneTech.Entity.Models.BrandModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("BrandModels");
                });

            modelBuilder.Entity("OneTech.Entity.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OneTech.Entity.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("OneTech.Entity.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MainCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OneTech.Entity.Models.MainCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MainCategories");
                });

            modelBuilder.Entity("OneTech.Entity.Models.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("OneTech.Entity.Models.OptionValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.ToTable("OptionValues");
                });

            modelBuilder.Entity("OneTech.Entity.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("OneTech.Entity.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BrandModelId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscountEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscountStart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("DiscountWithMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DiscountWithPercent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Sold")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BrandModelId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OneTech.Entity.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("OneTech.Entity.Models.ProductMainCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("MainCategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "MainCategoryId");

                    b.HasIndex("MainCategoryId");

                    b.ToTable("ProductMainCategories");
                });

            modelBuilder.Entity("OneTech.Entity.Models.ProductOptionValue", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("OptionValueId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "OptionValueId");

                    b.HasIndex("OptionValueId");

                    b.ToTable("ProductOptionValues");
                });

            modelBuilder.Entity("OneTech.Entity.Models.ProductPhoto", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "PhotoId");

                    b.HasIndex("PhotoId");

                    b.ToTable("ProductPhotos");
                });

            modelBuilder.Entity("OneTech.Entity.Models.ProductRelate", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("RelateId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "RelateId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.HasIndex("RelateId");

                    b.ToTable("ProductRelates");
                });

            modelBuilder.Entity("OneTech.Entity.Models.ProductReview", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ReviewId");

                    b.HasIndex("ReviewId");

                    b.ToTable("ProductReviews");
                });

            modelBuilder.Entity("OneTech.Entity.Models.ProductSubCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "SubCategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("ProductSubCategories");
                });

            modelBuilder.Entity("OneTech.Entity.Models.Relate", b =>
                {
                    b.Property<int>("RelateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("RelateId");

                    b.ToTable("Relate");
                });

            modelBuilder.Entity("OneTech.Entity.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<int>("Text")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("OneTech.Entity.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("OneTech.Entity.Models.BrandModel", b =>
                {
                    b.HasOne("OneTech.Entity.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("OneTech.Entity.Models.CartItem", b =>
                {
                    b.HasOne("OneTech.Entity.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OneTech.Entity.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OneTech.Entity.Models.Category", b =>
                {
                    b.HasOne("OneTech.Entity.Models.MainCategory", "MainCategory")
                        .WithMany("Categories")
                        .HasForeignKey("MainCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainCategory");
                });

            modelBuilder.Entity("OneTech.Entity.Models.OptionValue", b =>
                {
                    b.HasOne("OneTech.Entity.Models.Option", "Option")
                        .WithMany()
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Option");
                });

            modelBuilder.Entity("OneTech.Entity.Models.Product", b =>
                {
                    b.HasOne("OneTech.Entity.Models.BrandModel", "BrandModel")
                        .WithMany()
                        .HasForeignKey("BrandModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BrandModel");
                });

            modelBuilder.Entity("OneTech.Entity.Models.ProductCategory", b =>
                {
                    b.HasOne("OneTech.Entity.Models.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OneTech.Entity.Models.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OneTech.Entity.Models.ProductMainCategory", b =>
                {
                    b.HasOne("OneTech.Entity.Models.MainCategory", "MainCategory")
                        .WithMany("ProductMainCategories")
                        .HasForeignKey("MainCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OneTech.Entity.Models.Product", "Product")
                        .WithMany("ProductMainCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainCategory");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OneTech.Entity.Models.ProductOptionValue", b =>
                {
                    b.HasOne("OneTech.Entity.Models.OptionValue", "OptionValue")
                        .WithMany("ProductOptionValues")
                        .HasForeignKey("OptionValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OneTech.Entity.Models.Product", "Product")
                        .WithMany("ProductOptionValues")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OptionValue");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OneTech.Entity.Models.ProductPhoto", b =>
                {
                    b.HasOne("OneTech.Entity.Models.Photo", "Photo")
                        .WithMany("ProductPhotos")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OneTech.Entity.Models.Product", "Product")
                        .WithMany("ProductPhotos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Photo");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OneTech.Entity.Models.ProductRelate", b =>
                {
                    b.HasOne("OneTech.Entity.Models.Product", "Product")
                        .WithOne("Relate")
                        .HasForeignKey("OneTech.Entity.Models.ProductRelate", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OneTech.Entity.Models.Relate", "Relate")
                        .WithMany()
                        .HasForeignKey("RelateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Relate");
                });

            modelBuilder.Entity("OneTech.Entity.Models.ProductReview", b =>
                {
                    b.HasOne("OneTech.Entity.Models.Product", "Product")
                        .WithMany("ProductReviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OneTech.Entity.Models.Review", "Review")
                        .WithMany("ProductReviews")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("OneTech.Entity.Models.ProductSubCategory", b =>
                {
                    b.HasOne("OneTech.Entity.Models.Product", "Product")
                        .WithMany("ProductSubCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OneTech.Entity.Models.SubCategory", "SubCategory")
                        .WithMany("ProductCategories")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("OneTech.Entity.Models.SubCategory", b =>
                {
                    b.HasOne("OneTech.Entity.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OneTech.Entity.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("OneTech.Entity.Models.Category", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("OneTech.Entity.Models.MainCategory", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("ProductMainCategories");
                });

            modelBuilder.Entity("OneTech.Entity.Models.OptionValue", b =>
                {
                    b.Navigation("ProductOptionValues");
                });

            modelBuilder.Entity("OneTech.Entity.Models.Photo", b =>
                {
                    b.Navigation("ProductPhotos");
                });

            modelBuilder.Entity("OneTech.Entity.Models.Product", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("ProductMainCategories");

                    b.Navigation("ProductOptionValues");

                    b.Navigation("ProductPhotos");

                    b.Navigation("ProductReviews");

                    b.Navigation("ProductSubCategories");

                    b.Navigation("Relate");
                });

            modelBuilder.Entity("OneTech.Entity.Models.Review", b =>
                {
                    b.Navigation("ProductReviews");
                });

            modelBuilder.Entity("OneTech.Entity.Models.SubCategory", b =>
                {
                    b.Navigation("ProductCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
