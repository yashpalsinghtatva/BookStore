﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineBookStoreAPI.Data;

namespace OnlineBookStoreAPI.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    [Migration("20221019105411_orderMig")]
    partial class orderMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineBookStoreAPI.Data.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("PinCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.HasIndex("CountryId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("OnlineBookStoreAPI.Data.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("OnlineBookStoreAPI.Data.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("BookDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BookPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("BookTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfBooks")
                        .HasColumnType("int");

                    b.Property<int>("NumberofPages")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("OnlineBookStoreAPI.Data.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("OnlineBookStoreAPI.Data.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LanguageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("OnlineBookStoreAPI.Data.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShippingMethodId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("AddressId");

                    b.HasIndex("ShippingMethodId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineBookStoreAPI.Data.OrderBook", b =>
                {
                    b.Property<int>("OrderBookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderBookId");

                    b.HasIndex("BookId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderBooks");
                });

            modelBuilder.Entity("OnlineBookStoreAPI.Data.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PublisherName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("OnlineBookStoreAPI.Data.ShippingMethod", b =>
                {
                    b.Property<int>("ShippingMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShippingMethodName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShippingMethodId");

                    b.ToTable("ShippingMethods");
                });

            modelBuilder.Entity("OnlineBookStoreAPI.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OnlineBookStoreAPI.Data.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTypeId");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("OnlineBookStoreAPI.Data.Address", b =>
                {
                    b.HasOne("OnlineBookStoreAPI.Data.Country", "Country")
                        .WithMany("Addresses")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("OnlineBookStoreAPI.Data.Book", b =>
                {
                    b.HasOne("OnlineBookStoreAPI.Data.Author", "Author")
                        .WithMany("authorBooks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBookStoreAPI.Data.Language", "Language")
                        .WithMany("Books")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBookStoreAPI.Data.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookStoreAPI.Data.Order", b =>
                {
                    b.HasOne("OnlineBookStoreAPI.Data.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("OnlineBookStoreAPI.Data.ShippingMethod", "ShippingMethod")
                        .WithMany("Orders")
                        .HasForeignKey("ShippingMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBookStoreAPI.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookStoreAPI.Data.OrderBook", b =>
                {
                    b.HasOne("OnlineBookStoreAPI.Data.Book", "Book")
                        .WithMany("orderBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBookStoreAPI.Data.Order", "Order")
                        .WithMany("OrderBooks")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBookStoreAPI.Data.User", b =>
                {
                    b.HasOne("OnlineBookStoreAPI.Data.UserType", "UserType")
                        .WithMany("users")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
