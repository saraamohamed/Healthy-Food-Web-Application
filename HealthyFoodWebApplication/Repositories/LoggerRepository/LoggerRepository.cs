using HealthyFoodWebApplication.Models;

namespace HealthyFoodWebApplication.Repositories.LoggerRepository
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly HealthyFoodDbContext Context;
        public LoggerRepository(HealthyFoodDbContext _context)
        {
            Context = _context;
        }
  

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Logger>? GetAll()
        {
            return Context.Logger.ToList();
        }

        public Logger? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Logger entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Logger entity)
        {
            throw new NotImplementedException();
        }
    }
}
