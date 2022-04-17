using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ow_eote___back_end.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ow_eote___back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanetController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        private readonly IPlanetServices _planetService;

        public PlanetController(IPlanetServices planetService)
        {
            _planetService = planetService;
        }

        [HttpGet("{pos}")]
        public Planet GetPlanets([FromRoute] int pos)
        {
            return _planetService.GetPlanet(pos);
        }

        [HttpGet]
        public Planet GetRandomPlanets()
        {
            return _planetService.GetRandomPlanet();
        }

        [HttpPost]
        public ActionResult AddPlanet([FromBody] Planet planet) 
        {
            _planetService.AddPlanet(planet);
            return Ok();
        }

        [HttpPut("{idPlanet:guid}")]
        public ActionResult UpdatePlanet([FromRoute] Guid idPlanet, [FromBody] Planet planet)
        {
            _planetService.UpdatePlanet(idPlanet, planet);
            return Ok();
        }

        [HttpDelete("{idPlanet:guid}")]
        public ActionResult DeletePlanet([FromRoute] Guid idPlanet)
        {
            _planetService.DeletePlanet(idPlanet);
            return Ok();
        }
    }
}
