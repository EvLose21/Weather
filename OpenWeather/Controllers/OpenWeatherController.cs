using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OpenWeather.Domain.Interfaces;
using OpenWeather.Domain.Models.CurrentWeather;
using OpenWeather.Domain.Models.Forecast;
using WeatherApi.Library.Common.Models;

namespace OpenWeather.Controllers
{
    [Route("api/openweather")]
    [ApiController]
    public class OpenWeatherController : ControllerBase
    {
        private readonly IOpenWeatherService _httpCallService;
        private readonly IMapper _mapper;
        public OpenWeatherController(IOpenWeatherService httpCallService, IMapper mapper)
        {
            _httpCallService = httpCallService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("current")]
        public async Task<IActionResult> GetCurrentWeather()
        {
            try
            {
                var response = await _httpCallService.GetCurrentWeather<CurrentWeatherDTO>();
                var mapRespomse = _mapper.Map<CurrentWeatherCommon>(response);
                return (mapRespomse is null) ? NotFound(mapRespomse) : Ok(mapRespomse);
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
