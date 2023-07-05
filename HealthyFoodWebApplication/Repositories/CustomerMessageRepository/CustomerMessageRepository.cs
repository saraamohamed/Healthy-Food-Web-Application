using HealthyFoodWebApplication.Models;

namespace HealthyFoodWebApplication.Repositories.CustomerMessageRepository
{
    public class CustomerMessageRepository : ICustomerMessageRepository
    {
        private readonly HealthyFoodDbContext Context;
        public CustomerMessageRepository(HealthyFoodDbContext _context)
        {
            Context = _context;
        }
  

        public List<CustomerMessage>? GetAll()
        {
            return Context.CustomerMessage.ToList();
        }
        public void save()
        {
            Context.SaveChanges();
        }

        public CustomerMessage? GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Insert(CustomerMessage message)
        {
            Context.CustomerMessage.Add(message);
            Context.SaveChanges();
        }

      

        public void Update(int id, CustomerMessage entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
