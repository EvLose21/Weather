namespace WeatherApi.com.Models
{
    public class HourElement
    {
        public string? Time { get; set; }
        public int Time_epoch { get; set; }
        public decimal Temp_c { get; set; }
        public Condition? Condition { get; set; }
        public decimal Wind_kph { get; set; }
        public decimal Pressure_mb { get; set; }
        public decimal Precip_mm { get; set; }
        public int Humidity { get; set; }
        public int Cloud { get; set; }
        public decimal Feelslike_c { get; set; }
        public decimal Windchill_c { get; set; }
        public decimal Heatindex_c { get; set; }
        public decimal Dewpoint_f { get; set; }
        public int Will_it_rain { get; set; }
        public int Will_it_snow { get; set; }
        public int Is_day { get; set; }
        public decimal Vis_km { get; set; }
        public int Chance_of_rain { get; set; }
        public int Chance_of_snow { get; set; }
        public decimal Gust_kph { get; set; }
    }
}
