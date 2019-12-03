using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherFinder.DB;
using WeatherFinder.Models;

namespace WeatherFinder.Services
{
    public class WeatherServiceManager
    {
        private readonly WeatherFinderDbContext _ctx;

        public WeatherServiceManager()
        {
            _ctx = new WeatherFinderDbContext();
         }
        public void LogForecast(WeatherForecast weatherForecast)
        {
            //TODO: Log forecast into database
        }
        public async Task<IEnumerable<WeatherForecast>> GetAllForecastsAsync()
        {
            List<WeatherForecast> result = null;

            result = await _ctx.Forecasts.ToListAsync();

            return result;
        }
    }
}
