using BurgerToNightAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IBCategoryRepo:IRepository<BurgerCategory>
    {
        Task<BurgerCategory> UpdateAsync(BurgerCategory entity);

    }
}
