//using Microsoft.CodeAnalysis.Scripting;
//using HealthyFoodWebApplication.Models;
//using System.ComponentModel.DataAnnotations;

//namespace HealthyFoodWebApplication.Models
//{
//    //Server side
//    public class UniqueNameAttribute:ValidationAttribute
//    {
    
//        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
//        {
//            //get value
//            string name = value.ToString();
//            Product productFromRequest = validationContext.ObjectInstance as Product;
//            HealthyFoodDbContext dbContext = new HealthyFoodDbContext();

//            //name uniqe per department
//            Product productFromDb = dbContext.Product
//                .FirstOrDefault(e=>e.Name == name && e.Category== productFromRequest.Category);
           
//            if(productFromDb == null ) { //new name ,edit insert new name 
//                return ValidationResult.Success;
//            }
//            return new ValidationResult("Name already Found in this category");
     
//        }
//    }
//}
