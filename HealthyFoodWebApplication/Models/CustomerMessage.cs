﻿using System.ComponentModel.DataAnnotations;

namespace HealthyFoodWebApplication.Models
{
    public class CustomerMessage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
