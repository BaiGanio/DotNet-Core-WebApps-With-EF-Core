using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherFinder.DB;
using WeatherFinder.Models;

namespace WeatherFinder.Services
{
    public class LogServiceManager
    {
        private readonly WeatherFinderDbContext _ctx;

        public LogServiceManager()
        {
            _ctx = new WeatherFinderDbContext();
        }

        public async Task LogCustomException(CustomException ce)
        {
            await _ctx.Exceptions.AddAsync(ce);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomException>> GetAllCustomExceptions()
        {
            List<CustomException> result = 
                await _ctx.Exceptions
                    .OrderByDescending(ce => ce.DateCreated)
                    .ToListAsync();

            return result;
        }
    }
}
