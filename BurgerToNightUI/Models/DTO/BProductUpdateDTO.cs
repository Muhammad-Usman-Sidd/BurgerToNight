using BurgerToNight.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BurgerToNightUI.Extension;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BurgerToNightUI.Models.DTO
{
    public class BProductUpdateDTO
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

        [Range(5, 60)]
        public int PreparingTime { get; set; }

        public string Description { get; set; }
    }
}
