using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SBData.Entities;
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
            var url = GetDistanceRequestUrl(start, end, _configuration["MapQuest:APIKey"]);

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) return 0;

            var responseContentStream = await response.Content.ReadAsStreamAsync();

            try
            {
                var deserializedResponse = await JsonSerializer.DeserializeAsync<MapQuestApiResponse>(responseContentStream);

                return deserializedResponse?.Route?.Distance ?? 0;
            }
            catch (JsonException e)
            {
                return 0;
            }
        }

        private static string GetDistanceRequestUrl(Address start, Address end, string key)
        {
            return $"{MapQuestUrl}{key}&from={GetAddressString(start)}&to={GetAddressString(end)}";
        }

        private static string GetAddressString(Address address)
        {
            return $"{address.Street} {address.HouseNumber}, {address.City}, {address.Country}";
        }
    }
}
