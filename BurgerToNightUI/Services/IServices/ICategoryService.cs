using BurgerToNight.Models;
using BurgerToNightUI.Models;
using BurgerToNightUI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BurgerToNightUI.Services.IServices
{

    public interface ICategoryService :IBaseService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(BCategoryCreateDTO dto);
        Task<T> UpdateAsync<T>(BCategoryUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }

}