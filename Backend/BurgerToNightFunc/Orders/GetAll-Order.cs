using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BurgerToNightFunc.Orders
{
    public class GetAll_Order
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAll_Order(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Function("GetAllOrders")]
        public async Task<APIResponse> GetAllOrders(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "orders")] HttpRequestData req,
            string userId)
        {
            var response = new APIResponse();

            try
            {
                var orders = await _unitOfWork.OrderHeaders.GetAllAsync(includeProperties: "OrderDetail");
                if (orders == null || !orders.Any())
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("No orders found.");
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
