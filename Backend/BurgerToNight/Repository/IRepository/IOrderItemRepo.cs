using BurgerToNightAPI.Models;

namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IOrderItemRepo:IRepository<OrderItem>
    {
        Task<OrderItem> UpdateAsync(OrderItem entity);

    }
}
