using AutoMapper;
using OpenWeather.Domain.Models.CurrentWeather;
using WeatherApi.Library.Common.Models;

namespace OpenWeather.MappingConfigurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CurrentWeatherDTO, CurrentWeatherCommon>()
                .ForMember(dest =>
                    dest.city,
                    opt => opt.MapFrom(src => src.name))
                .ForMember(dest =>
                    dest.time,
                    opt => opt.MapFrom(src => src.dt))
                .ForMember(dest =>
                    dest.pressure,
                    opt => opt.MapFrom(src => src.main.pressure))
                .ForMember(dest =>
                    dest.temp,
                    opt => opt.MapFrom(src => src.main.temp - 273))
                .ForMember(dest =>
                    dest.wind,
                    opt => opt.MapFrom(src => src.wind.speed * 3.6))
                .ForMember(dest =>
                    dest.humidity,
                    opt => opt.MapFrom(src => src.main.humidity));
        }
    }
}
