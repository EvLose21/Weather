﻿namespace Api.WeatherStack.Models
{
    public class AstroElement
    {
        public string? sunrise { get; set; }
        public string? sunset { get; set; }
        public string? moonrise { get; set; }
        public string? moonset { get; set; }
        public string? moon_phase { get; set; }
        public decimal moon_illumination { get; set; }
    }

}
