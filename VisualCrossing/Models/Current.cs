namespace VisualCrossing.Models
{
    public class Current
    {
        public string? last_updated { get; set; }
        public decimal temp_c { get; set; }
        public decimal feelslike_c { get; set; }
        public Condition? condition { get; set; }
        public decimal wind_kph { get; set; }
        public decimal pressure_mb { get; set; }
        public decimal precip_mm { get; set; }
        public int humidity { get; set; }
        public int cloud { get; set; }
        public int is_day { get; set; }
        public decimal uv { get; set; }
        public decimal gust_kph { get; set; }
    }
}
