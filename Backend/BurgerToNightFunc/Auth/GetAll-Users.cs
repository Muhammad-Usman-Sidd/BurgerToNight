
using AutoMapper;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.Azure.Functions.Worker;
using System.Net;
using BurgerToNightFunc.Attributes;
using Microsoft.Azure.Functions.Worker.Http;

namespace BurgerToNightFunc.Auth
{
    public class GetAll_Users
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;

        public GetAll_Users(IUnitOfWork unitOfWork, IMapper mapper, IUserRepo userRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        [Authorize(roles: "admin")]
        [Function("GetAllUsers")]
        public async Task<APIResponse> GetAllUsers(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users")] HttpRequestData req)
        {
            var response = new APIResponse();
            try
            {
                var data = await _userRepo.GetAllUsersAsync();
                var Users = new List<UserDTO>();
                foreach (var user in data)
                {
                    var orders = await _unitOfWork.OrderHeaders.GetAllAsync(u => u.UserId == user.Id);
                    if (orders == null || !orders.Any())
                    {
                        response.StatusCode = HttpStatusCode.NotFound;
                        response.IsSuccess = false;
                        response.ErrorMessages.Add("No orders found for the specified user.");
                    }
                    user.TotalOrders = orders.Count();
                    user.TotalAmountSpent = orders.Sum(o => o.OrderTotal);

                    Users.Add(user);
                }
                var topUsers = Users
                 .OrderByDescending(c => c.TotalAmountSpent)
                 .ToList();
                response.StatusCode = HttpStatusCode.OK;
                response.IsSuccess = true;
                response.Result = topUsers;

                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add(ex.Message);
                return response;
            }
        }
    }
}
