using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BurgerToNightFunc.Orders
{
    public class Create_Order
    {
        private readonly IUnitOfWork _unitOfWork;

        public Create_Order(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Function("CreateOrder")]
        public async Task<APIResponse> CreateOrder(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "orders")] HttpRequestData req)
        {
            var response = new APIResponse();

            try
            {
                var token = req.Headers.GetValues("Authorization").FirstOrDefault();
                if (string.IsNullOrEmpty(token))
                {
                    response.StatusCode = HttpStatusCode.Unauthorized;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Unauthorized");
                    return response;
                }

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var createDTO = JsonConvert.DeserializeObject<OrderCreateDTO>(requestBody);

                if (createDTO == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Invalid input");
                    return response;
                }

                var order = new Order
                {
                    UserId = createDTO.UserId,
                    Items = createDTO.Items.Select(i => new OrderItem
                    {
                        ProductId = i.ProductId,
                        Quantity = i.Quantity,
                        Price = i.Price
                    }).ToList(),
                    Status = OrderStatus.Preparing,
                    OrderDate = DateTime.UtcNow
                };

                await _unitOfWork.Orders.CreateAsync(order);

                response.StatusCode = HttpStatusCode.OK;
                response.IsSuccess = true;
                response.Result = order;
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
