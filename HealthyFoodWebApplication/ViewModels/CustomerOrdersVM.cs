using HealthyFoodWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace HealthyFoodWebApplication.ViewModels
{
    public class CustomerOrdersVM
    {
        [Key]
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; } 
        public string? TotalPrice { get; set; }
        public Logger Logger { get; set; } = null!;
        public ShoppingBagItem shoppingBagItem { get; set; }    




    }
}
