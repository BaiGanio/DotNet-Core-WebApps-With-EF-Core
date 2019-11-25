using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherFinder.Models
{
    public sealed class WeatherForecast
    {
        public WeatherForecast() { }

        [Key]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Summary { get; set; }
        public double TemperatureC { get; set; }
        public int Humidity { get; set; }
        public double Pressure { get; set; }
        public int Wind { get; set; }
        public string City { get; set; }
    }
}
