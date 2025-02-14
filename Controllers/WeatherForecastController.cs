using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApplication1.Model;

namespace WebApplication1.Controllers
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
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _config;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMapper mapper, IConfigurationProvider config)
        {
            _logger = logger;
            _mapper = mapper;
            _config = config;
        }


        [HttpGet("MapUser")]
        public IEnumerable<UserViewModel> MapUser()
        {
            var user = new User()
            {
                Id = 1,
                FirstName = "Nuttinee",
                LastName = "Kosa",
                Email = "nuttinee@gmail.com",
                Address = "Condo"
            };

            var map = this._mapper.Map<User>(user);

            var mapModel = _mapper.Map<User, UserViewModel>(user);

            yield return mapModel;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
