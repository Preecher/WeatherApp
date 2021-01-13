using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Weather.Repos
{
    public class ContextFactory : IDesignTimeDbContextFactory<WeatherContext>
    {
        private readonly IConfiguration _config;
        private static string _connString;

        public ContextFactory(IConfiguration config)
        {
            _config = config;
        }

        public WeatherContext CreateDbContext(string[] args)
        {
            _connString = _config.GetConnectionString("SqlConnectionString");

            var builder = new DbContextOptionsBuilder<WeatherContext>();
            builder.UseSqlServer(_connString);

            return new WeatherContext(builder.Options);
        }
    }

}
