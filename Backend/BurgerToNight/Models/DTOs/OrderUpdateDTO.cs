namespace BurgerToNightAPI.Models.DTOs
{
    public class OrderUpdateDTO
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
    }
}
