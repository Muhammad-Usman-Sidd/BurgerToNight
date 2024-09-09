using AutoMapper;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightFunc.Attributes;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BurgerToNightFunc.Auth
{
    public class GetUserDetails
    {
        private readonly ILogger<GetUserDetails> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public GetUserDetails(ILogger<GetUserDetails> logger, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _logger = logger;
            _userManager = userManager;
            _mapper = mapper;
        }

        [Authorize(roles: "customer")]
        [Function("GetUserDetails")]
        public async Task<APIResponse> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "user/{UserId}")] HttpRequestData req, string userId)
        {
            var response = new APIResponse();
            try
            {

                if (string.IsNullOrEmpty(userId))
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("User ID is missing");
                    return response;
                }

                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("User not found");
                    return response;
                }
                var userDTO = _mapper.Map<UserDTO>(user);
                response.StatusCode = HttpStatusCode.OK;
                response.Result = userDTO;
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add("Internal server error");
                return response;
            }
        }
    }
}
