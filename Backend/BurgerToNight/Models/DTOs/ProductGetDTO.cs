using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace BurgerToNightAPI.Models.DTOs
{
    public class ProductGetDTO
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public string? productCategory { get; set; }
        [Range(5, 200)]
        public int Price { get; set; }
        public int? PreparingTime { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }

    }
}
