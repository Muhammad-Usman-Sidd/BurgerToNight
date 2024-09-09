using BurgerToNightAPI.Data;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;

namespace BurgerToNightAPI.Repository
{
    public class CategoryRepo : Repository<Category>, ICategoryRepo
    {
        private readonly AppDbContext _db;

        public CategoryRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            _db.Categories.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
