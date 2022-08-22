namespace WeatherApi.com.Models
{
    public class DayElement
    {
        public decimal Maxtemp_c { get; set; }
        public decimal Mintemp_c { get; set;}
        public decimal Avgtemp_c { get; set; }
        public decimal Maxwind_kph { get; set; }
        public decimal Totalprecip_mm { get; set; }
        public decimal Avgvis_km { get; set; }
        public decimal Avghumidity { get; set; }
        public Condition? Condition { get; set; }
        public decimal Uv { get; set; }
    }
}
