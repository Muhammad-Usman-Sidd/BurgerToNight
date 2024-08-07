using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<APIResponse> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "orders")] HttpRequestData req,
            FunctionContext context)
        {
            var response = new APIResponse();

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var orderDTO = JsonConvert.DeserializeObject<OrderCreateDTO>(requestBody);

                if (orderDTO == null || !orderDTO.OrderDetails.Any())
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Invalid input");
                    return response;
                }

                var orderHeader = new OrderHeader
                {
                    UserId = orderDTO.UserId,
                    OrderDate = DateTime.UtcNow,
                    OrderTotal = orderDTO.OrderTotal,
                    OrderStatus = "Pending",
                    PaymentStatus = "Pending",
                    PhoneNumber = orderDTO.PhoneNumber,
                    Address = orderDTO.Address,
                    City = orderDTO.City,
                    Name = orderDTO.Name,
                };

                await _unitOfWork.OrderHeaders.CreateAsync(orderHeader);
                await _unitOfWork.SaveAsync();

                foreach (var detail in orderDTO.OrderDetails)
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderHeaderId = orderHeader.Id,
                        ProductId = detail.ProductId,
                        Quantity = detail.Quantity,
                        Price = detail.Price
                    };
                    await _unitOfWork.OrderDetails.CreateAsync(orderDetail);
                }
                await _unitOfWork.SaveAsync();

                response.StatusCode = HttpStatusCode.Created;
                response.IsSuccess = true;
                response.Result = orderHeader;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages.Add($"Internal server error: {ex.Message}");
            }

            return response;
        }
    }
}
