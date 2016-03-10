using Newtonsoft.Json;

namespace Ruckus.Spot.Api
{
    public class Zones
    {
        [JsonProperty("zone_map_name")]
        public string ZoneMapName { get; set; }

        [JsonProperty("zone_name")]
        public string ZoneName { get; set; }
    }
}