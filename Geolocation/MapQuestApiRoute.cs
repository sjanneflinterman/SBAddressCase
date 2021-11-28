using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Geolocation
{
    public class MapQuestApiRoute
    {
        [JsonPropertyName("distance")]
        public double Distance { get; set; }
    }
}
