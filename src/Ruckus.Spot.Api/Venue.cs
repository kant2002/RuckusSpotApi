using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ruckus.Spot.Api
{
    public class Venue
    {
        /// <summary>
        /// Gets or sets venue identifier
        /// </summary>
        [JsonProperty("venue_id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets venue name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets larger version of exterior_thumbnail_url provided by the venues endpoint
        /// </summary>
        [JsonProperty("exterior_image_url")]
        public string ExteriorImage { get; set; }

        /// <summary>
        /// Gets or sets Street number and name, including apartment or suite if needed.
        /// </summary>
        [JsonProperty("street_address")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets City or village
        /// </summary>
        [JsonProperty("locality")]
        public string Locality { get; set; }

        /// <summary>
        /// Gets or sets State or province
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets postal code
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets country name
        /// </summary>
        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets Array formatted as [longitude, latitude], as described for a Point object in the GeoJSON specifications
        /// </summary>
        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }

        /// <summary>
        /// Gets or sets String that can be referenced against the IANA Time Zone Database.
        /// </summary>
        [JsonProperty("time_zone_id")]
        public string TimeZoneId { get; set; }
    }
}
