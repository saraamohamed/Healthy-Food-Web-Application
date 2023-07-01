using HealthyFoodWebApplication.Models;
using HealthyFoodWebApplication.Repositories.ProductRepository;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace HealthyFoodWebApplication.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository productRepository;
        public ProductController(IProductRepository productRepo)
        {
            productRepository = productRepo;
        }
        public IActionResult GetProductView()
        {
            List<Product> AllProductsModel = productRepository.GetAll();

            return View("Product",AllProductsModel);
        }
        public IActionResult GetCategoryProducts(ProductType category)
        {
            List<Product> products = productRepository.GetByCategory(category);
            return View("Product", products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product newProduct)
        {
            if (ModelState.IsValid == true)//check server side
            {
                try
                {
                    productRepository.Insert(newProduct);
                    productRepository.Save();
                    return RedirectToAction("GetProductView");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.InnerException.Message);//div only

                }
            }

            return View("AddProduct", newProduct);

        }


    }
}
