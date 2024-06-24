using BurgerToNightUI.Models.DTO;
using BurgerToNightUI.Models;

namespace BurgerToNightUI.Services.IServices
{
    public interface IProductService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(BProductCreateDTO dto);
        Task<T> UpdateAsync<T>(BProductUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
