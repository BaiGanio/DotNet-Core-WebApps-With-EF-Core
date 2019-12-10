using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherFinder.DB;
using WeatherFinder.Models;
using WeatherFinder.Services;

namespace WeatherFinder.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherServiceManager _weatherManager;
        private readonly LogServiceManager _logManager;
        public HomeController()
        {
            _weatherManager = new WeatherServiceManager();
            _logManager = new LogServiceManager();
        }

        public async Task<IActionResult> Index(string searchString)
        {
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    var result = await _weatherManager.GetAllForecastsAsync();

                    var forecast = 
                        result
                        .Where(s => s.City.ToLower() == searchString.ToLower())
                        .FirstOrDefault();

                    if (forecast == null/* || forecast.Date > forecast.Date.AddMinutes(-11)*/)
                    {
                        forecast =
                            await _weatherManager.GetIndustryForecast(searchString);
                    }

                    return View(forecast);
                }
                return View();
            }
            catch (Exception ex)
            {
                CustomException ce = new CustomException(ex);
                await _logManager.LogCustomException(ce);
                return View("Error");
            }
        }

        public async Task<IActionResult> Privacy()
        {
            try
            {
                throw new Exception("Wow!?!?! We are logging exceptions from method called Privacy()!!!");
            }
            catch (Exception ex)
            {
                CustomException ce = new CustomException(ex);
                await _logManager.LogCustomException(ce);

                return View("Error");
            }
        }

        public IActionResult Error()
        {
            return View(/*new ErrorViewModel { RequestId = "_!_!" ?? HttpContext.TraceIdentifier }*/);
        }

        public async Task<IActionResult> Exceptions()
        {
            var exceptions  = 
                await _logManager.GetAllCustomExceptions();
            return View(exceptions);
        }

        public async Task<IActionResult> MyWeather(string searchString)
        {
            try
            {
                var result = await _weatherManager.GetAllForecastsAsync();
                if (!String.IsNullOrEmpty(searchString))
                {
                    result = result.Where(s => s.City.Contains(searchString));
                }
                return View(result);
            }
            catch (Exception ex)
            {
                CustomException ce = new CustomException(ex);
                await _logManager.LogCustomException(ce);
                return View("Error");
            }
        }

    }
}
