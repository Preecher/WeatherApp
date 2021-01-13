using System.Threading.Tasks;
using Weather.Entities;

namespace Weather.Services.Interface
{
    public interface IDataService
    {
        public Task<DataRequest> CreateWeatherData(DataRequest weather);
        public Task<WeatherData> ReadWeatherData();
    }
}
