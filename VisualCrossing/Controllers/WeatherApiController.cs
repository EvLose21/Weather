using Microsoft.AspNetCore.Mvc;
using VisualCrossing.Interface;
using VisualCrossing.Models.CurrentWeather;
using VisualCrossing.Models.Forecast;

namespace VisualCrossing.Controllers
{
    [Route("api/weatherapi")]
    [ApiController]
    public class WeatherApiController : ControllerBase
    {
        private readonly IHttpCallService _httpCallService;
        public WeatherApiController(IHttpCallService httpCallService)
        {
            _httpCallService = httpCallService;
        }

        /// <summary>
        /// Returns current weather from weatherapi.com
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Returns forecast from weatherapi.com
        /// </summary>
        /// <returns></returns>
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
