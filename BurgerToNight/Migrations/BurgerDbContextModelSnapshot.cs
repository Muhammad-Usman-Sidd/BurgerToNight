﻿// <auto-generated />
using System;
using BurgerToNight.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BurgerToNight.Migrations
{
    [DbContext(typeof(BurgerDbContext))]
    partial class BurgerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BurgerToNight.Models.BurgerCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationCategoryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationCategoryTime = new DateTime(2024, 6, 24, 19, 8, 42, 389, DateTimeKind.Local).AddTicks(8478),
                            Description = "BBQ burger are made with highly care and in check environment",
                            Title = "BBQ"
                        },
                        new
                        {
                            Id = 2,
                            CreationCategoryTime = new DateTime(2024, 6, 24, 19, 8, 42, 389, DateTimeKind.Local).AddTicks(8494),
                            Description = "Grilled burger Patty are made in hygenic and clean Oven",
                            Title = "Grilled"
                        },
                        new
                        {
                            Id = 3,
                            CreationCategoryTime = new DateTime(2024, 6, 24, 19, 8, 42, 389, DateTimeKind.Local).AddTicks(8497),
                            Description = "Crunch buger patty are made With best breadcrumbs and fresh and clean oil",
                            Title = "Crunch"
                        },
                        new
                        {
                            Id = 4,
                            CreationCategoryTime = new DateTime(2024, 6, 24, 19, 8, 42, 389, DateTimeKind.Local).AddTicks(8499),
                            Description = "Our most favourite and yet the best one!",
                            Title = "Special"
                        });
                });

            modelBuilder.Entity("BurgerToNight.Models.BurgerProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PreparingTime")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BCategoryId");

                    b.ToTable("BProducts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BCategoryId = 3,
                            CreationDate = new DateTime(2024, 6, 24, 14, 8, 42, 389, DateTimeKind.Utc).AddTicks(8776),
                            Description = "",
                            Image = "",
                            Name = "Mighty Zinger",
                            PreparingTime = 10,
                            Price = 20
                        },
                        new
                        {
                            Id = 2,
                            BCategoryId = 2,
                            CreationDate = new DateTime(2024, 6, 24, 14, 8, 42, 389, DateTimeKind.Utc).AddTicks(8782),
                            Description = "",
                            Image = "",
                            Name = "Big Ben",
                            PreparingTime = 10,
                            Price = 18
                        },
                        new
                        {
                            Id = 3,
                            BCategoryId = 4,
                            CreationDate = new DateTime(2024, 6, 24, 14, 8, 42, 389, DateTimeKind.Utc).AddTicks(8785),
                            Description = "",
                            Image = "",
                            Name = "Big Bang",
                            PreparingTime = 10,
                            Price = 40
                        },
                        new
                        {
                            Id = 4,
                            BCategoryId = 1,
                            CreationDate = new DateTime(2024, 6, 24, 14, 8, 42, 389, DateTimeKind.Utc).AddTicks(8788),
                            Description = "",
                            Image = "",
                            Name = "Super BBQ",
                            PreparingTime = 10,
                            Price = 30
                        });
                });

            modelBuilder.Entity("BurgerToNight.Models.BurgerProduct", b =>
                {
                    b.HasOne("BurgerToNight.Models.BurgerCategory", "BurgerCategory")
                        .WithMany()
                        .HasForeignKey("BCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BurgerCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
