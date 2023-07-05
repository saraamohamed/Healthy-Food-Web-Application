using HealthyFoodWebApplication.Repositories.LoggerRepository;
using HealthyFoodWebApplication.Repositories.ShoppingBag;
using HealthyFoodWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly IShoppingBagRepository BagRepository;
        private readonly ILoggerRepository LoggerRepository;

        public OrderController(IShoppingBagRepository BagRepo, ILoggerRepository loggerRepo)
        {
            BagRepository = BagRepo;
            LoggerRepository = loggerRepo;
        }

        //public IActionResult GetOrderView()
        //{
        //    return View("Order");
        //}
        public IActionResult GetOrderView()
        {
            var Bags = BagRepository.GetAll().ToList();
            var custOrdersVMList = new List<CustomerOrdersVM>();
            //var username = User.Identity.Name;
            foreach (var order in Bags)
            {
                var customerOrdersVM = new CustomerOrdersVM
                {
                    ProductName = order.ProductName,
                    ProductPrice = order.ProductPrice,
                    ProductQuantity = order.ProductQuantity,
                    TotalPrice = (order.ProductPrice * (order.ProductQuantity)).ToString(),
                    FullName = order.Username,
                   //PhoneNumber = order.Logger.PhoneNumber,
                };
                custOrdersVMList.Add(customerOrdersVM);
            }



            return View("Order", custOrdersVMList);
        }
    }
}
