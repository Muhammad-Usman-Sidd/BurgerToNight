using BurgerToNightUI.Models;

namespace BurgerToNightUI.Services.IServices
{
    public interface IBaseService
    {
        APIResponse ResponseModel { get; set; } 
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
