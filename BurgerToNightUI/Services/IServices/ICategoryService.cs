using BurgerToNightUI.Models;
using BurgerToNightUI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BurgerToNightUI.Services.IServices
{

    public interface ICategoryService :IBaseService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(BCategoryCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(BCategoryEditDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }

}