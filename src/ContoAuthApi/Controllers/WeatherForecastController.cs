using ContoAuthApi.Accounts.Entities;
using ContoAuthApi.Accounts.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContoAuthApi.Controllers;

[Route("weatherforecast")]
public class WeatherForecastController : Controller
{
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<WeatherForecast>> GetWeatherForecast()
    {
        var forecast = _weatherForecastService.GetWeatherForecasts();

        return Ok(new
        {
            results = forecast
        });
    }
}
