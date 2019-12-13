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
                //@"Server=.;Database=WeatherFinder-LocalDB;Integrated Security=True"
                //@"Server=localhost;Database=WeatherFinder-LocalDB;User ID=sa;Password=fmi"
                @"Server=ee7524f9-6f33-4d41-848f-ab2101546358.sqlserver.sequelizer.com;Database=dbee7524f96f334d41848fab2101546358;User ID=wdbaoddfqiimwfos;Password=ZhLy68iTXsaYiTwRUpcmodyCzYcDso4WSXezXY638tjogrc27KPNjvDVRh7g5LzJ;"
            );
        }
    }
}
