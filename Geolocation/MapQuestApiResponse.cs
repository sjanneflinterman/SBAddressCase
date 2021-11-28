using System.Text.Json.Serialization;

namespace Geolocation
{
    public class MapQuestApiResponse
    {
        [JsonPropertyName("route")] public MapQuestApiRoute? Route { get; set; }
    }
}
