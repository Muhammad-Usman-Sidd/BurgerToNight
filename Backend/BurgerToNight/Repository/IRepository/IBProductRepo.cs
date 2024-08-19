using BurgerToNightAPI.Models;

namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IProductRepo:IRepository<Product>
    {
        Task<Product> UpdateAsync(Product entity);

    }
}
