namespace WeatherApi.Library.Common.Models
{
    public class CurrentWeather
    {
        public string? city { get; set; }
        public double temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public double wind { get; set; }
        public int time { get; set; }
           
    }
}
