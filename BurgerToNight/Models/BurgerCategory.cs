using System.ComponentModel.DataAnnotations;

namespace BurgerToNight.Models
{
    public class BurgerCategory
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationCategoryTime { get; set; }
    }
}
