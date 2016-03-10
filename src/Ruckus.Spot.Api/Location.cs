namespace Ruckus.Spot.Api
{
    using Newtonsoft.Json;

    public class Location
    {
        [JsonProperty("mac")]
        public string Mac { get; set; }
        
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
        
        [JsonProperty("floor_number")]
        public int FloorNumber { get; set; }
        
        [JsonProperty("x")]
        public double X { get; set; }
        
        [JsonProperty("y")]
        public double Y { get; set; }
        
        [JsonProperty("located_inside")]
        public bool IsLocatedInside { get; set; }
        public Zones[] Zones { get; set; }
    }
}