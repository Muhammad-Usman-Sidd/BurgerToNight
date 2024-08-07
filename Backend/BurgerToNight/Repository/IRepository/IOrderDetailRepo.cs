using BurgerToNightAPI.Models;

namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IOrderDetailRepo:IRepository<OrderDetail>
    {
        Task<OrderDetail> UpdateAsync(OrderDetail entity);
    }
}
