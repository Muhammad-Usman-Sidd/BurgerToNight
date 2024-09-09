using AutoMapper;
using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightFunc.Attributes;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace BurgerToNightFunc.Orders
{
    public class GetAll_Order
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;

        public GetAll_Order(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [Authorize(roles: "admin")]
        [Function("GetAllOrders")]
        public async Task<APIResponse> GetAllOrders(
    [HttpTrigger(AuthorizationLevel.Function, "get", Route = "orders")] HttpRequestData req)
        {
            var response = new APIResponse();

            try
            {
                var orders = await _unitOfWork.OrderHeaders.GetAllAsync();

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

                        orderDTO.Items = new List<OrderDetailGetDTO>();
                        foreach (var detail in orderDetails)
                        {
                            var orderDetailDTO = new OrderDetailGetDTO
                            {
                                Id = detail.Id,
                                ProductId = detail.ProductId,
                                product = await _unitOfWork.Products.GetAsync(u => u.Id == detail.ProductId),
                                Quantity = detail.Quantity,
                                Price = detail.Price
                            };
                            orderDTO.Items.Add(orderDetailDTO);
                        }

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