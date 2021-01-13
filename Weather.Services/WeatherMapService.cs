using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Services.Interface;
using Weather.Services.Model;

namespace Weather.Services
{
    public class WeatherMapService : IWeatherService
    {
        private readonly ILogger<IWeatherService> _logger;
        private readonly IConfiguration _config;
        private readonly HttpClient _client;

        public WeatherMapService(ILogger<IWeatherService> logger, HttpClient client, IConfiguration config)
        {
            _logger = logger;
            _client = client;
            _config = config;
        }

        public async Task<WeatherMapResponse> GetWeatherData(string zipCode)
        {
            var apiKey = _config.GetConnectionStringOrSetting("ApiKey");
            
            var urlb = new UriBuilder
            {
                Scheme = "https",
                Host = "api.openweathermap.org",
                Path = "data/2.5/weather",
                Query = $"zip={zipCode}&units=imperial&appid={apiKey}"
            };
            
            var response = await _client.GetAsync(urlb.Uri);
            if(!response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Failed to get data: " + response.StatusCode.ToString());
                return null;
            }

            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<WeatherMapResponse>(result);

            return data;
        }
    }
}
