using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace BurgerToNight.Models
{
    public class BurgerProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int BCategoryId { get; set; }
        [ForeignKey("BCategoryId")]
        [ValidateNever]
        public BurgerCategory? BurgerCategory { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public DateTime CreationDate { get; set; }
        public int? PreparingTime { get; set; }

    }
}
