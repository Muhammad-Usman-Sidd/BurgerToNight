using System.Net;
using AutoMapper;
using BurgerToNightAPI.Data;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BurgerToNightFunc.Category
{
    public class Create_Category
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public Create_Category(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [Function("CreateCategory")]
        public async Task<APIResponse> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "CategoryAPI")] HttpRequestData req,
        FunctionContext context)
        {
            var response = new APIResponse();
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var createDTO = JsonConvert.DeserializeObject<BCategoryGetDTO>(requestBody);

                if (createDTO == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Invalid input");
                    return response;
                }
                var model = _mapper.Map<BurgerCategory>(createDTO);

                await _unitOfWork.BCategories.CreateAsync(model);
                await _unitOfWork.BCategories.SaveAsync();

                response.StatusCode = HttpStatusCode.Created;
                response.Result = model;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add($"Internal server error: {ex.Message}");
            }
            return response;
        }
    }
}
