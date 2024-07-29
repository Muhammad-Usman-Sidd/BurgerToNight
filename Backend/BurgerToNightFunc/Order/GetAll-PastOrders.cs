using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BurgerToNightFunc.Order
{
    public class GetAll_PastOrders
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAll_PastOrders(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Function("GetAll_PastOrders")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "PastOrders")] HttpRequestData req,
            FunctionContext context)
        {
            var log = context.GetLogger("GetAll_PastOrders");
            var response = req.CreateResponse();

            try
            {
                // Fetch past orders from the repository
                var pastOrders = await _unitOfWork.OrderDetails.GetAllAsync();

                if (pastOrders == null || !pastOrders.Any())
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    await response.WriteAsJsonAsync(new
                    {
                        IsSuccess = false,
                        ErrorMessages = new[] { "No past orders found." }
                    });
                    return response;
                }

                var pastOrdersDTO = pastOrders.Select(order => new
                {
                    order.OrderId,
                    order.OrderDate,
                    Items = order.Items.Select(item => new
                    {
                        item.ProductId,
                        item.Quantity,
                        item.Price
                    }),
                    TotalPrice = order.TotalPrice
                });

                // Return successful response
                response.StatusCode = HttpStatusCode.OK;
                await response.WriteAsJsonAsync(new
                {
                    IsSuccess = true,
                    Result = pastOrdersDTO
                });
            }
            catch (Exception ex)
            {
                log.LogError($"Error fetching past orders: {ex.Message}");

                // Return error response
                response.StatusCode = HttpStatusCode.InternalServerError;
                await response.WriteAsJsonAsync(new
                {
                    IsSuccess = false,
                    ErrorMessages = new[] { $"Internal server error: {ex.Message}" }
                });
            }

            return response;
        }
    }
}
