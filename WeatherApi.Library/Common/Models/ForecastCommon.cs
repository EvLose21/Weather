namespace WeatherApi.Library.Common.Models
{
    public class ForecastCommon
    {
        public string? city { get; set; }
        public List<ForecastdayCommon>? day { get; set; }

    }
}
