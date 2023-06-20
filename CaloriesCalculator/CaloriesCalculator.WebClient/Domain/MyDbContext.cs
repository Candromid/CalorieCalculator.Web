using CaloriesCalculator.WebClient.Domain.Entities;
using CaloriesCalculator.WebClient.Service;
using Microsoft.EntityFrameworkCore;

namespace CaloriesCalculator.WebClient.Domain
{
    public class MyDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }
    }
}
