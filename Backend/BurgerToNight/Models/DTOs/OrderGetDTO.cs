using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BurgerToNightAPI.Models.DTOs
{
    public class OrderGetDTO
    {
        public int Id { get; set; }
        public string? OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public string? PaymentStatus { get; set; }

        public DateTime PaymentDate { get; set; }
        public double OrderTotal { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        public string? Name { get; set; }
        public List<OrderDetailGetDTO> Items { get; set; }
    }
}
