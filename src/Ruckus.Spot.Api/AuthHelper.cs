namespace Ruckus.Spot.Api
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class AuthHelper
    {
        public static async Task<AuthResponse> GetApiToken(RuckusApiConfiguration configuration, string email, string password)
        {
            using (var client = new HttpClient())
            {
                var request = new AuthRequest()
                {
                    Email = email,
                    Password = password
                };
                var serializer = new JsonSerializer();
                var requestBuilder = new StringBuilder();
                using (var writer = new StringWriter(requestBuilder))
                {
                    serializer.Serialize(writer, request);
                }

                var data = new StringContent(requestBuilder.ToString());
                data.Headers.Add("Content-Type", "application/json");
                var httpResponse = await client.PostAsync(configuration.ServerUrl + "api_keys.json", data);
                var responseStream = await httpResponse.Content.ReadAsStreamAsync();
                using (var streamReader = new StreamReader(responseStream))
                {
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        return serializer.Deserialize<AuthResponse>(jsonReader);
                    }
                }
            }
        }
    }
}
