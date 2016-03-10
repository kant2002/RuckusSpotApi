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

        /// <summary>
        /// Get venue radio maps
        /// </summary>
        /// <param name="id">Id of the venue for which to get information.</param>
        /// <returns>Sequence of <see cref="RadioMapSummary"/> assigned to the venue.</returns>
        /// <remarks>
        /// A venue has one or many radio maps, which contains the indoor maps and information 
        /// about the venue's floors, zones and calibration data. These radio maps can either be 
        /// used in production or not, determined by the production attribute. Because a 
        /// venue can change over time, production radio maps have start_timestamp and end_timestamp 
        /// attributes. For a production radio map currently in use, its end_timestamp will be null.
        /// </remarks>
        public async Task<IEnumerable<RadioMapSummary>> GetVenueRadioMaps(string id)
        {
            using (var client = new HttpClient())
            {
                var serializer = new JsonSerializer();
                var byteArray = Encoding.UTF8.GetBytes(this.configuration.ApiToken + ":X");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var httpResponse = await client.GetStringAsync(configuration.ServerUrl + $"venues/{id}/radio_maps.json");
                using (var streamReader = new StringReader(httpResponse))
                {
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        return serializer.Deserialize<RadioMapSummary[]>(jsonReader);
                    }
                }
            }
        }

        /// <summary>
        /// Get radio map details
        /// </summary>
        /// <param name="venueId">Id of the venue for which to get information.</param>
        /// <param name="name">Name of the radio map</param>
        /// <returns>Information about the <see cref="RadioMap"/>.</returns>
        public async Task<RadioMap> GetRadioMap(string venueId, string name)
        {
            using (var client = new HttpClient())
            {
                var serializer = new JsonSerializer();
                var byteArray = Encoding.UTF8.GetBytes(this.configuration.ApiToken + ":X");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var httpResponse = await client.GetStringAsync(configuration.ServerUrl + $"venues/{venueId}/radio_maps/{name}.json");
                using (var streamReader = new StringReader(httpResponse))
                {
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        return serializer.Deserialize<RadioMap>(jsonReader);
                    }
                }
            }
        }
    }
}
