using HealthyFoodWebApplication.Models;

namespace HealthyFoodWebApplication.Repositories.ProductRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Insert(Product product);
        void Update(int id, Product product);
        void Delete(int id);
        void Save();
        List<Product> GetByCategory(ProductType category);
    }
}
