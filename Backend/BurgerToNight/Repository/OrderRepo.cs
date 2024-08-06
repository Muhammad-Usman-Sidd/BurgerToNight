using BurgerToNightAPI.Data;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;

namespace BurgerToNightAPI.Repository
{
    public class OrderRepo : Repository<Order>, IOrderRepo
    {
        private readonly BurgerDbContext _db;
        public OrderRepo(BurgerDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Order> UpdateAsync(Order entity)
        {
            _db.Orders.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
