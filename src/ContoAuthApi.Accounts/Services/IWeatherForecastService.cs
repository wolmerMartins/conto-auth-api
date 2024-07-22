using ContoAuthApi.Accounts.Entities;

namespace ContoAuthApi.Accounts.Services;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> GetWeatherForecasts();
}
