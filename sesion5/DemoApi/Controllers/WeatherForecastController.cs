using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers;

[ApiController]
[Route("/forecasts")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly List<WeatherForecast> _forecasts;
    private readonly GuidService _svc;
    private readonly FooService _foo;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, GuidService svc, FooService foo)
    {
        _logger = logger;
        _svc = svc;
        _foo = foo;
        _forecasts = new List<WeatherForecast>();
        _forecasts.AddRange(LoadForecasts());
        _logger.LogInformation("Creado controllador de tipo {tipo}", this.GetType().Name);
    }

    [HttpGet("guid")]
    public IActionResult GetGuid() => Ok(new { GuidSvc=_svc.Id, FooSvc=_foo.Id });

    

    private IEnumerable<WeatherForecast> LoadForecasts()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(404)]
    public ActionResult<WeatherForecast> GetById(int id, int add) 
    {
        var newId = id + add;
        if (newId > _forecasts.Count - 1) {
            return NotFound();
        }
        else {
            return _forecasts[newId];
        }
    }

    [HttpGet()]
    public IEnumerable<WeatherForecast> Get()
    {
        return _forecasts;
    }
}
