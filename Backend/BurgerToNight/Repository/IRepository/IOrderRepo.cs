using BurgerToNightAPI.Models;

namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IOrderRepo :IRepository<Order>
    {
        Task<Order> UpdateAsync(Order entity);

    }
}
