using BurgerToNightAPI.Models;

namespace BurgerToNightAPI.Repository.IRepository
{
    public interface ICartRepo :IRepository<Cart>
    {
        Task<Cart> UpdateAsync(Cart entity);
    }
}
