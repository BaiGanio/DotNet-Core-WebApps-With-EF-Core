using Microsoft.EntityFrameworkCore;
using WeatherFinder.Models;

namespace WeatherFinder.DB
{
    public class WeatherFinderDbContext : DbContext
    {
        public DbSet<WeatherForecast> Forecasts { get; set; }
        public DbSet<CustomException> Exceptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=WeatherFinder-LocalDB;Integrated Security=True"
                //@"Server=localhost;Database=WeatherFinder-LocalDB;User ID=sa;Password=fmi"
            );
        }
    }
}
