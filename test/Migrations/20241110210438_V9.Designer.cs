﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test.Models;

#nullable disable

namespace test.Migrations
{
    [DbContext(typeof(applictioncontext))]
    [Migration("20241110210438_V9")]
    partial class V9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("test.Models.invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<float>("diCount")
                        .HasColumnType("real");

                    b.Property<double>("total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("invoice");
                });

            modelBuilder.Entity("test.Models.invoiceDetlies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("invoiceId")
                        .HasColumnType("int");

                    b.Property<int>("itemId")
                        .HasColumnType("int");

                    b.Property<string>("itemname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("quantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("invoiceId");

                    b.HasIndex("itemId");

                    b.ToTable("invoiceDetlies");
                });

            modelBuilder.Entity("test.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("mainitemId")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("quanity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("mainitemId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("test.Models.mainitem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Nmae")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("mainitem");
                });

            modelBuilder.Entity("test.Models.Users", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("test.Models.invoice", b =>
                {
                    b.HasOne("test.Models.Users", "User")
                        .WithMany("invoices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("test.Models.invoiceDetlies", b =>
                {
                    b.HasOne("test.Models.invoice", "invoice")
                        .WithMany()
                        .HasForeignKey("invoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("test.Models.Item", "item")
                        .WithMany()
                        .HasForeignKey("itemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("invoice");

                    b.Navigation("item");
                });

            modelBuilder.Entity("test.Models.Item", b =>
                {
                    b.HasOne("test.Models.mainitem", "mainitem")
                        .WithMany("Items")
                        .HasForeignKey("mainitemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("mainitem");
                });

            modelBuilder.Entity("test.Models.mainitem", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("test.Models.Users", b =>
                {
                    b.Navigation("invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
