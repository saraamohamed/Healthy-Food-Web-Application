﻿using System.ComponentModel.DataAnnotations;

namespace HealthyFoodWebApplication.Models
{
    public class Logger
    {
        [MinLength(7)]
        [MaxLength(20)]
        public string FullName { get; set; }

        [Key]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [RegularExpression(@"^01[1235][0-9]{8}$", ErrorMessage = "Invalid phone number, please enter valid phone number")]
        [MinLength(11)]
        public string PhoneNumber { get; set; }


        [EmailAddress]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        [Required]
        public string Role { get; set; }

        // Navigation Properties
        public ICollection<ShoppingBagItem> ShoppingBagItems { get; set; } = new List<ShoppingBagItem>();
    }
}
