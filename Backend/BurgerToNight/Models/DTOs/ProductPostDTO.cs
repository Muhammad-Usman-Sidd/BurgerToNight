using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerToNightAPI.Models.DTOs
{
    public class ProductPostDTO
    {
        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public string? Description { get; set; }
        public int Price { get; set; }
        public int? PreparingTime { get; set; }
        public string? Image { get; set; }

    }
}

