using ECertifyAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ECertifyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ECertifyContext _context;
        // to check if the db connection is set correctly
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ECertifyContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();

            var model = _context.Users.ToList();
            return Ok(model);
        }
    }
}
