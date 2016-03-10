using Newtonsoft.Json;

namespace Ruckus.Spot.Api
{
    public class ZoneMap
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("zone_image_url")]
        public string ZoneImageUrl { get; set; }

        [JsonProperty("zones")]
        public Zone[] Zones { get; set; }
    }
}