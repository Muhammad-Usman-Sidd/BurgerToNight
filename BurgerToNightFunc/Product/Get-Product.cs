using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;
using AutoMapper;
using BurgerToNightAPI.Models.DTOs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace BurgerToNightFunc.Product
{
    public class Get_Product
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_Product(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Function("GetProduct")]
        public async Task<APIResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ProductAPI/{id}")] HttpRequestData req,
            FunctionContext context, int id)
        {
            var log = context.GetLogger("GetProduct");
            var response = new APIResponse();

            try
            {
                var product = await _unitOfWork.BProducts.GetAsync(u => u.Id == id);
                if (product == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add($"Product with id {id} not found.");
                    return response;
                }

                var mappedProduct = _mapper.Map<BProductGetDTO>(product);
                var burgerCategory = await _unitOfWork.BCategories.GetAsync(c => c.Id == mappedProduct.BCategoryId);
                mappedProduct.burgerCategory = burgerCategory?.Title;

                response.StatusCode = HttpStatusCode.OK;
                response.Result = mappedProduct;
            }
            catch (Exception ex)
            {
                log.LogError($"Error getting product with id {id}: {ex.Message}");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add($"Internal server error: {ex.Message}");
            }

            return response;
        }
    }
}
