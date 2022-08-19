using AutoMapper;
using WeatherApi.com.Models.CurrentWeather;
using WeatherApi.com.Models.Forecast;
using WeatherApi.Library.Common.Models;
using WeatherApi.com.Models;

namespace WeatherApi.com
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CurrentWeatherDTO, CurrentWeatherCommon>()
                .ForMember(dest =>
                    dest.city,
                    opt => opt.MapFrom(src => src.location.name))
                .ForMember(dest =>
                    dest.time,
                    opt => opt.MapFrom(src => src.location.localtime_epoch))
                .ForMember(dest =>
                    dest.pressure,
                    opt => opt.MapFrom(src => src.current.pressure_mb))
                .ForMember(dest =>
                    dest.temp,
                    opt => opt.MapFrom(src => src.current.temp_c))
                .ForMember(dest =>
                    dest.wind,
                    opt => opt.MapFrom(src => src.current.wind_kph))
                .ForMember(dest =>
                    dest.humidity,
                    opt => opt.MapFrom(src => src.current.humidity));

            CreateMap<HourElement, ForecastdayCommon>()
                .ForMember(dest =>
                    dest.time,
                    opt => opt.MapFrom(src => src.time_epoch))
                .ForMember(dest =>
                    dest.wind,
                    opt => opt.MapFrom(src => src.wind_kph))
                .ForMember(dest =>
                    dest.humidity,
                    opt => opt.MapFrom(src => src.humidity))
                .ForMember(dest =>
                    dest.pressure,
                    opt => opt.MapFrom(src => src.pressure_mb))
                .ForMember(dest =>
                    dest.temp,
                    opt => opt.MapFrom(src => src.temp_c));

            
            CreateMap<ForecastDTO, ForecastCommon>()
                .ForMember(dest =>
                    dest.city,
                    opt => opt.MapFrom(src => src.location.name))
                .ForPath(dest =>
                    dest.day,
                    opt => opt.MapFrom(src => src.forecast.forecastday[0].hour)); // need fix in the future
        }
    }
}
