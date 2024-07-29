using BurgerToNightAPI.Models;

namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IOrderDetailRepo :IRepository<OrdersDetail>
    {
        Task<OrdersDetail> UpdateAsync(OrdersDetail entity);

    }
}
