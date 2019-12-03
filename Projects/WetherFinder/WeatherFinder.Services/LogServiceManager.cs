using System.Collections.Generic;
using WeatherFinder.Models;

namespace WeatherFinder.Services
{
    public class LogServiceManager
    {
        public void LogCustomException(CustomException ce)
        {
            //TODO: Log exception into database
        }

        public IEnumerable<CustomException> GetAllCustomExceptions()
        {
            List<CustomException> result = null;

            //TODO: Get exceptions from database

            return result;
        }
    }
}
