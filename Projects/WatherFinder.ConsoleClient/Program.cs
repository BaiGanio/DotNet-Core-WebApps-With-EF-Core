using System;
using System.Collections.Generic;
using Utils;
using WeatherFinder.DB;
using WeatherFinder.Models;

namespace WatherFinder.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var forecasts = GenerateDummyWeatherForecastData();
            PrintDummyWeatherForecastData(forecasts);

            //TODO: Log exceptions in database if any!!
            //InsertDummyWeatherForecastDataInDatabase(forecasts);
        }

        private static List<WeatherForecast> GenerateDummyWeatherForecastData()
        {
            var weeklyForecast = new List<WeatherForecast>();
            var rng = new Random();
            string[] Summaries =
                new[]
                {
                    "Freezing",
                    "Bracing",
                    "Chilly",
                    "Cool",
                    "Mild",
                    "Warm",
                    "Balmy",
                    "Hot",
                    "Sweltering",
                    "Scorching"
                };

            string[] Cities =
              new[]
              {
                    "Aksokovo",
                    "Plovdiv",
                    "Buenos Aires",
                    "Tokyo",
                    "WTF",
                    "Mars"
              };

            for (int i = 0; i < 17; i++)
            {
                var forecast = new WeatherForecast
                {
                    Id = rng.Next(0, 125).ToString(),
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = rng.Next(-20, 55),
                    Humidity = rng.Next(0, 100),
                    Pressure = MyExtensions.NextDouble(rng, 100, 1000),
                    Wind = rng.Next(0, 100),
                    Summary = Summaries[rng.Next(Summaries.Length)],
                    City = Cities[rng.Next(Cities.Length)]
                };
                weeklyForecast.Add(forecast);
            };
            return weeklyForecast;
        }

        private static void PrintDummyWeatherForecastData(List<WeatherForecast> forecasts)
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"WEATHER-FINDER",50}");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"ID",-10}| {"Date",-9}| {"Temperature", -12}| {"Humidity",-8}| {"Pressure",-10}| {"Wind",-8}| {"Summary",-12}| {"City",-12}|\n");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            for (int i = 0; i < forecasts.Count; i++)
            {
                Console.WriteLine(
                    $"{forecasts[i].Id,-10}|" +
                    $"{forecasts[i].Date.ToShortDateString(),-10}| " +
                    $"{forecasts[i].TemperatureC + " °C", -12:N2}| " +
                    $"{forecasts[i].Humidity + " %",-8}| " +
                    $"{forecasts[i].Pressure,-7:N2} mb| " +
                    $"{forecasts[i].Wind + " km/h",-8}| " +
                    $"{forecasts[i].Summary,-12}| " +
                    $"{forecasts[i].City,-12}| "
                );
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------");
        }

        private static void InsertDummyWeatherForecastDataInDatabase(List<WeatherForecast> forecasts)
        {
            var dbContext = new WeatherFinderDbContext();

            dbContext.Database.EnsureCreated();

            //dbContext.Database.Migrtate();

            for (int i = 0; i < forecasts.Count; i++)
            {
                dbContext.Forecasts.Add(forecasts[i]);
            }

            //foreach (var forecast in forecasts)
            //{
            //    dbContext.Add(forecast);
            //}

            dbContext.SaveChanges();
        }
    }
}
