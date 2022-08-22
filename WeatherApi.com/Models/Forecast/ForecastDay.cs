namespace WeatherApi.com.Models.Forecast
{
    public class ForecastDay
    {
        public string? Date { get; set; }
        public DayElement? Day { get; set; }
        public AstroElement? Astro { get; set; }
        public List<HourElement>? Hour { get; set; }
    }
}
