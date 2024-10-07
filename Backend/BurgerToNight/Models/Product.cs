using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerToNightAPI.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category? productCategory { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public DateTime CreationDate { get; set; }
        public int? PreparingTime { get; set; }
        public string? Image { get; set; }
        public int? TotalSales { get; set; }
    }
}
