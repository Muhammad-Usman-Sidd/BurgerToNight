using BurgerToNight.Models;

namespace BurgerToNight.Repository.IRepository
{
    public interface IBProductRepo:IRepository<BurgerProduct>
    {
        Task<BurgerProduct> UpdateAsync(BurgerProduct entity);

    }
}
