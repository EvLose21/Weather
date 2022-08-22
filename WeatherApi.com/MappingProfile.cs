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
                    dest.City,
                    opt => opt.MapFrom(src => src.Location.Name))
                .ForMember(dest =>
                    dest.Time,
                    opt => opt.MapFrom(src => src.Location.Localtime_epoch))
                .ForMember(dest =>
                    dest.Pressure,
                    opt => opt.MapFrom(src => src.Current.Pressure_mb))
                .ForMember(dest =>
                    dest.Temp,
                    opt => opt.MapFrom(src => src.Current.Temp_c))
                .ForMember(dest =>
                    dest.Wind,
                    opt => opt.MapFrom(src => src.Current.Wind_kph))
                .ForMember(dest =>
                    dest.Humidity,
                    opt => opt.MapFrom(src => src.Current.Humidity));

            CreateMap<HourElement, ForecastdayCommon>()
                .ForMember(dest =>
                    dest.Time,
                    opt => opt.MapFrom(src => src.Time_epoch))
                .ForMember(dest =>
                    dest.Wind,
                    opt => opt.MapFrom(src => src.Wind_kph))
                .ForMember(dest =>
                    dest.Humidity,
                    opt => opt.MapFrom(src => src.Humidity))
                .ForMember(dest =>
                    dest.Pressure,
                    opt => opt.MapFrom(src => src.Pressure_mb))
                .ForMember(dest =>
                    dest.Temp,
                    opt => opt.MapFrom(src => src.Temp_c));

            
            CreateMap<ForecastDTO, ForecastCommon>()
                .ForMember(dest =>
                    dest.City,
                    opt => opt.MapFrom(src => src.Location.Name))
                .ForPath(dest =>
                    dest.Day,
                    opt => opt.MapFrom(src => src.Forecast.Forecastday[0].Hour)); // todo need fix in the future
        }
    }
}
