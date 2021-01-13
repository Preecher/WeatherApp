using System;
using System.ComponentModel.DataAnnotations;

namespace Weather.Entities
{
    public class ZipWeather
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string WeatherDescription { get; set; }
        public double Temp { get; set; }
        public double TempLow { get; set; }
        public double TempHigh { get; set; }
        public string WindSpeed { get; set; }
        public string Cloud { get; set; }
        public string Pressure { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime WeatherDate { get; set; }
        //public DataRequest DataRequest { get; set; }
    }

    public class DataRequest
    {
        [Key]
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public DateTime RequestDate { get; set; }
        public ZipWeather ZipWeather { get; set; }
    }
}