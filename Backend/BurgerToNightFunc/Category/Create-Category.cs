using System.Net;
using AutoMapper;
using BurgerToNightAPI.Data;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightFunc.Attributes;
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
        private readonly IUserRepo _userRepo;

        public Create_Category(IMapper mapper, IUnitOfWork unitOfWork, IUserRepo userRepo)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepo = userRepo;
        }

        [Authorize(roles: "admin")]
        [Function("CreateCategory")]
        public async Task<APIResponse> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "CategoryAPI")] HttpRequestData req,
        FunctionContext context)
         {
            var response = new APIResponse();
            try
            {
              
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var createDTO = JsonConvert.DeserializeObject<BCategoryPostDTO>(requestBody);

                if (createDTO == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Invalid input");
                    return response;
                }
                var model = _mapper.Map<BurgerCategory>(createDTO);

                await _unitOfWork.BCategories.CreateAsync(model);
                await _unitOfWork.SaveAsync();

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
