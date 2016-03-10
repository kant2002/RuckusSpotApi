namespace Ruckus.Spot.Api
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class GenericError
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public Dictionary<string, string> Errors { get; set; }
    }
}
