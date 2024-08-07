using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BurgerToNightFunc.Orders
{
    public class DeleteOrder
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Function("DeleteOrder")]
        public async Task<APIResponse> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "orders/{orderId}")] HttpRequestData req,
            FunctionContext context, int orderId)
        {
            var log = context.GetLogger("DeleteOrder");
            var response = new APIResponse();

            try
            {
                var orderHeader = await _unitOfWork.OrderHeaders.GetAsync(o => o.Id == orderId);
                if (orderHeader == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Order not found");
                    return response;
                }

                await _unitOfWork.OrderHeaders.RemoveAsync(orderHeader);
                await _unitOfWork.SaveAsync();

                response.StatusCode = HttpStatusCode.NoContent;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                log.LogError($"Error deleting order: {ex.Message}");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add($"Internal server error: {ex.Message}");
            }

            return response;
        }
    }
}
