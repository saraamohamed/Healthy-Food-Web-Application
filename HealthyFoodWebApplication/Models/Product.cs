using System.ComponentModel;
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
        [MinLength(3, ErrorMessage = "The name must be at least 3 characters long.")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceBeforeSale { get; set; }

        public string? Image { get; set; }
        [Required(ErrorMessage = "Please select a category for the product.")]
        public ProductType Category { get; set; }

        [DefaultValue(1)]
        public int Quantity { get; set; } = 1;
        public bool IsDeleted { get; set; }=false;
    }
}
