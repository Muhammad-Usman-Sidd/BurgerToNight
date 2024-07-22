using AutoMapper;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BurgerToNightAPI.Data;
using BurgerToNightAPI.Repository.IRepository;
using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;

namespace BurgerToNightAPI.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly BurgerDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string secretKey;
        private readonly IMapper _mapper;

        public UserRepo(BurgerDbContext db, IConfiguration configuration,
            UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _db=db;
            _mapper = mapper;
            _userManager = userManager;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _roleManager = roleManager;
        }

        public bool IsUniqueUser(string username)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _db.ApplicationUsers
                .FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower());
            var IsValid = BCrypt.Net.BCrypt.Verify(loginRequestDTO.Password, user.PasswordHash);
            if (user == null || IsValid==false)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }

            // If user was found, generate JWT Token
            var roles = await _userManager.GetRolesAsync(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.UserName.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = _mapper.Map<UserDTO>(user),
            };
            return loginResponseDTO;
        }
        public async Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDTO.UserName,
                Email = registrationRequestDTO.UserName,
                NormalizedEmail = registrationRequestDTO.UserName.ToUpper(),
                Name = registrationRequestDTO.Name,
            };

            try
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registrationRequestDTO.Password);
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole("admin"));
                        await _roleManager.CreateAsync(new IdentityRole("customer"));
                    }
                    await _userManager.AddToRoleAsync(user, "admin");
                    var userToReturn = _db.ApplicationUsers
                        .FirstOrDefault(u => u.UserName == registrationRequestDTO.UserName);
                    return _mapper.Map<UserDTO>(userToReturn);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return new UserDTO();
        }
        public async Task<bool> ResetPassword(string userId, ResetPasswordDTO passwordChangeDTO)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            if (!BCrypt.Net.BCrypt.Verify(passwordChangeDTO.CurrentPassword, user.PasswordHash))
            {
                return false; 
            }

            var newPasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordChangeDTO.NewPassword);
            user.PasswordHash = newPasswordHash;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

    }
}
