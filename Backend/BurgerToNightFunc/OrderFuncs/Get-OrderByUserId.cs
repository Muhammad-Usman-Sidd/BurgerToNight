using AutoMapper;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightFunc.Attributes;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BurgerToNightFunc.Orders
{
    public class Get_OrderByUserId
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;

        public Get_OrderByUserId(IUnitOfWork unitOfWork, IMapper mapper, IUserRepo userRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        [Authorize(roles: "customer")]
        [Function("GetUserOrders")]
        public async Task<APIResponse> GetUserOrders(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "orders/{userId}")] HttpRequestData req, string userId)
        {
            var response = new APIResponse();

            try
            {
                var orders = await _unitOfWork.OrderHeaders.GetAllAsync(u => u.UserId == userId);

                if (orders == null || !orders.Any())
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add("No orders found for the specified user.");
                }
                else
                {
                    var orderDTOs = new List<OrderGetDTO>();

                    foreach (var order in orders)
                    {
                        var orderDetails = await _unitOfWork.OrderDetails.GetAllAsync(u => u.OrderHeaderId == order.Id);
                        var orderDTO = _mapper.Map<OrderGetDTO>(order);

                        orderDTO.Items = orderDetails.Select(detail => new OrderDetailDTO
                        {
                            ProductId = detail.ProductId,
                            Quantity = detail.Quantity,
                            Price = detail.Price
                        }).ToList();

                        orderDTOs.Add(orderDTO);
                    }

                    response.StatusCode = HttpStatusCode.OK;
                    response.IsSuccess = true;
                    response.Result = orderDTOs;
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