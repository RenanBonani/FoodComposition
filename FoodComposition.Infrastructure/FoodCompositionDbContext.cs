using FoodComposition.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FoodComposition.Infrastructure
{
    public class FoodCompositionDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DbSet<Composition> FoodCompositions { get; set; }

        public FoodCompositionDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
        }

    }
}