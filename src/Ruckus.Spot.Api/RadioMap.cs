using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ruckus.Spot.Api
{
    public class RadioMap
    {
        /// <summary>
        /// Gets or sets Radio map name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value whether this radio map is a production version
        /// </summary>
        [JsonProperty("production")]
        public bool Production { get; set; }

        /// <summary>
        /// Gets or sets start time of radio map
        /// </summary>
        [JsonProperty("start_timestamp")]
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets end time of radio map. Will be null for a production radio map if it is currently in use.
        /// </summary>
        [JsonProperty("end_timestamp")]
        public string EndDate { get; set; }

        public double Width { get; set; }
        public double Height { get; set; }
        public double Scale { get; set; }
        public Floor[] Floors { get; set; }
    }
}
