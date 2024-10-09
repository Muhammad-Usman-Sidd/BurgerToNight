using BurgerToNightAPI.Data;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BurgerToNightAPI.Repository
{
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        private readonly AppDbContext _db;
        public ProductRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            _db.Products.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Product>> GetTopSellingProducts(int topCount)
        {
            var topProducts = await _db.OrderDetails
            .GroupBy(od => od.ProductId)
            .Select(group => new
            {
                ProductId = group.Key,
                TotalSold = group.Sum(od => od.Quantity)
            })
            .OrderByDescending(g => g.TotalSold)
            .Take(topCount)
            .Join(_db.Products,
                g => g.ProductId,
                p => p.Id,
                (g, p) => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description =p.Description,  
                    PreparingTime = p.PreparingTime,
                    CategoryId = p.CategoryId,
                    productCategory =p.productCategory,
                    CreationDate = p.CreationDate,
                    Image = p.Image,
                    TotalSales = g.TotalSold
                })
            .ToListAsync();

            return topProducts;
        }
    }
}
