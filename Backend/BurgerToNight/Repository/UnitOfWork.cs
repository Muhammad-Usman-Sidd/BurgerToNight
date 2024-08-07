using BurgerToNightAPI.Data;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;

namespace BurgerToNightAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BurgerDbContext _db;
        public IBCategoryRepo BCategories { get; }
        public IBProductRepo BProducts { get; }
        public IOrderHeaderRepo OrderHeaders { get; set; }
        public IOrderDetailRepo OrderDetails { get; set; }
        public ICartRepo Carts { get; set; }

       

        public UnitOfWork(BurgerDbContext db)
        {
            _db = db;
            BCategories = new BCategoryRepo(_db);
            BProducts = new BProductRepo(_db);
            OrderDetails = new OrderDetailRepo(_db);
            OrderHeaders = new OrderHeaderRepo(_db);
            Carts = new CartRepo(_db);

        }

        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }
    }

}
