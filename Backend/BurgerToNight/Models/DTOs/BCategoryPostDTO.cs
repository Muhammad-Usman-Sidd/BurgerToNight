using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BurgerToNightAPI.Models.DTOs
{
    public class BCategoryPostDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }

    }
}
