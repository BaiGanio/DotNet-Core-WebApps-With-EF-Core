using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task LogForecast(WeatherForecast weatherForecast)
        {
            await _ctx.Forecasts.AddAsync(weatherForecast);
        }
        public async Task<IEnumerable<WeatherForecast>> GetAllForecastsAsync()
        {
            List<WeatherForecast> result = 
                await _ctx.Forecasts.ToListAsync();

            return result;
        }

        public async Task<WeatherForecast> GetIndustryForecast(string searchString)
        {
            try
            {
                //TODO: ask industry provider for the forecast & log it into datbase

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
