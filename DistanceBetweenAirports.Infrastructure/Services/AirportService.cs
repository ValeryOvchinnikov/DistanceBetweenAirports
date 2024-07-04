using DistanceBetweenAirports.Domain.Entities;
using DistanceBetweenAirports.Domain.Services;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using DistanceBetweenAirports.Domain.Exceptions;
using System.Net;

namespace DistanceBetweenAirports.Infrastructure.Services
{
    public class AirportService:IAirportService
    {
        private readonly HttpClient _httpClient;

        public AirportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Airport> GetAirportAsync(string iataCode)
        {
           
                var url = $"https://places-dev.cteleport.com/airports/{iataCode}";
                var response = await _httpClient.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new AirportNotFoundException(iataCode);
                }
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var airport = JsonConvert.DeserializeObject<Airport>(json);

                return airport;
           
        }
    }
}
