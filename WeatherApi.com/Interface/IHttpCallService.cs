namespace WeatherApi.com.Interface
{
    public interface IHttpCallService
    {
        Task<T> GetCurrentWeather<T>();
        Task<T> GetForecast<T>();
    }
}
