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
    public class Edit_Product
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Edit_Product(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Function("EditProduct")]
        public async Task<APIResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "ProductAPI/{id}")] HttpRequestData req,
            FunctionContext context, int id)
        {
            var log = context.GetLogger("EditProduct");
            var response = new APIResponse();

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var updateDTO = JsonConvert.DeserializeObject<BProductUpdateDTO>(requestBody);

                if (updateDTO == null || id != updateDTO.Id)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Error: ID mismatch or DTO is null.");
                    return response;
                }
                if (await _unitOfWork.BCategories.GetAsync(u => u.Id == updateDTO.BCategoryId) == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Error: BCategoryID mismatch or is null.");
                    return response;
                }
                BurgerProduct model = _mapper.Map<BurgerProduct>(updateDTO);

                await _unitOfWork.BProducts.UpdateAsync(model);
                response.StatusCode = HttpStatusCode.NoContent;
                response.IsSuccess = true;
                return (response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return response;
        }
    }
}
