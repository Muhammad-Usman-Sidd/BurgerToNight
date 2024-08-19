using BurgerToNightAPI.Data;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository;
using BurgerToNightAPI.Repository.IRepository;

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
    }
}
