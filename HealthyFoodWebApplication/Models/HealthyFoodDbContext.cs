using Microsoft.EntityFrameworkCore;
namespace HealthyFoodWebApplication.Models
{
    public class HealthyFoodDbContext : DbContext
    {
   
        //public HealthyFoodDbContext() : base()
        //{
        //}

        public HealthyFoodDbContext() { }


        public HealthyFoodDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CustomerMessage> CustomerMessage { get; set; }
        public DbSet<Logger> Logger { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ShoppingBagItem> ShoppingBag { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=HealthyFoodDb;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
