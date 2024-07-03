﻿using BurgerToNightUI.Extension;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerToNightUI.Models.DTO
{
    public class BProductDeleteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BCategoryId { get; set; }
        [ForeignKey("BCategoryId")]
        [ValidateNever]
        public BCategoryDTO burgerCategory { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string PriceInCurrency => Price.ToCurrency();
        public int PreparingTime { get; set; }
        public string TimeInMinutes => PreparingTime.ToMinutes();
    }
}
