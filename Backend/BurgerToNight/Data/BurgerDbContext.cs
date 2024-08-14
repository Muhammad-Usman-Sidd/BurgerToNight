using BurgerToNightAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BurgerToNightAPI.Data
{
    public class BurgerDbContext : IdentityDbContext<ApplicationUser>
    {
        public BurgerDbContext(DbContextOptions<BurgerDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<BurgerCategory> BCategories { get; set; }
        public DbSet<BurgerProduct> BProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BurgerCategory>().HasData(
                new BurgerCategory
                {
                    Id = 1,
                    Name = "BBQ",
                    Description = "Experience the smoky flavor and tender texture of our BBQ burgers, crafted with meticulous care in a controlled environment.",
                    CreationCategoryTime = DateTime.Now
                },
                new BurgerCategory
                {
                    Id = 2,
                    Name = "Grilled",
                    Description = "Indulge in the wholesome goodness of our Grilled burgers, prepared in a hygienic oven for a perfect char and juicy bite.",
                    CreationCategoryTime = DateTime.Now
                },
                new BurgerCategory
                {
                    Id = 3,
                    Name = "Crunch",
                    Description = "Savor the irresistible crunch of our burgers, made with the finest breadcrumbs and fresh, clean oil for an unforgettable taste.",
                    CreationCategoryTime = DateTime.Now
                },
                new BurgerCategory
                {
                    Id = 4,
                    Name = "Special",
                    Description = "Discover our signature Special burgers, the ultimate favorite renowned for their exceptional flavor and quality.",
                    CreationCategoryTime = DateTime.Now
                },
                new BurgerCategory
                {
                    Id = 5,
                    Name = "Fish",
                    Description = "Dive into the deliciousness of our Fish burgers, served with love and a smile for a delightful seafood experience.",
                    CreationCategoryTime = DateTime.Now
                },
                new BurgerCategory
                {
                    Id = 6,
                    Name = "Lamb",
                    Description = "Enjoy the rich and succulent taste of our Lamb burgers, made with premium lamb meat imported from Turkey just for you.",
                    CreationCategoryTime = DateTime.Now
                }
            );

            modelBuilder.Entity<BurgerProduct>().HasData(
                new BurgerProduct
                {
                    Id = 1,
                    Name = "Mighty Zinger",
                    BCategoryId = 3,
                    Description = "The Mighty Zinger is one of our most liked and extraordinarily large burgers! Made with a crunchy breadcrumb coating, fresh lettuce, juicy tomatoes, pickles, and topped with spicy mayo.",
                    Price = 20,
                    CreationDate = DateTime.UtcNow,
                    PreparingTime = 10,
                    Image = ""
                },
                new BurgerProduct
                {
                    Id = 2,
                    Name = "Big Ben",
                    BCategoryId = 2,
                    Description = "Craving something delicious? Look no further than the Big Ben, a grilled delight featuring a charred patty, cheddar cheese, crispy bacon, onions, and a special smoky sauce.",
                    Price = 18,
                    CreationDate = DateTime.UtcNow,
                    PreparingTime = 10,
                    Image = ""
                },
                new BurgerProduct
                {
                    Id = 3,
                    Name = "Big Bang",
                    BCategoryId = 4,
                    Description = "Need to fill a giant stomach? The Big Bang is here to deliver with its massive size and explosive flavor! Loaded with double beef patties, American cheese, onion rings, and BBQ sauce.",
                    Price = 40,
                    CreationDate = DateTime.UtcNow,
                    PreparingTime = 10,
                    Image = ""
                },
                new BurgerProduct
                {
                    Id = 4,
                    Name = "Super BBQ",
                    BCategoryId = 1,
                    Description = "Our Super BBQ burgers are crafted with extreme care, offering a mouthwatering BBQ experience with smoky beef patties, pepper jack cheese, crispy onions, and tangy BBQ sauce.",
                    Price = 30,
                    CreationDate = DateTime.UtcNow,
                    PreparingTime = 10,
                    Image = ""
                },
                new BurgerProduct
                {
                    Id = 5,
                    Name = "Selmon Burger",
                    BCategoryId = 5,
                    Description = "Our Selmon Fish burgers are in high demand. Order yours before it's too late and enjoy the taste of fresh, delectable fish! Made with crispy fish fillets, tartar sauce, lettuce, and pickles.",
                    Price = 30,
                    CreationDate = DateTime.UtcNow,
                    PreparingTime = 10,
                    Image = ""
                },
                new BurgerProduct
                {
                    Id = 6,
                    Name = "Lamb Burger",
                    BCategoryId = 6,
                    Description = "Savor the exquisite flavor of our Lamb Burger, featuring premium lamb meat, mint yogurt sauce, feta cheese, cucumber slices, and arugula, all wrapped in a toasted bun.",
                    Price = 30,
                    CreationDate = DateTime.UtcNow,
                    PreparingTime = 10,
                    Image = ""
                }
            );
        }
    }
}
