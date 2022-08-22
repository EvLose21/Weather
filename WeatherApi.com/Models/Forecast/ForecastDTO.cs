namespace WeatherApi.com.Models.Forecast
{
    public class ForecastDTO
    {
        public Location? Location { get; set; }
        public Current? Current { get; set; }
        public Forecast? Forecast { get; set; }
    }
}
