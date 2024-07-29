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
        public DbSet<OrdersDetail> OrderDetails { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<BurgerCategory> BCategories { get; set; }
        public DbSet<BurgerProduct> BProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BurgerCategory>().HasData(
                new BurgerCategory { Id = 1, Title = "BBQ", Description = "BBQ burger are made with highly care and in check environment",CreationCategoryTime=DateTime.Now },
                new BurgerCategory { Id = 2, Title = "Grilled", Description = "Grilled burger Patty are made in hygenic and clean Oven", CreationCategoryTime = DateTime.Now },
                new BurgerCategory { Id = 3, Title = "Crunch", Description = "Crunch buger patty are made With best breadcrumbs and fresh and clean oil", CreationCategoryTime = DateTime.Now },
                new BurgerCategory { Id = 4, Title = "Special", Description = "Our most favourite and yet the best one!",CreationCategoryTime = DateTime.Now }
                );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BurgerProduct>().HasData(
                new BurgerProduct { Id =1,Name="Mighty Zinger", BCategoryId =3,Description="The Mighty Zinger one of the most liked and extremely big burgers! ",Price=20,CreationDate=DateTime.UtcNow,PreparingTime=10,Image=""},
                new BurgerProduct { Id =2, Name ="Big Ben", BCategoryId=2, Description = "Carwing for something good look no further", Price =18, CreationDate = DateTime.UtcNow, PreparingTime = 10,Image = "" },
                new BurgerProduct { Id =3, Name ="Big Bang", BCategoryId =4, Description = "Wanna fill your gaint stomach?? ", Price =40, CreationDate = DateTime.UtcNow ,PreparingTime = 10, Image = "" },
                new BurgerProduct { Id =4, Name ="Super BBQ", BCategoryId =1, Description = "Super BBQ burgers are made with extreme care", Price =30, CreationDate = DateTime.UtcNow ,PreparingTime = 10, Image = "" }
                );
        }
    }

}
