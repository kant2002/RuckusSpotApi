namespace Ruckus.Spot.Api
{
    using Newtonsoft.Json;

    public class AuthRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
