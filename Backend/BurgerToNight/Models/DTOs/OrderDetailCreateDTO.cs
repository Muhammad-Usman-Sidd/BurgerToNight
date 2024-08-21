namespace BurgerToNightAPI.Models.DTOs
{
    public class OrderDetailCreateDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
