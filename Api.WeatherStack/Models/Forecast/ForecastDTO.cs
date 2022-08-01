namespace Api.WeatherStack.Models.Forecast
{
    public class ForecastDTO
    {
        public Location? location { get; set; }
        public Current? current { get; set; }
        public Forecast? forecast { get; set; }
    }
}
