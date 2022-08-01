namespace Api.WeatherStack.Models
{
    public class DayElement
    {
        public decimal maxtemp_c { get; set; }
        public decimal mintemp_c { get; set;}
        public decimal avgtemp_c { get; set; }
        public decimal maxwind_kph { get; set; }
        public decimal totalprecip_mm { get; set; }
        public decimal avgvis_km { get; set; }
        public decimal avghumidity { get; set; }
        public Condition? condition { get; set; }
        public decimal uv { get; set; }
    }
}
