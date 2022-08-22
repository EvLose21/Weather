using AutoMapper;
using OpenWeather.Domain.Models.CurrentWeather;
using OpenWeather.Domain.Models.Forecast;
using WeatherApi.Library.Common.Models;

namespace OpenWeather.MappingConfigurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CurrentWeatherDTO, CurrentWeatherCommon>()
                .ForMember(dest =>
                    dest.City,
                    opt => opt.MapFrom(src => src.name))
                .ForMember(dest =>
                    dest.Time,
                    opt => opt.MapFrom(src => src.dt))
                .ForMember(dest =>
                    dest.Pressure,
                    opt => opt.MapFrom(src => src.main.pressure))
                .ForMember(dest =>
                    dest.Temp,
                    opt => opt.MapFrom(src => src.main.temp - 273))
                .ForMember(dest =>
                    dest.Wind,
                    opt => opt.MapFrom(src => src.wind.speed * 3.6))
                .ForMember(dest =>
                    dest.Humidity,
                    opt => opt.MapFrom(src => src.main.humidity));

            CreateMap<ForecastDay, ForecastdayCommon>()
                .ForMember(dest =>
                    dest.Time,
                    opt => opt.MapFrom(src => src.dt))
                .ForMember(dest =>
                    dest.Pressure,
                    opt => opt.MapFrom(src => src.main.pressure))
                .ForMember(dest =>
                    dest.Temp,
                    opt => opt.MapFrom(src => src.main.temp - 273))
                .ForMember(dest =>
                    dest.Wind,
                    opt => opt.MapFrom(src => src.wind.speed * 3.6))
                .ForMember(dest =>
                    dest.Humidity,
                    opt => opt.MapFrom(src => src.main.humidity));

            CreateMap<ForecastDTO, ForecastCommon>()
                .ForMember(dest =>
                    dest.City,
                    opt => opt.MapFrom(src => src.city.name))
                .ForMember(dest =>
                    dest.Day,
                    opt => opt.MapFrom(src => src.list));
        }
    }
}
