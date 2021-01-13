using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Weather.Entities;
using Weather.Repos;
using Weather.Services.Interface;

namespace Weather.Services
{
    public class DataService : IDataService
    {
        private readonly WeatherContext _context;

        public DataService(WeatherContext context)
        {
            _context = context;
        }

        public async Task<DataRequest> CreateWeatherData(DataRequest weather)
        {
            var newRecord = await _context.DataRequest.AddAsync(weather);
            DataRequest response = newRecord.Entity;
            
            await _context.SaveChangesAsync();
      
            return response;
        }

        public async Task<WeatherData> ReadWeatherData()
        {   
            var response = new WeatherData();
            
            var data = await _context.DataRequest.Include(a => a.ZipWeather).ToListAsync();

            response.ZipWeathers = data;
            
            return response;
        }
    }
}
