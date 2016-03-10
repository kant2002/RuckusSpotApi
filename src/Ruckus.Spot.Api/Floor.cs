using Newtonsoft.Json;

namespace Ruckus.Spot.Api
{
    public class Floor
    {
        /// <summary>
        /// Gets or sets Radio map name
        /// </summary>
        [JsonProperty("number")]
        public int Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("map_image_url")]
        public string MapImageUrl { get; set; }

        [JsonProperty("inside_image_url")]
        public string InsideImageUrl { get; set; }

        [JsonProperty("zone_maps")]
        public ZoneMap[] ZoneMaps { get; set; }
    }
}