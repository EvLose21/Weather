using WeatherApi.com.Models.CurrentWeather;
using WeatherApi.com.Models.Forecast;

namespace WeatherApi.com.Interface
{
    public interface IHttpCallService
    {
        Task<CurrentWeatherDTO> GetCurrentWeather();
        Task<ForecastDTO> GetForecast();
    }
}
