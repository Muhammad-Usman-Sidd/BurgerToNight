namespace BurgerToNightAPI.Models.DTOs
{
    public class CategoryUpdateDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public string? ExistingIcon { get; set; }

    }
}

