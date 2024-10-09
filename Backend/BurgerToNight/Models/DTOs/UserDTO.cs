namespace BurgerToNightAPI.Models.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public int? TotalOrders { get; set; }
        public double? TotalAmountSpent { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}

