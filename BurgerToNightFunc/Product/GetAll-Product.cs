using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository.IRepository;
using AutoMapper;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace BurgerToNightFunc.Product
{
    public class GetAll_Product
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAll_Product(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Function("GetAllProduct")]
        public async Task<APIResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ProductAPI")] HttpRequestData req,
            FunctionContext context)
        {
            var log = context.GetLogger("GetAllProduct");
            var response = new APIResponse();

            try
            {
                var products = await _unitOfWork.BProducts.GetAllAsync();
                if (products == null || !products.Any())
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("No products found.");
                    return response;
                }

                var productDTOs = new List<BProductGetDTO>();
                foreach (var item in products)
                {
                    var burgerCategory = await _unitOfWork.BCategories.GetAsync(c => c.Id == item.BCategoryId);
                    var mappedProduct = _mapper.Map<BProductGetDTO>(item);
                    mappedProduct.burgerCategory = burgerCategory?.Title;
                    productDTOs.Add(mappedProduct);
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Result = productDTOs;
            }
            catch (Exception ex)
            {
                log.LogError($"Error getting products: {ex.Message}");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add($"Internal server error: {ex.Message}");
            }

            return response;
        }
    }
}
