using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BurgerToNightFunc.Orders
{
    public class Get_OrderByUserId
    {
        private readonly IUnitOfWork _unitOfWork;

        public Get_OrderByUserId(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Function("GetUserOrders")]
        public async Task<APIResponse> GetUserOrders(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "orders/user/{userId}")] HttpRequestData req, string userId)
        {
            var response = new APIResponse();

            try
            {
                var orders = await _unitOfWork.OrderHeaders.GetAsync(u => u.UserId == userId);

                if (orders == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("No orders found for the specified user.");
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.IsSuccess = true;
                    response.Result = orders;
                }

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

