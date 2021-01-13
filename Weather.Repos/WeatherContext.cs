using Microsoft.EntityFrameworkCore;
using Weather.Entities;

namespace Weather.Repos
{
    public class WeatherContext: DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options)
                : base(options)
        { }

        public DbSet<ZipWeather> ZipWeather { get; set; }
        public DbSet<DataRequest> DataRequest { get; set; }
    }
}
