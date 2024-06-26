using System.ComponentModel.DataAnnotations;

namespace BurgerToNightUI.Models.DTO
{
    public class BCategoryEditDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title must be between 1 and 100 characters", MinimumLength = 1)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
