using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerToNight.Models.DTOs
{
    public class BProductUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int BCategoryId { get; set; }
        [ForeignKey("BCategoryId")]
        [ValidateNever]
        public BurgerCategory? burgerCategory { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int? PreparingTime { get; set; }
    }
}
