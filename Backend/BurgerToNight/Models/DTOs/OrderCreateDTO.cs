namespace BurgerToNightAPI.Models.DTOs
{
    public class OrderCreateDTO
    {
        public string UserId { get; set; }
        public List<OrderItem> Items { get; set; }

    }
}
