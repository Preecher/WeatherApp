using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Weather.Repos;
using Weather.Services;
using Weather.Services.Interface;

[assembly: FunctionsStartup(typeof(WeatherApp.Startup))]

namespace WeatherApp
{
    class Startup: FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddHttpClient();
            builder.Services.AddLogging();
            builder.Services.AddTransient<IDataService, DataService>();
            builder.Services.AddTransient<IWeatherService, WeatherMapService>();

            string sqlConnection = config.GetConnectionStringOrSetting("SqlConnectionString");
            builder.Services.AddDbContext<WeatherContext>(
                options => options.UseSqlServer(sqlConnection));
        }
    }
}
