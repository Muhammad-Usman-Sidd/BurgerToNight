using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace BurgerToNightFunc.Orders
{
    public class UpdateOrder
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Function("UpdateOrder")]
        public async Task<APIResponse> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "orders/{orderId}")] HttpRequestData req,
            FunctionContext context, int orderId)
        {
            var log = context.GetLogger("UpdateOrder");
            var response = new APIResponse();

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var orderDTO = JsonConvert.DeserializeObject<OrderUpdateDTO>(requestBody);

                if (orderDTO == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Invalid input");
                    return response;
                }

                var orderHeader = await _unitOfWork.OrderHeaders.GetAsync(o => o.Id == orderId);
                if (orderHeader == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Order not found");
                    return response;
                }

                orderHeader.OrderStatus = orderDTO.OrderStatus ?? orderHeader.OrderStatus;
                orderHeader.PaymentStatus = orderDTO.PaymentStatus ?? orderHeader.PaymentStatus;

                _unitOfWork.OrderHeaders.Update(orderHeader);
                await _unitOfWork.SaveAsync();

                response.StatusCode = HttpStatusCode.OK;
                response.IsSuccess = true;
                response.Result = orderHeader;
            }
            catch (Exception ex)
            {
                log.LogError($"Error updating order: {ex.Message}");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add($"Internal server error: {ex.Message}");
            }

            return response;
        }
    }
}
