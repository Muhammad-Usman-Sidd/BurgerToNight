using BurgerToNightAPI.Models;

namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IBProductRepo:IRepository<BurgerProduct>
    {
        Task<BurgerProduct> UpdateAsync(BurgerProduct entity);

    }
}
