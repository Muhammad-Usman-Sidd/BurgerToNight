
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
    public class Get_Top_Customers
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;

        public Get_Top_Customers(IUnitOfWork unitOfWork, IMapper mapper, IUserRepo userRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        [Authorize(roles: "admin")]
        [Function("GetTopCustomers")]
        public async Task<APIResponse> GetTopCustomers(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users/top-customers")] HttpRequestData req)
        {
            var response = new APIResponse();

            try
            {
                var users = await _userRepo.GetAllUsersAsync();
                var customers = new List<UserDTO>();
                foreach (var user in users)
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

                    customers.Add(user);
                }
                 var topCustomers = customers
                  .OrderByDescending(c=>c.TotalAmountSpent)
                  .Take(3)
                  .ToList();

                response.StatusCode = HttpStatusCode.OK;
                response.IsSuccess = true;
                response.Result = topCustomers;

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