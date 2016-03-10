using Newtonsoft.Json;

namespace Ruckus.Spot.Api
{
    public class Zone
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}