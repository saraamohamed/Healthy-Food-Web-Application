using HealthyFoodWebApplication.Models;
using HealthyFoodWebApplication.Repositories;
using HealthyFoodWebApplication.Repositories.ProductRepository;
using HealthyFoodWebApplication.Repositories.ShoppingBag;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace HealthyFoodWebApplication.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository productRepository;
        IShoppingBagRepository _shoppingBag;
        public ProductController(IProductRepository productRepo, IShoppingBagRepository shoppingBag)
        {
            productRepository = productRepo;
            _shoppingBag = shoppingBag;

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


        public IActionResult AddToCart(int productId)
        {
            var product = productRepository.GetById(productId);
            if (ModelState.IsValid)
            {
                var username = User.Identity.Name;
                var ProductItem = new ShoppingBagItem
                {
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    ProductQuantity = product.Quantity,
                    ProductTotalPrice = product.Price.ToString(),
                    Username=username,
                };
                _shoppingBag.Add(ProductItem);
                _shoppingBag.Save();
            }
            return RedirectToAction("GetProductView");
        }
        public IActionResult EditProduct(int productId)
        {
            var product = productRepository.GetById(productId);
           
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(int productId, Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                  
                    var Pro = productRepository.GetById(productId);
                    Pro.Name = product.Name;
                    Pro.Price = product.Price;
                    Pro.Quantity=product.Quantity;
                    Pro.PriceBeforeSale = product.PriceBeforeSale;
                    Pro.Category = product.Category;
                    Pro.Image=product.Image;
                    productRepository.Save();
                    return RedirectToAction("GetProductView");
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError("", errorMessage: exception.InnerException.Message);
                }
            }

            return View( product);
        }
        public IActionResult Delete(int productId)
        {
            productRepository.Delete(productId);

           return RedirectToAction("GetProductView");
        }

    }
}
