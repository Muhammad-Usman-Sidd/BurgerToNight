using BurgerToNight.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerToNightUI.Models.DTO
{
    public class BProductCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [DisplayName("Category")]
        public int BCategoryId { get; set; }
        [ForeignKey("BCategoryId"),DisplayName("Category")]
        [ValidateNever]
        public BurgerCategory burgerCategory { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int? PreparingTime { get; set; }

    }
}
