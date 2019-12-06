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
        public HomeController()
        {
            _weatherManager = new WeatherServiceManager();
        }

        public IActionResult Index()
        {
            return View();
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
                var ctx = new WeatherFinderDbContext();
                await ctx.Exceptions.AddAsync(ce);
                await ctx.SaveChangesAsync();

                return View("Error");
            }
            //return View();
        }

        public IActionResult Error()
        {
            return View(/*new ErrorViewModel { RequestId = "_!_!" ?? HttpContext.TraceIdentifier }*/);
        }

        public async Task<IActionResult> Exceptions()
        {
            var ctx = new WeatherFinderDbContext();

            List<CustomException> exceptions =
                await ctx.Exceptions
                .OrderByDescending(ex => ex.DateCreated)
                .ToListAsync();

            return View(exceptions);
        }

        public async Task<IActionResult> MyWeather(string searchString1)
        {
            try
            {
                // throw new NotImplementedException("Should implement some logic in the near future!!! Right?!?!?");
                var result = await _weatherManager.GetAllForecastsAsync();
                if (!String.IsNullOrEmpty(searchString1))
                {
                    result = result.Where(s => s.City.Contains(searchString1));
                }
                return View(result);
            }
            catch (Exception ex)
            {
                CustomException ce = new CustomException(ex);
                var ctx = new WeatherFinderDbContext();
                await ctx.Exceptions.AddAsync(ce);
                await ctx.SaveChangesAsync();

                return View("Error");
            }

            //return View();
        }

    }
}
