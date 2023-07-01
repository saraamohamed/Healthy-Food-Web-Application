using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthyFoodWebApplication.Models
{
    public enum ProductType
    {
        Vegetable=1,
        Fruit=2,
        Fresh=3
    }
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for the product.")]
        [MinLength(2, ErrorMessage = "The name must be at least 2 characters long.")]
        public string Name { get; set; }
        public float Price { get; set; }
        public float? PriceBeforeSale { get; set; }

        public string? Image { get; set; }
        [Required(ErrorMessage = "Please select a category for the product.")]
        public ProductType Category { get; set; }
        public bool IsDeleted { get; set; }=false;
    }
}
