using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
                var httpResponse = await client.GetAsync(configuration.ServerUrl + "venues.json");
                var responseStream = await httpResponse.Content.ReadAsStreamAsync();
                using (var streamReader = new StreamReader(responseStream))
                {
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        return serializer.Deserialize<VenueSummary[]>(jsonReader);
                    }
                }
            }
        }
    }
}
