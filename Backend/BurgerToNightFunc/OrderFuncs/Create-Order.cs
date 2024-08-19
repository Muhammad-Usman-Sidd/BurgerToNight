using AutoMapper;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightFunc.Attributes;
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
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;
        public Create_Order(IUnitOfWork unitOfWork, IMapper mapper, IUserRepo userRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        [Authorize(roles: "customer")]
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
                
                if (orderDTO == null || !orderDTO.Items.Any())
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("Invalid input");
                    return response;
                }

                var orderHeaderobj = _mapper.Map<OrderHeader>(orderDTO);
                orderHeaderobj.OrderDate = DateTime.UtcNow;
                orderHeaderobj.OrderStatus = "Order Accepted";
                orderHeaderobj.PaymentStatus = "Pending";
   

                await _unitOfWork.OrderHeaders.CreateAsync(orderHeaderobj);
                await _unitOfWork.SaveAsync();

                foreach (var Item in orderDTO.Items)
                {
                    var orderDetail = new OrderDetail
                    {
                        orderHeader = orderHeaderobj,
                        OrderHeaderId = orderHeaderobj.Id,
                        ProductId = Item.ProductId,
                        burgerProduct = await _unitOfWork.Products.GetAsync(u => u.Id == Item.ProductId),
                        Quantity = Item.Quantity,
                        Price = Item.Price
                    };
                    await _unitOfWork.OrderDetails.CreateAsync(orderDetail);
                }
                await _unitOfWork.SaveAsync();
                var dto = _mapper.Map<OrderGetDTO>(orderDTO);

                response.StatusCode = HttpStatusCode.Created;
                response.IsSuccess = true;
                response.Result = dto;
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
