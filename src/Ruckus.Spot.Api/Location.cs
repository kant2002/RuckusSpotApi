namespace Ruckus.Spot.Api
{
    using Newtonsoft.Json;

    public class Location
    {
        /// <summary>
        /// Gets or sets Radio map name
        /// </summary>
        [JsonProperty("mac")]
        public string Mac { get; set; }

        /// <summary>
        /// Gets or sets Radio map name
        /// </summary>
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// Gets or sets Radio map name
        /// </summary>
        [JsonProperty("floor_number")]
        public int FloorNumber { get; set; }
        
        /// <summary>
        /// Gets or sets Radio map name
        /// </summary>
        [JsonProperty("x")]
        public double X { get; set; }

        /// <summary>
        /// Gets or sets Radio map name
        /// </summary>
        [JsonProperty("y")]
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets Radio map name
        /// </summary>
        [JsonProperty("located_inside")]
        public bool IsLocatedInside { get; set; }
        public Zones[] Zones { get; set; }
    }
}