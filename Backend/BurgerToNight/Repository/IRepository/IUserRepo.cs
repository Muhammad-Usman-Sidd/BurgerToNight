using BurgerToNightAPI.Models.DTOs;
using System.Security.Claims;

namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IUserRepo
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegistrationRequestDTO registerationRequestDTO);
        Task<bool> ResetPassword(string userId, ResetPasswordDTO passwordChangeDTO);
        Task<List<UserDTO>> GetAllUsersAsync();
    }
}
