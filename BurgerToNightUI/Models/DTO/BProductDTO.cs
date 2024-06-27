using BurgerToNight.Models;
using BurgerToNightUI.Extension;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerToNightUI.Models.DTO
{
    public class BProductDTO
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public int BCategoryId { get; set; }
        [ForeignKey("BCategoryId")]
        [ValidateNever]
        public BCategoryDTO burgerCategory { get; set; }
        [Range(5, 200)]
        public int Price { get; set; }
        public string PriceInCurrency => Price.ToCurrency();
        public string TimeInMinutes => PreparingTime.ToMinutes();
        [Range(5, 60)]
        public int PreparingTime { get; set; }
        public string? Image { get; set; }
        public string? ExistingImage { get; set; }
        public string? ExistingImageType { get; set; }
    }
}

