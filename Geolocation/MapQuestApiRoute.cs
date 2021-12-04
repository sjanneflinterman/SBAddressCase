using System.Text.Json.Serialization;

namespace Geolocation
{
    public class MapQuestApiRoute
    {
        [JsonPropertyName("distance")]
        public double Distance { get; set; }
    }
}
