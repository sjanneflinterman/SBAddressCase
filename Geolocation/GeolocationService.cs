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
        private const string MapQuestUrl = "http://www.mapquestapi.com/directions/v2/route?key=";

        public GeolocationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        

        public async Task<double> GetDistance(Address start, Address end)
        {
            var url = BuildUrl(start, end, _configuration["MapQuest:APIKey"]);

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return 0;
                }

                var responseContentStream = await response.Content.ReadAsStreamAsync();

                try
                {
                    var convertedResponse = await JsonSerializer.DeserializeAsync<MapQuestApiResponse>(responseContentStream);

                    return convertedResponse?.Route?.Distance ?? 0;
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

        private static string BuildUrl(Address start, Address end, string key)
        {
            var url = $"{MapQuestUrl}{key}&from=";

            url += GetAddressString(start);
            url += "&to=";
            url += GetAddressString(end);

            return url;
        }

        private static string GetAddressString(Address address)
        {
            return $"{address.Street} {address.HouseNumber},{address.City}, {address.Country}";
        }

    }
}
