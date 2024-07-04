using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DistanceBetweenAirports.Domain.Entities
{
    public class Airport
    {
        
        public string Iata { get; set; }

        public string Name { get; set; }

        public string City { get; set; }
        [JsonProperty("city_iata")]
        public string CityIata { get; set; }

        public string Icao { get; set; }
        public string Country { get; set; }
        [JsonProperty("country_iata")]
        public string CountryIata { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
        public int Rating { get; set; }

        public int Hubs { get; set; }
        public string TimeZoneRegionName { get; set; }

        public string Type { get; set; }

        public Airport() { }

        public Airport(string iata, string name, double latitude, double longitude, string c)
        {
            Iata = iata;
            Name = name;
            var location = new Location
            {
                Latitude = latitude,
                Longitude = longitude
            };

           
        }

        public Airport(string iata, string name, string city, string cityIata, string icao, string country, string countryIata, Location location, int rating, int hubs, string timeZoneRegionName, string type)
        {
            Iata = iata ?? throw new ArgumentNullException(nameof(iata));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            City = city ?? throw new ArgumentNullException(nameof(city));
            CityIata = cityIata ?? throw new ArgumentNullException(nameof(cityIata));
            Icao = icao ?? throw new ArgumentNullException(nameof(icao));
            Country = country ?? throw new ArgumentNullException(nameof(country));
            CountryIata = countryIata ?? throw new ArgumentNullException(nameof(countryIata));
            Location = location ?? throw new ArgumentNullException(nameof(location));
            Rating = rating;
            Hubs = hubs;
            TimeZoneRegionName = timeZoneRegionName ?? throw new ArgumentNullException(nameof(timeZoneRegionName));
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }
    }

    public class Location
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }
}
