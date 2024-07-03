using BurgerToNight.Utility;
using BurgerToNightUI.Models;
using BurgerToNightUI.Services.IServices;
using BurgerToNightUI.Services;
using BurgerToNightUI.Models.DTO;

namespace BurgerToNightUI.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string AuthUrl;

        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            AuthUrl = configuration.GetValue<string>("ServiceUrls:UrlAPI");

        }

        public Task<T> LoginAsync<T>(LoginRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = AuthUrl + "/UsersAuthAPI/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegistrationRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = AuthUrl + "/UsersAuthAPI/register"
            });
        }
        public Task<T> ResetPassword<T>(ResetPasswordDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = AuthUrl + "/UsersAuthAPI/ResetPassword"
            });
        }

    }
}
