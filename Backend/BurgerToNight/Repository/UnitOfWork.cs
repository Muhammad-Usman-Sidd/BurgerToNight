using BurgerToNightAPI.Data;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;

namespace BurgerToNightAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public ICategoryRepo Categories { get; }
        public IProductRepo Products { get; }
        public IOrderHeaderRepo OrderHeaders { get; set; }
        public IOrderDetailRepo OrderDetails { get; set; }
        public ICartRepo Carts { get; set; }

       

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Categories = new CategoryRepo(_db);
            Products = new ProductRepo(_db);
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
