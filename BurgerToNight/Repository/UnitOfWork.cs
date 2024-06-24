using BurgerToNight.Data;
using BurgerToNight.Models;
using BurgerToNight.Repository.IRepository;

namespace BurgerToNight.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BurgerDbContext _db;
        public IBCategoryRepo BCategories { get;}

        public IBProductRepo BProducts { get; }

        public UnitOfWork(BurgerDbContext db)
        {
            _db = db;
            BCategories = new BCategoryRepo(_db);
            BProducts = new BProductRepo(_db);

        }

        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }
    }

}
