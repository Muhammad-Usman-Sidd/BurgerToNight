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
    public class ResetPassword
    {
        private readonly IUserRepo _userRepo;

        public ResetPassword(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [Function("ResetPassword")]
        public async Task<APIResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "AuthResetPassword")] HttpRequestData req,
            FunctionContext context)
        {
            var log = context.GetLogger("ResetPassword");
            var response = new APIResponse();

            try
            {
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var resetPasswordDTO = JsonConvert.DeserializeObject<ResetPasswordDTO>(requestBody);

                var userId = req.Headers.GetValues("userId").FirstOrDefault();
                if (string.IsNullOrEmpty(userId))
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("User ID is missing.");
                    return response;
                }

                var result = await _userRepo.ResetPassword(userId, resetPasswordDTO);

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