using BurgerToNightAPI.Data;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository;
using BurgerToNightAPI.Repository.IRepository;

namespace BurgerToNightAPI.Repository
{
    public class BProductRepo : Repository<BurgerProduct>, IBProductRepo
    {
        private readonly BurgerDbContext _db;
        public BProductRepo(BurgerDbContext db) : base(db)
        {
            _db = db;

        }
        public async Task<BurgerProduct> UpdateAsync(BurgerProduct entity)
        {
            _db.BProducts.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
