﻿namespace OpenWeather.Domain.Models.CurrentWeather
{
    public class CurrentWeatherDTO
    {
        public Location? location { get; set; }
        public Current? current { get; set; }
    }
}