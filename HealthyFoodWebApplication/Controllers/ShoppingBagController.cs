using HealthyFoodWebApplication.Models;
using HealthyFoodWebApplication.Repositories.ProductRepository;
using HealthyFoodWebApplication.Repositories.ShoppingBag;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWebApplication.Controllers
{
    public class ShoppingBagController : Controller
    {
        private readonly IShoppingBagRepository _bagRepository;
        private readonly IProductRepository _repository;

        public ShoppingBagController(IShoppingBagRepository bagRepository, IProductRepository repository)
        {
            _bagRepository = bagRepository;
            _repository = repository;
        }
        public IActionResult GetShoppingBagView()
        {
            var username = User.Identity.Name;
            List<ShoppingBagItem> items = new List<ShoppingBagItem>();
            if (ModelState.IsValid )
            {
                List<ShoppingBagItem> Allitems = _bagRepository.GetAll();
                foreach(var item in Allitems)
                {
                    if (item.Username == username)
                    {
                        items.Add(item);
                    }
                }
                return View("ShoppingBag", items);
            }
            return View("ShoppingBag");
        }
        public IActionResult DeleteProduct(int id)
        {
            _bagRepository.Delete(id);
            _bagRepository.Save();
            return RedirectToAction("GetShoppingBagView");
        }


    }
}
