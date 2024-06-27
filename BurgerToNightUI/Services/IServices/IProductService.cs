using BurgerToNightUI.Models.DTO;
using BurgerToNightUI.Models;
using BurgerToNightUI.Models.VM;
using BurgerToNight.Models.DTOs;

namespace BurgerToNightUI.Services.IServices
{
    public interface IProductService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(BProductPostDTO dto);
        Task<T> UpdateAsync<T>(BProductUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
