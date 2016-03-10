using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ruckus.Spot.Api
{
    public class VenueSummary
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
        /// Gets or sets thumbnail showing the exterior of a venue. Can be used to visually enhance a list view of venues.
        /// </summary>
        [JsonProperty("exterior_thumbnail_url")]
        public string ExteriorThumbnail { get; set; }
    }
}
