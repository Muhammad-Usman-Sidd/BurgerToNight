namespace BurgerToNightAPI.Models.DTOs
{

    public class OrderDetailGetDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
