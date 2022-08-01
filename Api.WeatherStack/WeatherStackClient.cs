using System.Text.Json;

namespace Api.WeatherStack
{
    public class WeatherStackClient
    {
        public class WeatherClient
        {
            private readonly HttpClient _client;
            private readonly JsonSerializerOptions _options;

            public WeatherClient(HttpClient client)
            {
                _client = client;

                _client.BaseAddress = new Uri("В ПОИСКЕ");
                _client.Timeout = new TimeSpan(0, 0, 30);
                _client.DefaultRequestHeaders.Clear();

                _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            }
        }
    }
}
