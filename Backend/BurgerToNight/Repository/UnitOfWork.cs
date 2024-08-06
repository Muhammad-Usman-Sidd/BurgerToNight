using BurgerToNightAPI.Data;
using BurgerToNightAPI.Repository.IRepository;

namespace BurgerToNightAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BurgerDbContext _db;
        public IBCategoryRepo BCategories { get; }

        public IBProductRepo BProducts { get; }
        public IOrderRepo Orders { get; set; }


        public UnitOfWork(BurgerDbContext db)
        {
            _db = db;
            Orders = new OrderRepo(_db);
            BCategories = new BCategoryRepo(_db);
            BProducts = new BProductRepo(_db);

        }

        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }
    }

}
