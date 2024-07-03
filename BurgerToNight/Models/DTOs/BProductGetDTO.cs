using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;


namespace BurgerToNightAPI.Models.DTOs
{
    public class BProductGetDTO
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        public int BCategoryId { get; set; }
        [Range(5, 200)]
        public int Price { get; set; }
        public int? PreparingTime { get; set; }
        public string? Image { get; set; }

    }
}
