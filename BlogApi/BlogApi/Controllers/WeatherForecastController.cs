using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();

            for (int i = 0; i < 5; i++)
            {
                var newModel = new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                };
                weatherForecasts.Add(newModel);
            }



            return weatherForecasts;
        }

        [HttpGet("list/{number}")]
        public IEnumerable<WeatherForecast> List(int number)
        {
            var rng = new Random();

            List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();

            for (int i = 0; i < number; i++)
            {
                var newModel = new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                };
                weatherForecasts.Add(newModel);
            }

            return weatherForecasts;
        }
    }
}
