using System.ComponentModel.DataAnnotations;

namespace HealthyFoodWebApplication.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public float Price { get; set; } 
        public string Category { get; set; } = null!;
    }
}
