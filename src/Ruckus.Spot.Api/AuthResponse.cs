namespace Ruckus.Spot.Api
{
    using Newtonsoft.Json;

    public class AuthResponse
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        public string Role { get; set; }
    }
}
