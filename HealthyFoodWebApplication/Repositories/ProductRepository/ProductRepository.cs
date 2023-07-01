using HealthyFoodWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthyFoodWebApplication.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        HealthyFoodDbContext dbContext;
        public ProductRepository(HealthyFoodDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Delete(int id)
        {
            Product OldProduct = GetById(id);
            OldProduct.IsDeleted = true;   

        }

        public List<Product>? GetAll()
        {
            return dbContext.Product.Where(c => c.IsDeleted != true).ToList();
        }

        public Product? GetById(int id)
        {
            return dbContext.Product.FirstOrDefault(c => c.Id == id);
        }

        public void Insert(Product NewProduct)
        {
            dbContext.Product.Add(NewProduct);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Update(int id,Product UpdatedProduct)
        {
            Product OldProduct = GetById(id);

            dbContext.Update(UpdatedProduct);
        }
        public List<Product> GetByCategory(ProductType category)
        {
            return dbContext.Product.Where(p => p.Category == category &&  p.IsDeleted != true).ToList();
        }

 
    }
}
