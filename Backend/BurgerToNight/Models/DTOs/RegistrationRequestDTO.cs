﻿namespace BurgerToNightAPI.Models.DTOs
{
    public class RegistrationRequestDTO
    {
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }

        public string Password { get; set; }
        public string? Role { get; set; }
        public string? SecretKey { get; set; }
    }
}

