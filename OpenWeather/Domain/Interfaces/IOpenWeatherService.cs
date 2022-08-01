namespace OpenWeather.Domain.Interfaces
{
    public interface IOpenWeatherService
    {
        Task<T> GetCurrentWeather<T>();
        Task<T> GetForecast<T>();
    }
}
