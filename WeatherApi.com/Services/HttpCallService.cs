using IdentityModel.Client;
using Microsoft.Net.Http.Headers;
using System.Diagnostics;
using WeatherApi.com.Interface;
using WeatherApi.com.Models;
using WeatherApi.com.Models.Forecast;

namespace WeatherApi.com.Services
{
    public class HttpCallService : IHttpCallService, IForecastHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpCallService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
     
        public async Task<T> GetCurrentWeather<T>()
        {
            var authClient = _httpClientFactory.CreateClient();
            var discoveryDocument = await authClient.GetDiscoveryDocumentAsync("https://localhost:10001");      // why 10001?
            var tokenResponse = await authClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = "client_id",
                ClientSecret = "client_secret",

                Scope = "WeatherApi"
            });

            T data = default(T);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://api.weatherapi.com/v1/current.json?key=7e3d5c232f4844219e272126222207&q=Minsk&aqi=no")
            {
                Headers =
                {
                    {HeaderNames.Accept, "application/json"},
                    {HeaderNames.UserAgent, "HttpRequestSample" }
                }
            };

            var httpClient = _httpClientFactory.CreateClient();

            httpClient.SetBearerToken(tokenResponse.AccessToken);

            HttpResponseMessage response = await httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadFromJsonAsync<T>().ConfigureAwait(false);
            }

            else
            {
                Debug.WriteLine("failure");
            }

            return data;
        }

        public async Task<T> GetForecast<T>()
        {
            T data = default(T);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://api.weatherapi.com/v1/forecast.json?key=7e3d5c232f4844219e272126222207&q=Minsk&days=1&aqi=no&alerts=no")
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
                data = await response.Content.ReadFromJsonAsync<T>().ConfigureAwait(false);
            }

            else
            {
                Debug.WriteLine("failure");
            }

            return data;
        }

        public void FixTime(ForecastDTO model)
        {
            var hour = model.forecast.forecastday[0].hour; // always one forecast element??
            var temp = new List<HourElement>();
            for (int i = 0; i < hour.Count / 3; i++)
            {
                temp.Add(hour[i * 3]);
            }
            model.forecast.forecastday[0].hour = temp;
        }
    }
}
