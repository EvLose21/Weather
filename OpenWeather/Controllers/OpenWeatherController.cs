using Microsoft.AspNetCore.Mvc;
using OpenWeather.Domain.Interfaces;
using OpenWeather.Domain.Models.CurrentWeather;
using OpenWeather.Domain.Models.Forecast;

namespace OpenWeather.Controllers
{
    [Route("api/openweather")]
    [ApiController]
    public class OpenWeatherController : ControllerBase
    {
        private readonly IOpenWeatherService _httpCallService;
        public OpenWeatherController(IOpenWeatherService httpCallService)
        {
            _httpCallService = httpCallService;
        }

        [HttpGet]
        [Route("current")]
        public async Task<IActionResult> GetCurrentWeather()
        {
            try
            {
                var response = await _httpCallService.GetCurrentWeather<CurrentWeatherDTO>();
                return (response is null) ? NotFound(response) : Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("forecast")]
        public async Task<IActionResult> GetForecast()
        {
            try
            {
                var response = await _httpCallService.GetForecast<ForecastDTO>();
                return (response is null) ? NotFound(response) : Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
