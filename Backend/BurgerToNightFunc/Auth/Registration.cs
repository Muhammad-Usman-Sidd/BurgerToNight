using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace BurgerToNightFunc.Auth
{
    public class Register
    {
        private readonly IUserRepo _userRepo;

        public Register(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [Function("Register")]
        public async Task<APIResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "AuthRegister")] HttpRequestData req,
            FunctionContext context)
        {
            var log = context.GetLogger("Register");
            var response = new APIResponse();

            try
            {
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var registrationRequestDTO = JsonConvert.DeserializeObject<RegistrationRequestDTO>(requestBody);

                var result = await _userRepo.Register(registrationRequestDTO);

                if (result == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Registration failed.");
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Result = result;
                }
            }
            catch (Exception ex)
            {
                log.LogError($"Error during registration: {ex.Message}");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add($"Internal server error: {ex.Message}");
            }

            return response;
        }
    }
}
