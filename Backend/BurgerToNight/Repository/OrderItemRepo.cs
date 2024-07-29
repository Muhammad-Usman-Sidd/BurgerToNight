using BurgerToNightAPI.Data;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;

namespace BurgerToNightAPI.Repository
{
    public class OrderItemRepo : Repository<OrderItem>, IOrderItemRepo
    {
        private readonly BurgerDbContext _db;
        public OrderItemRepo(BurgerDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<OrderItem> UpdateAsync(OrderItem entity)
        {
            _db.OrderItems.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
