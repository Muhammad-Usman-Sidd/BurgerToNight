using BurgerToNightAPI.Models.DTOs;
using System.Security.Claims;

namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IUserRepo
    {
        bool IsUniqueUser(string username);
        ClaimsPrincipal GetPrincipalFromToken(string token);

        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegistrationRequestDTO registerationRequestDTO);
        Task<bool> ResetPassword(string userId, ResetPasswordDTO passwordChangeDTO);
    }
}
