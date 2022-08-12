using WeatherApi.com.Models.Forecast;

namespace WeatherApi.com.Interface
{
    public interface IForecastHelper
    {
        public void FixTime(ForecastDTO model);
    }


}
