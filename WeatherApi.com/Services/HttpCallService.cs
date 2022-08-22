using Microsoft.Net.Http.Headers;
using System.Diagnostics;
using System.Text.Json;
using WeatherApi.com.Interface;
using WeatherApi.com.Models;
using WeatherApi.com.Models.CurrentWeather;
using WeatherApi.com.Models.Forecast;
using System.Text.Json.Serialization;

namespace WeatherApi.com.Services
{
    public class HttpCallService : IHttpCallService, IForecastHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        public HttpCallService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public CurrentWeatherDTO? Current { get; set; }
        public ForecastDTO? Forecast { get; set; }

        public async Task<CurrentWeatherDTO> GetCurrentWeather()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://api.weatherapi.com/v1/current.json?key=7e3d5c232f4844219e272126222207&q=Minsk&aqi=no")
            {
                Headers =
                {
                    {HeaderNames.Accept, "application/json"},
                    {HeaderNames.UserAgent, "HttpRequestSample" }
                }
            };

            var httpClient = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                using var current = await response.Content.ReadAsStreamAsync();

                Current = await JsonSerializer.DeserializeAsync<CurrentWeatherDTO>(current, _options);

            }

            else
            {
                Debug.WriteLine("failure");
            }

            return Current;
        }

        public async Task<ForecastDTO> GetForecast()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://api.weatherapi.com/v1/forecast.json?key=7e3d5c232f4844219e272126222207&q=Minsk&days=1&aqi=no&alerts=no")
            {
                Headers =
                {
                    {HeaderNames.Accept, "application/json"},
                    {HeaderNames.UserAgent, "HttpRequestSample" }
                }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                using var forecast = await response.Content.ReadAsStreamAsync();

                Forecast = await JsonSerializer.DeserializeAsync<ForecastDTO>(forecast, _options);
            }

            else
            {
                Debug.WriteLine("failure");
            }

            return Forecast;
        }

        public void FixTime(ForecastDTO model)
        {
            for (int j = 0; j < model.Forecast.Forecastday.Count; j++)
            {
                var temp = new List<HourElement>();
                var hour = model.Forecast.Forecastday[j].Hour;
                for (int i = 0; i < hour.Count / 3; i++)
                {
                    temp.Add(hour[i * 3]);
                }
                model.Forecast.Forecastday[j].Hour = temp;
            }
        }
    }
}
