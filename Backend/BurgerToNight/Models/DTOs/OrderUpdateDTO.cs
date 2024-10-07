namespace BurgerToNightAPI.Models.DTOs
{
    public class OrderUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
    }
}
