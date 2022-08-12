﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.com.Interface;
using WeatherApi.com.Models;
using WeatherApi.com.Models.CurrentWeather;
using WeatherApi.com.Models.Forecast;
using WeatherApi.Library.Common.Models;

namespace WeatherApi.com.Controllers
{
    [Route("api/weatherapi")]
    [ApiController]
    public class WeatherApiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHttpCallService _httpCallService;
        private readonly IForecastHelper _forecastHelper;
        public WeatherApiController(IHttpCallService httpCallService, IMapper mapper, IForecastHelper forecastHelper)
        {
            _httpCallService = httpCallService;
            _mapper = mapper;
            _forecastHelper = forecastHelper;
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
                var mapRespomse = _mapper.Map<CurrentWeatherCommon>(response);
               
                return (mapRespomse is null) ? NotFound(mapRespomse) : Ok(mapRespomse);
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
                _forecastHelper.FixTime(response);
                return (response is null) ? NotFound(response) : Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
 