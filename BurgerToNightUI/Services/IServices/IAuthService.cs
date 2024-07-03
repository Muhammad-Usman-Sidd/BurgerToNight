using BurgerToNightUI.Models.DTO;

namespace BurgerToNightUI.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO obj);
        Task<T> RegisterAsync<T>(RegistrationRequestDTO obj);
        Task<T> ResetPassword<T>(ResetPasswordDTO obj);
    }
}
