using System.Threading.Tasks;
using Weather.Entities;

namespace Weather.Services.Interface
{
    public interface IDataService
    {
        public Task<ZipWeather> CreateWeatherData(ZipWeather weather);
        public Task<WeatherData> ReadWeatherData();
    }
}
