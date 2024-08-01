using System;
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

namespace BurgerToNightFunc.Auth
{
    public class Login
    {
        private readonly IUserRepo _userRepo;

        public Login(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [Function("Login")]
        public async Task<APIResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "AuthLogin")] HttpRequestData req,
            FunctionContext context)
        {
            var log = context.GetLogger("Login");
            var response = new APIResponse();

            try
            {
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var loginRequestDTO = JsonConvert.DeserializeObject<LoginRequestDTO>(requestBody);

                var result = await _userRepo.Login(loginRequestDTO);

                if (result.Token == "")
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Invalid username or password.");
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Result = result;
                }
            }
            catch (Exception ex)
            {
                log.LogError($"Error during login: {ex.Message}");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add($"Internal server error: {ex.Message}");
            }

            return response;
        }
    }
}
