namespace WeatherApi.Library.Common.Models
{
    public class ForecastCommon
    {
        public string? City { get; set; }
        public List<ForecastdayCommon>? Day { get; set; }

    }
}
