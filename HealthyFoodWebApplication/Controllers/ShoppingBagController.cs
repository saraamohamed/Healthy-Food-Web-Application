using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWebApplication.Controllers
{
    public class ShoppingBagController : Controller
    {
        public IActionResult GetShoppingBagView()
        {
            return View("ShoppingBag");
        }
    }
}
