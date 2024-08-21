namespace BurgerToNightAPI.Models.DTOs
{
    public class OrderCreateDTO
    {
        public string UserId { get; set; }
        public double OrderTotal { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        public string? Name { get; set; }
        public List<OrderDetailCreateDTO> Items { get; set; }
    }
}
