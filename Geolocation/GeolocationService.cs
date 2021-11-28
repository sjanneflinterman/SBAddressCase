using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Threading.Tasks;
using SBData.Entities;
using System.Net.Http.Json;
using System.Text.Json;

namespace Geolocation
{
    public class GeolocationService : IGeolocationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public GeolocationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_configuration["MapQuest:APIKey"]);
        }
        

        public async Task<double> GetDistance(Address start, Address end)
        {
            var url = $"{_configuration["MapQuest:URL"]}{_configuration["MapQuest:APIKey"]}";

            url += "&from=";
            url += GetAddressString(start);
            url += "&to=";
            url += GetAddressString(end);

            try
            {
                _httpClient.Timeout = TimeSpan.FromMinutes(30);

                var uri = new Uri(url);

                var response = await _httpClient.GetAsync(uri);

                if (!response.IsSuccessStatusCode)
                {
                    return 0;
                }

                using var responseContentStream = await response.Content.ReadAsStreamAsync();

                try
                {
                    var convertedResponse = await JsonSerializer.DeserializeAsync<MapQuestApiResponse>(responseContentStream);
                    var distance =  convertedResponse?.Route?.Distance ?? 0;
                    return distance;
                }
                catch (JsonException e)
                {
                    return 0;
                }

            }
            catch (TaskCanceledException ex)
            {
                var test = ex.CancellationToken;
            }

            return 0;

        }

        private string GetAddressString(Address address)
        {
            return $"{address.Street} {address.HouseNumber},{address.City}, {address.Country}";
        }

    }



}
