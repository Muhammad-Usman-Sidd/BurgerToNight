using BurgerToNight.Utility;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightUI.Models;
using BurgerToNightUI.Models.DTO;
using BurgerToNightUI.Models.VM;
using BurgerToNightUI.Services;
using BurgerToNightUI.Services.IServices;
using Newtonsoft.Json.Linq;

namespace BurgerToNightUI.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string productUrl;

        public ProductService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            productUrl = configuration.GetValue<string>("ServiceUrls:UrlAPI");

        }

        public Task<T> CreateAsync<T>(BProductPostDTO dto,string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = productUrl + "/ProductAPI/",
                Token=token
            });
        }

        public Task<T> DeleteAsync<T>(int id,string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = productUrl + "/ProductAPI/" + id,
                Token=token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = productUrl  +"/ProductAPI/",
                Token=token
            });
        }

        public Task<T> GetAsync<T>(int id,string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = productUrl + "/ProductAPI/" + id,
                Token=token
            });
        }

        public Task<T> UpdateAsync<T>(BProductUpdateDTO dto,string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = productUrl + "/ProductAPI/" + dto.Id,
                Token=token
            });
        }
    }
}
