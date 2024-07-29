using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BurgerToNightAPI.Models
{
    public class OrdersDetail
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalPrice { get; set; }
    }
}
