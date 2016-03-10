namespace Ruckus.Spot.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class AuthHelper
    {
        public static string GetApiToken(RuckusApiConfiguration configuration, string email, string password)
        {
            using (var client = new HttpClient())
            {
                var data = new StringContent();
                data.Headers.Add("Content-Type", "application/json");
                client.PostAsync(configuration.ServerUrl + "api/v1/api_keys.json", data);
            }
        }
    }
}
