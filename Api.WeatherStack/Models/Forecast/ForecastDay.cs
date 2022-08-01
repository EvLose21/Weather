namespace Api.WeatherStack.Models.Forecast
{
    public class ForecastDay
    {
        public string? date { get; set; }
        public DayElement? day { get; set; }
        public AstroElement? astro { get; set; }
        public List<HourElement>? hour { get; set; }
    }
}
