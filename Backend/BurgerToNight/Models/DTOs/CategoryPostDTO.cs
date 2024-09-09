using System.ComponentModel.DataAnnotations;

namespace BurgerToNightAPI.Models.DTOs
{
    public class CategoryPostDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public string Icon { get; set; }
    }
}
