using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Weather.Entities;
using Weather.Services.Interface;

namespace WeatherApp
{
    public class WeatherApp
    {
        private readonly IWeatherService _weatherService;
        private readonly IDataService _dataService;
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public WeatherApp(IWeatherService weatherMapService, IDataService dataService)
        {
            _weatherService = weatherMapService;
            _dataService = dataService;
        }

        [FunctionName("GetHistory")]
        public async Task<IActionResult> GetHistory(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            var response = await _dataService.ReadWeatherData();
            return new OkObjectResult(response);
        }

        [FunctionName("GetZipWeather")]
        public async Task<IActionResult> GetZipWeather(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            if (!ValidateZip(requestBody))
            {
                return new BadRequestObjectResult("Invalid ZipCode. Zipcode must be numeric and 5 digits");
            }

            var zipCode = JsonConvert.DeserializeObject<string>(requestBody);

            var data = await _weatherService.GetWeatherData(zipCode);

            if (data == null)
            {
                return new BadRequestObjectResult("Weather data not found for zipcode: " + zipCode);
            }

            DataRequest weather = BuildWeatherData(zipCode, data);

            var response = await _dataService.CreateWeatherData(weather);

            return new OkObjectResult(response);
        }

        private bool ValidateZip(string zipCode)
        {
            if (string.IsNullOrEmpty(zipCode))
                return false;

            if (zipCode.Length != 5)
                return false;

            var isNumeric = int.TryParse(zipCode, out int n);
            
            return isNumeric;

        }

        private DataRequest BuildWeatherData(string zipCode, Weather.Services.Model.WeatherMapResponse data)
        {
            var weather = new DataRequest
            {
                ZipCode = zipCode,
                RequestDate = DateTime.Now,
                ZipWeather = new ZipWeather
                {
                    City = data.Name,
                    Country = data.Sys.Country,
                    WeatherDescription = data.Weather.FirstOrDefault().Description,
                    Temp = data.Main.Temp,
                    TempLow = data.Main.TempMin,
                    TempHigh = data.Main.TempMax,
                    WindSpeed = string.Concat(data.Wind.Speed, " mph ", DegreesToCardinal(data.Wind.Degrees)),
                    Cloud = string.Concat(data.Clouds.All, " %"),
                    Pressure = string.Concat(data.Main.Pressure, " mm"),
                    Longitude = data.Coord.Lon,
                    Latitude = data.Coord.Lat,
                    WeatherDate = FromUnixTime(data.Dt).ToLocalTime(),
                }
            };
            return weather;
        }

        public static DateTime FromUnixTime(long unixTime)
        {
            return Epoch.AddSeconds(unixTime);
        }
        private string DegreesToCardinal(double degrees)
        {
            string[] caridnals = { "N", "NE", "E", "SE", "S", "SW", "W", "NW", "N" };
            return caridnals[(int)Math.Round((degrees % 360) / 45)];
        }

    }
}
