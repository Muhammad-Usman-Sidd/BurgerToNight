using BurgerToNight.Data;
using BurgerToNight.Models;
using BurgerToNight.Repository.IRepository;

namespace BurgerToNight.Repository
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
