using BurgerToNightAPI.Models;
using BurgerToNightAPI.Models.DTOs;

namespace BurgerToNightAPI.Repository.IRepository
{
    public interface IOrderHeaderRepo : IRepository<OrderHeader>
    {
        void Update(OrderHeader obj);
        void UpdateStatus(int id, OrderUpdateDTO orderStatus, string? paymentStatus = null);
        void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId);
    }

}
