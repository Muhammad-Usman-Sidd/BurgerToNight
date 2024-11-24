using BurgerToNightAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BurgerToNightAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Pizza",
                    Description = "Deliciously baked pizzas with a variety of toppings and flavors to satisfy every craving.",
                    CreationCategoryTime = DateTime.Now,
                    Icon = ""
                },
                new Category
                {
                    Id = 2,
                    Name = "Burger",
                    Description = "Juicy and flavorful burgers, crafted to perfection with fresh ingredients.",
                    CreationCategoryTime = DateTime.Now,
                    Icon = ""
                },
                new Category
                {
                    Id = 3,
                    Name = "Broast",
                    Description = "Crispy and tender broasts, made with quality spices and cooked to golden perfection.",
                    CreationCategoryTime = DateTime.Now,
                    Icon = ""
                },
                new Category
                {
                    Id = 4,
                    Name = "Pasta",
                    Description = "A selection of rich and creamy pasta dishes, cooked with authentic flavors.",
                    CreationCategoryTime = DateTime.Now,
                    Icon = ""
                },
                new Category
                {
                    Id = 5,
                    Name = "Wrap",
                    Description = "Tasty wraps filled with a variety of meats and vegetables, wrapped in soft tortillas.",
                    CreationCategoryTime = DateTime.Now,
                    Icon = ""
                },
                new Category
                {
                    Id = 6,
                    Name = "Salad",
                    Description = "Fresh and healthy salads, made with crisp vegetables and delicious dressings.",
                    CreationCategoryTime = DateTime.Now,
                    Icon = ""
                },
                new Category
                {
                    Id = 7,
                    Name = "Deals",
                    Description = "Special deals just hanging around the corner for you!",
                    CreationCategoryTime = DateTime.Now,
                    Icon = ""
                }
            );

            modelBuilder.Entity<Product>().HasData(
                     new Product
                     {
                         Id = 1,
                         Name = "Pepperoni Pizza",
                         CategoryId = 1, // Pizza
                         Description = "A classic Pepperoni Pizza topped with premium pepperoni slices, mozzarella cheese, and our signature tomato sauce.",
                         Price = 15,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 15,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 2,
                         Name = "Margherita Pizza",
                         CategoryId = 1, // Pizza
                         Description = "Simplicity at its best: the Margherita Pizza features fresh basil, tomatoes, mozzarella, and a drizzle of olive oil.",
                         Price = 12,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 12,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 3,
                         Name = "BBQ Chicken Pizza",
                         CategoryId = 1, // Pizza
                         Description = "BBQ Chicken Pizza loaded with grilled chicken, BBQ sauce, onions, and mozzarella cheese.",
                         Price = 18,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 15,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 4,
                         Name = "Veggie Pizza",
                         CategoryId = 1, // Pizza
                         Description = "A delightful Veggie Pizza topped with bell peppers, olives, mushrooms, onions, and mozzarella cheese.",
                         Price = 14,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 15,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 5,
                         Name = "Classic Cheeseburger",
                         CategoryId = 2, // Burger
                         Description = "Our Classic Cheeseburger is made with a juicy beef patty, melted cheddar cheese, lettuce, tomato, and pickles.",
                         Price = 10,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 8,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 6,
                         Name = "Double Bacon Burger",
                         CategoryId = 2, // Burger
                         Description = "A mouthwatering Double Bacon Burger with double beef patties, crispy bacon, cheddar cheese, and smoky sauce.",
                         Price = 20,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 10,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 7,
                         Name = "Mushroom Swiss Burger",
                         CategoryId = 2, // Burger
                         Description = "The Mushroom Swiss Burger features a savory beef patty, Swiss cheese, sautéed mushrooms, and garlic aioli.",
                         Price = 15,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 10,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 8,
                         Name = "Spicy Chicken Burger",
                         CategoryId = 2, // Burger
                         Description = "A spicy twist on a classic, the Spicy Chicken Burger is packed with flavor and heat, topped with jalapeños and pepper jack cheese.",
                         Price = 12,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 10,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 9,
                         Name = "Chicken Broast",
                         CategoryId = 3, // Broast
                         Description = "Golden crispy Chicken Broast, marinated in special spices and fried to perfection. Served with fries and coleslaw.",
                         Price = 18,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 20,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 10,
                         Name = "Beef Broast",
                         CategoryId = 3, // Broast
                         Description = "Tender and crispy Beef Broast, seasoned with a blend of herbs and spices. Served with a side of dipping sauce.",
                         Price = 20,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 20,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 11,
                         Name = "Spaghetti Carbonara",
                         CategoryId = 4, // Pasta
                         Description = "Traditional Spaghetti Carbonara made with creamy sauce, crispy pancetta, and Parmesan cheese.",
                         Price = 14,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 15,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 12,
                         Name = "Chicken Alfredo",
                         CategoryId = 4, // Pasta
                         Description = "A rich and creamy Chicken Alfredo pasta with grilled chicken, fettuccine noodles, and Alfredo sauce.",
                         Price = 16,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 15,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 13,
                         Name = "Penne Arrabbiata",
                         CategoryId = 4, // Pasta
                         Description = "Spicy and flavorful Penne Arrabbiata, made with penne pasta, garlic, red chili flakes, and tomato sauce.",
                         Price = 13,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 12,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 14,
                         Name = "Fettuccine Alfredo",
                         CategoryId = 4, // Pasta
                         Description = "Creamy and indulgent Fettuccine Alfredo, made with rich Alfredo sauce and topped with Parmesan cheese.",
                         Price = 15,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 12,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 15,
                         Name = "Grilled Chicken Wrap",
                         CategoryId = 5, // Wrap
                         Description = "A healthy and delicious Grilled Chicken Wrap with lettuce, tomatoes, cucumbers, and a tangy yogurt dressing.",
                         Price = 10,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 10,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 16,
                         Name = "Falafel Wrap",
                         CategoryId = 5, // Wrap
                         Description = "A tasty Falafel Wrap filled with crispy falafel, fresh vegetables, and a creamy tahini sauce.",
                         Price = 9,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 10,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 17,
                         Name = "Beef Shawarma Wrap",
                         CategoryId = 5, // Wrap
                         Description = "A flavorful Beef Shawarma Wrap, filled with seasoned beef, fresh vegetables, and garlic sauce, wrapped in a soft tortilla.",
                         Price = 12,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 10,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 18,
                         Name = "Grilled Veggie Wrap",
                         CategoryId = 5, // Wrap
                         Description = "A Grilled Veggie Wrap loaded with grilled vegetables, hummus, and fresh herbs, wrapped in a whole wheat tortilla.",
                         Price = 10,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 10,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 19,
                         Name = "Caesar Salad",
                         CategoryId = 6, // Salad
                         Description = "A fresh Caesar Salad with crisp romaine lettuce, croutons, Parmesan cheese, and Caesar dressing.",
                         Price = 8,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 5,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 20,
                         Name = "Greek Salad",
                         CategoryId = 6, // Salad
                         Description = "A refreshing Greek Salad made with cucumbers, tomatoes, olives, feta cheese, and a lemon-oregano dressing.",
                         Price = 9,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 5,
                         Image = ""
                     },
                     new Product
                     {
                         Id = 21,
                         Name = "Mega Burger Feast",
                         CategoryId = 7, // Deals
                         Description = "A delicious deal with two juicy beef burgers, loaded with cheese, fresh veggies, and a side of crispy fries.",
                         Price = 120,
                         CreationDate = DateTime.UtcNow,
                         PreparingTime = 30,
                         Image = ""
                     },
                    new Product
                    {
                        Id = 22,
                        Name = "Family Pizza Bundle",
                        CategoryId = 7, // Deals
                        Description = "Get two large pizzas with a variety of toppings, plus a family-size portion of garlic bread and a liter of soda.",
                        Price = 180,
                        CreationDate = DateTime.UtcNow,
                        PreparingTime = 45,
                        Image = ""
                    },

                    new Product
                    {
                        Id = 23,
                        Name = "Chicken Bucket Special",
                        CategoryId = 7, // Deals
                        Description = "Enjoy a bucket filled with 12 pieces of crispy fried chicken, a large side of coleslaw, and mashed potatoes with gravy.",
                        Price = 150,
                        CreationDate = DateTime.UtcNow,
                        PreparingTime = 35,
                        Image = ""
                    },

                    new Product
                    {
                        Id = 24,
                        Name = "Wrap Fiesta Box",
                        CategoryId = 7, // Deals
                        Description = "A box of 10 flavorful Wraps, with your choice of beef or chicken, served with salsa, guacamole, and chips.",
                        Price = 100,
                        CreationDate = DateTime.UtcNow,
                        PreparingTime = 25,
                        Image = ""
                    },

                    new Product
                    {
                        Id = 25,
                        Name = "Cheese Lover's Pizza",
                        CategoryId = 7, // Deals
                        Description = "Indulge in a cheesy delight with a large pizza smothered in four types of cheese, baked to perfection.",
                        Price = 95,
                        CreationDate = DateTime.UtcNow,
                        PreparingTime = 40,
                        Image = ""
                    }


                 );

        }
    }
}
