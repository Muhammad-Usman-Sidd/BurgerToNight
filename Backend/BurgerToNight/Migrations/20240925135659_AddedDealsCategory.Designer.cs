﻿// <auto-generated />
using System;
using BurgerToNightAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BurgerToNightAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240925135659_AddedDealsCategory")]
    partial class AddedDealsCategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BurgerToNightAPI.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BurgerToNightAPI.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ProductId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("BurgerToNightAPI.Models.Category", b =>
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

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationCategoryTime = new DateTime(2024, 9, 25, 18, 56, 58, 710, DateTimeKind.Local).AddTicks(3557),
                            Description = "Deliciously baked pizzas with a variety of toppings and flavors to satisfy every craving.",
                            Icon = "",
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = 2,
                            CreationCategoryTime = new DateTime(2024, 9, 25, 18, 56, 58, 710, DateTimeKind.Local).AddTicks(3575),
                            Description = "Juicy and flavorful burgers, crafted to perfection with fresh ingredients.",
                            Icon = "",
                            Name = "Burger"
                        },
                        new
                        {
                            Id = 3,
                            CreationCategoryTime = new DateTime(2024, 9, 25, 18, 56, 58, 710, DateTimeKind.Local).AddTicks(3576),
                            Description = "Crispy and tender broasts, made with quality spices and cooked to golden perfection.",
                            Icon = "",
                            Name = "Broast"
                        },
                        new
                        {
                            Id = 4,
                            CreationCategoryTime = new DateTime(2024, 9, 25, 18, 56, 58, 710, DateTimeKind.Local).AddTicks(3577),
                            Description = "A selection of rich and creamy pasta dishes, cooked with authentic flavors.",
                            Icon = "",
                            Name = "Pasta"
                        },
                        new
                        {
                            Id = 5,
                            CreationCategoryTime = new DateTime(2024, 9, 25, 18, 56, 58, 710, DateTimeKind.Local).AddTicks(3579),
                            Description = "Tasty wraps filled with a variety of meats and vegetables, wrapped in soft tortillas.",
                            Icon = "",
                            Name = "Wrap"
                        },
                        new
                        {
                            Id = 6,
                            CreationCategoryTime = new DateTime(2024, 9, 25, 18, 56, 58, 710, DateTimeKind.Local).AddTicks(3580),
                            Description = "Fresh and healthy salads, made with crisp vegetables and delicious dressings.",
                            Icon = "",
                            Name = "Salad"
                        },
                        new
                        {
                            Id = 7,
                            CreationCategoryTime = new DateTime(2024, 9, 25, 18, 56, 58, 710, DateTimeKind.Local).AddTicks(3581),
                            Description = "Special deals just hanging around the corner for you!",
                            Icon = "",
                            Name = "Deals"
                        });
                });

            modelBuilder.Entity("BurgerToNightAPI.Models.LocalUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LocalUsers");
                });

            modelBuilder.Entity("BurgerToNightAPI.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderHeaderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderHeaderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("BurgerToNightAPI.Models.OrderHeader", b =>
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

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("OrderTotal")
                        .HasColumnType("float");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("OrderHeaders");
                });

            modelBuilder.Entity("BurgerToNightAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
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

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3760),
                            Description = "A classic Pepperoni Pizza topped with premium pepperoni slices, mozzarella cheese, and our signature tomato sauce.",
                            Image = "",
                            Name = "Pepperoni Pizza",
                            PreparingTime = 15,
                            Price = 15
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3763),
                            Description = "Simplicity at its best: the Margherita Pizza features fresh basil, tomatoes, mozzarella, and a drizzle of olive oil.",
                            Image = "",
                            Name = "Margherita Pizza",
                            PreparingTime = 12,
                            Price = 12
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3765),
                            Description = "BBQ Chicken Pizza loaded with grilled chicken, BBQ sauce, onions, and mozzarella cheese.",
                            Image = "",
                            Name = "BBQ Chicken Pizza",
                            PreparingTime = 15,
                            Price = 18
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3767),
                            Description = "A delightful Veggie Pizza topped with bell peppers, olives, mushrooms, onions, and mozzarella cheese.",
                            Image = "",
                            Name = "Veggie Pizza",
                            PreparingTime = 15,
                            Price = 14
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3768),
                            Description = "Our Classic Cheeseburger is made with a juicy beef patty, melted cheddar cheese, lettuce, tomato, and pickles.",
                            Image = "",
                            Name = "Classic Cheeseburger",
                            PreparingTime = 8,
                            Price = 10
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3770),
                            Description = "A mouthwatering Double Bacon Burger with double beef patties, crispy bacon, cheddar cheese, and smoky sauce.",
                            Image = "",
                            Name = "Double Bacon Burger",
                            PreparingTime = 10,
                            Price = 20
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3772),
                            Description = "The Mushroom Swiss Burger features a savory beef patty, Swiss cheese, sautéed mushrooms, and garlic aioli.",
                            Image = "",
                            Name = "Mushroom Swiss Burger",
                            PreparingTime = 10,
                            Price = 15
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3773),
                            Description = "A spicy twist on a classic, the Spicy Chicken Burger is packed with flavor and heat, topped with jalapeños and pepper jack cheese.",
                            Image = "",
                            Name = "Spicy Chicken Burger",
                            PreparingTime = 10,
                            Price = 12
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3775),
                            Description = "Golden crispy Chicken Broast, marinated in special spices and fried to perfection. Served with fries and coleslaw.",
                            Image = "",
                            Name = "Chicken Broast",
                            PreparingTime = 20,
                            Price = 18
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3776),
                            Description = "Tender and crispy Beef Broast, seasoned with a blend of herbs and spices. Served with a side of dipping sauce.",
                            Image = "",
                            Name = "Beef Broast",
                            PreparingTime = 20,
                            Price = 20
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 4,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3778),
                            Description = "Traditional Spaghetti Carbonara made with creamy sauce, crispy pancetta, and Parmesan cheese.",
                            Image = "",
                            Name = "Spaghetti Carbonara",
                            PreparingTime = 15,
                            Price = 14
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 4,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3780),
                            Description = "A rich and creamy Chicken Alfredo pasta with grilled chicken, fettuccine noodles, and Alfredo sauce.",
                            Image = "",
                            Name = "Chicken Alfredo",
                            PreparingTime = 15,
                            Price = 16
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 4,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3781),
                            Description = "Spicy and flavorful Penne Arrabbiata, made with penne pasta, garlic, red chili flakes, and tomato sauce.",
                            Image = "",
                            Name = "Penne Arrabbiata",
                            PreparingTime = 12,
                            Price = 13
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 4,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3783),
                            Description = "Creamy and indulgent Fettuccine Alfredo, made with rich Alfredo sauce and topped with Parmesan cheese.",
                            Image = "",
                            Name = "Fettuccine Alfredo",
                            PreparingTime = 12,
                            Price = 15
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 5,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3784),
                            Description = "A healthy and delicious Grilled Chicken Wrap with lettuce, tomatoes, cucumbers, and a tangy yogurt dressing.",
                            Image = "",
                            Name = "Grilled Chicken Wrap",
                            PreparingTime = 10,
                            Price = 10
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 5,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3786),
                            Description = "A tasty Falafel Wrap filled with crispy falafel, fresh vegetables, and a creamy tahini sauce.",
                            Image = "",
                            Name = "Falafel Wrap",
                            PreparingTime = 10,
                            Price = 9
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 5,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3794),
                            Description = "A flavorful Beef Shawarma Wrap, filled with seasoned beef, fresh vegetables, and garlic sauce, wrapped in a soft tortilla.",
                            Image = "",
                            Name = "Beef Shawarma Wrap",
                            PreparingTime = 10,
                            Price = 12
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 5,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3796),
                            Description = "A Grilled Veggie Wrap loaded with grilled vegetables, hummus, and fresh herbs, wrapped in a whole wheat tortilla.",
                            Image = "",
                            Name = "Grilled Veggie Wrap",
                            PreparingTime = 10,
                            Price = 10
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 6,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3797),
                            Description = "A fresh Caesar Salad with crisp romaine lettuce, croutons, Parmesan cheese, and Caesar dressing.",
                            Image = "",
                            Name = "Caesar Salad",
                            PreparingTime = 5,
                            Price = 8
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 6,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3799),
                            Description = "A refreshing Greek Salad made with cucumbers, tomatoes, olives, feta cheese, and a lemon-oregano dressing.",
                            Image = "",
                            Name = "Greek Salad",
                            PreparingTime = 5,
                            Price = 9
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 7,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3800),
                            Description = "A delicious deal with two juicy beef burgers, loaded with cheese, fresh veggies, and a side of crispy fries.",
                            Image = "",
                            Name = "Mega Burger Feast",
                            PreparingTime = 30,
                            Price = 120
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 7,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3802),
                            Description = "Get two large pizzas with a variety of toppings, plus a family-size portion of garlic bread and a liter of soda.",
                            Image = "",
                            Name = "Family Pizza Bundle",
                            PreparingTime = 45,
                            Price = 180
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 7,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3803),
                            Description = "Enjoy a bucket filled with 12 pieces of crispy fried chicken, a large side of coleslaw, and mashed potatoes with gravy.",
                            Image = "",
                            Name = "Chicken Bucket Special",
                            PreparingTime = 35,
                            Price = 150
                        },
                        new
                        {
                            Id = 24,
                            CategoryId = 7,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3805),
                            Description = "A box of 10 flavorful Wraps, with your choice of beef or chicken, served with salsa, guacamole, and chips.",
                            Image = "",
                            Name = "Wrap Fiesta Box",
                            PreparingTime = 25,
                            Price = 100
                        },
                        new
                        {
                            Id = 25,
                            CategoryId = 7,
                            CreationDate = new DateTime(2024, 9, 25, 13, 56, 58, 710, DateTimeKind.Utc).AddTicks(3806),
                            Description = "Indulge in a cheesy delight with a large pizza smothered in four types of cheese, baked to perfection.",
                            Image = "",
                            Name = "Cheese Lover's Pizza",
                            PreparingTime = 40,
                            Price = 95
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BurgerToNightAPI.Models.Cart", b =>
                {
                    b.HasOne("BurgerToNightAPI.Models.ApplicationUser", "applicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BurgerToNightAPI.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("applicationUser");
                });

            modelBuilder.Entity("BurgerToNightAPI.Models.OrderDetail", b =>
                {
                    b.HasOne("BurgerToNightAPI.Models.OrderHeader", "orderHeader")
                        .WithMany()
                        .HasForeignKey("OrderHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BurgerToNightAPI.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("orderHeader");
                });

            modelBuilder.Entity("BurgerToNightAPI.Models.OrderHeader", b =>
                {
                    b.HasOne("BurgerToNightAPI.Models.ApplicationUser", "applicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("applicationUser");
                });

            modelBuilder.Entity("BurgerToNightAPI.Models.Product", b =>
                {
                    b.HasOne("BurgerToNightAPI.Models.Category", "productCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("productCategory");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BurgerToNightAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BurgerToNightAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BurgerToNightAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BurgerToNightAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
