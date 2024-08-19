using BurgerToNightAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurgerToNightAPI.Repository.IRepository
{
    public interface ICategoryRepo:IRepository<Category>
    {
        Task<Category> UpdateAsync(Category entity);

    }
}
