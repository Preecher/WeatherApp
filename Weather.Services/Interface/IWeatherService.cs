using System.Threading.Tasks;
using Weather.Services.Model;

namespace Weather.Services.Interface
{
    public interface IWeatherService
    {
        public Task<WeatherMapResponse> GetWeatherData(string zipCode);
    }
}
