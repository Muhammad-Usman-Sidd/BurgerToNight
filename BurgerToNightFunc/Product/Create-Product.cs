using System.IO;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BurgerToNightFunc.Product
{
    public class Create_Product
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Create_Product(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Function("CreateProduct")]
        public async Task<APIResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "ProductAPI")] HttpRequestData req,
            FunctionContext context)
        {
            var log = context.GetLogger("CreateProduct");
            var response = new APIResponse();

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var createDTO = JsonConvert.DeserializeObject<BProductPostDTO>(requestBody);

                if (createDTO == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Invalid input");
                    return response;
                }

                if (await _unitOfWork.BProducts.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Product already exists");
                    return response;
                }

                if (await _unitOfWork.BCategories.GetAsync(u => u.Id == createDTO.BCategoryId) == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Invalid category ID");
                    return response;
                }

                var product = _mapper.Map<BurgerProduct>(createDTO);
                await _unitOfWork.BProducts.CreateAsync(product);
                await _unitOfWork.SaveAsync();

                var result = _mapper.Map<BProductGetDTO>(product);
                result.burgerCategory = (await _unitOfWork.BCategories.GetAsync(c => c.Id == product.BCategoryId))?.Title;

                response.StatusCode = HttpStatusCode.Created;
                response.Result = result;
            }
            catch (Exception ex)
            {
                log.LogError($"Error creating product: {ex.Message}");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add($"Internal server error: {ex.Message}");
            }

            return response;
        }
    }
}
