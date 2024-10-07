using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightFunc.Attributes;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace BurgerToNightFunc.Auth
{
    public class ResetPassword
    {
        private readonly IUserRepo _userRepo;

        public ResetPassword(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        [Authorize(roles: ["customer", "admin"])]
        [Function("ResetPassword")]
        public async Task<APIResponse> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "AuthResetPassword")] HttpRequestData req,
            FunctionContext context)
        {
            var log = context.GetLogger("ResetPassword");
            var response = new APIResponse();

            try
            {
                var token = req.Headers.GetValues("Authorization").FirstOrDefault();
                if (token == null)
                {
                    response.StatusCode = HttpStatusCode.Unauthorized;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Unauthorized");
                    return response;
                }
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var resetPasswordDTO = JsonConvert.DeserializeObject<ResetPasswordDTO>(requestBody);

                if (string.IsNullOrEmpty(resetPasswordDTO.UserId))
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("User ID is missing.");
                    return response;
                }

                var result = await _userRepo.ResetPassword(resetPasswordDTO.UserId, resetPasswordDTO);

                if (!result)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Password reset failed.");
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Result = "Password reset successful.";
                }
            }
            catch (Exception ex)
            {
                log.LogError($"Error during password reset: {ex.Message}");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add($"Internal server error: {ex.Message}");
            }

            return response;
        }
    }
}
