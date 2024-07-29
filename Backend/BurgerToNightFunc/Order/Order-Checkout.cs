using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Repository.IRepository;
using System.Net;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;

public class Order_Checkout
{
    private readonly IUnitOfWork _unitOfWork;

    public Order_Checkout(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [Function("OrderCheckout")]
    public async Task<APIResponse> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Checkout")] HttpRequestData req)
    {
        var response = new APIResponse
        {
            StatusCode = HttpStatusCode.OK,
            IsSuccess = true
        };

        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var cartItems = JsonConvert.DeserializeObject<List<CartItem>>(requestBody);

            if (cartItems == null || !cartItems.Any())
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages.Add("No items in the cart.");
                return response;
            }

            var orderDetails = new OrdersDetail
            {
                OrderDate = DateTime.UtcNow,
                Items = cartItems.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList(),
                TotalPrice = cartItems.Sum(item => item.Price * item.Quantity)
            };

            await _unitOfWork.OrderDetails.CreateAsync(orderDetails);
            await _unitOfWork.SaveAsync();

            response.Result = orderDetails;
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.IsSuccess = false;
            response.ErrorMessages.Add($"An error occurred: {ex.Message}");
        }

        return response;
    }
}
