namespace WeatherApi.com.Models
{
    public class Location
    {
        public string? Name { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string? Tz_id { get; set; }
        public string? Localtime { get; set; }
        public int Localtime_epoch { get; set; }
    }
}
