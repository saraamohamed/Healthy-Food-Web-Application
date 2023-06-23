using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWebApplication.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetProductView()
        {
            return View("Product");
        }

        public IActionResult AddProduct()
        {
            return View();
        }
    }
}
