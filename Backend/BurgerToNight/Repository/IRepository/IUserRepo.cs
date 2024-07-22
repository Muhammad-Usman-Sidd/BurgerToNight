using BurgerToNightAPI.Models.DTOs;

namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IUserRepo
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegistrationRequestDTO registerationRequestDTO);
        Task<bool> ResetPassword(string userId, ResetPasswordDTO passwordChangeDTO);
    }
}
