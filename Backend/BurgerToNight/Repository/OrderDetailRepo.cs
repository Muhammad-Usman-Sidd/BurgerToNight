using BurgerToNightAPI.Data;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;

namespace BurgerToNightAPI.Repository
{
    public class OrderDetailRepo : Repository<OrdersDetail>, IOrderDetailRepo
    {
        private readonly BurgerDbContext _db;
        public OrderDetailRepo(BurgerDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<OrdersDetail> UpdateAsync(OrdersDetail entity)
        {
            _db.OrderDetails.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
