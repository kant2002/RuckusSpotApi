using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Ruckus.Spot.Api
{
    public class RuckusApi
    {
        private RuckusApiConfiguration configuration;

        public RuckusApi(RuckusApiConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// List manageable venues
        /// </summary>
        /// <returns>Sequence of <see cref="VenueSummary"/> information.</returns>
        /// <remarks>Venues are the primary resource managed by an SPoT Location deployment. Each venue represents a physical space that can vary in size from a small room to a large multistory building.</remarks>
        public async Task<IEnumerable<VenueSummary>> GetVenues()
        {
            using (var client = new HttpClient())
            {
                var serializer = new JsonSerializer();
                var byteArray = Encoding.UTF8.GetBytes(this.configuration.ApiToken + ":X");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var httpResponse = await client.GetStringAsync(configuration.ServerUrl + "venues.json");
                using (var streamReader = new StringReader(httpResponse))
                {
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        return serializer.Deserialize<VenueSummary[]>(jsonReader);
                    }
                }
            }
        }

        /// <summary>
        /// Get venue details
        /// </summary>
        /// <param name="id">Id of the venue for which to get information.</param>
        /// <returns>Information about <see cref="Venue"/>.</returns>
        public async Task<Venue> GetVenue(string id)
        {
            using (var client = new HttpClient())
            {
                var serializer = new JsonSerializer();
                var byteArray = Encoding.UTF8.GetBytes(this.configuration.ApiToken + ":X");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var httpResponse = await client.GetStringAsync(configuration.ServerUrl + $"venues/{id}.json");
                using (var streamReader = new StringReader(httpResponse))
                {
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        return serializer.Deserialize<Venue>(jsonReader);
                    }
                }
            }
        }
    }
}
