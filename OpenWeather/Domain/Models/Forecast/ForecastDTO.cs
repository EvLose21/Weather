namespace OpenWeather.Domain.Models.Forecast
{
    public class ForecastDTO
    {
        public string cod { get; set; }
        public decimal message { get; set; }
        public int cnt { get; set; }
        public List<ForecastDay>? list { get; set; }
        public City city { get; set; }
    }
}