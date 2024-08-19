using BurgerToNightAPI.Data;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;

namespace BurgerToNightAPI.Repository
{
    public class OrderDetailRepo : Repository<OrderDetail>, IOrderDetailRepo
    {
        private readonly AppDbContext _db;
        public OrderDetailRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public Task<OrderDetail> UpdateAsync(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
