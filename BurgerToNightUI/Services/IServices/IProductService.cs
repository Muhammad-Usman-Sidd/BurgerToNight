using BurgerToNightUI.Models.DTO;
using BurgerToNightUI.Models;
using BurgerToNightUI.Models.VM;
using BurgerToNightAPI.Models.DTOs;

namespace BurgerToNightUI.Services.IServices
{
    public interface IProductService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(BProductPostDTO dto, string token);
        Task<T> UpdateAsync<T>(BProductUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
