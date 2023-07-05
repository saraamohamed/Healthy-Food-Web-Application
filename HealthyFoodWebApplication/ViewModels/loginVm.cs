using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace HealthyFoodWebApplication.ViewModels
{
    [Authorize]
    public class loginVm
    {
        [Key]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
