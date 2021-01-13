using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace Weather.Repos
{
    public class ContextFactory : IDesignTimeDbContextFactory<WeatherContext>
    {
        public WeatherContext CreateDbContext(string[] args)
        {
            //var _connString = _config.GetConnectionString("SqlConnectionString");
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var _connString = config.GetConnectionStringOrSetting("SqlConnectionString");

            var builder = new DbContextOptionsBuilder<WeatherContext>();
            builder.UseSqlServer(_connString);

            return new WeatherContext(builder.Options);
        }
    }

}
