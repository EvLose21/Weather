namespace WeatherApi.com.Models
{
    public class Current
    {
        public string? Last_updated { get; set; }
        public decimal Temp_c { get; set; }
        public decimal Feelslike_c { get; set; }
        public Condition? Condition { get; set; }
        public decimal Wind_kph { get; set; }
        public decimal Pressure_mb { get; set; }
        public decimal Precip_mm { get; set; }
        public int Humidity { get; set; }
        public int Cloud { get; set; }
        public int Is_day { get; set; }
        public decimal Uv { get; set; }
        public decimal Gust_kph { get; set; }
    }
}
