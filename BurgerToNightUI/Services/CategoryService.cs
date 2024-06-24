using BurgerToNight.Utility;
using BurgerToNightUI.Models;
using BurgerToNightUI.Models.DTO;
using BurgerToNightUI.Services;
using BurgerToNightUI.Services.IServices;
using Newtonsoft.Json;

namespace BurgerToNightUI.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string categoryUrl;

        public CategoryService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            categoryUrl = configuration.GetValue<string>("ServiceUrls:UrlAPI");

        }

        public Task<T> CreateAsync<T>(BCategoryCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = categoryUrl + "/CategoryAPI/"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = categoryUrl + "/CategoryAPI/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = categoryUrl + "/CategoryAPI/"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = categoryUrl + "/CategoryAPI/" + id
            });
        }

        public Task<T> UpdateAsync<T>(BCategoryUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = categoryUrl + "/CategoryAPI/" + dto.Id
            });

        }
    }
}
