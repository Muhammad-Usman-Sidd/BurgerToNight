using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerToNightAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; }
        public string? City { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
