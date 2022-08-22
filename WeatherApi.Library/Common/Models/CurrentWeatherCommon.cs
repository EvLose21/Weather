namespace WeatherApi.Library.Common.Models
{
    public class CurrentWeatherCommon
    {
        public string? City { get; set; }
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        public double Wind { get; set; }
        public int Time { get; set; }
    }
}
