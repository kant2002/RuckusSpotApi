namespace Ruckus.Spot.Api
{
#if NET451
    using System.Configuration;
#endif

    public class RuckusApiConfiguration
    {
#if NET451
        /// <summary>
        /// Default values for the server url.
        /// </summary>
        private static string DefaultServerUrl { get; set; }

        /// <summary>
        /// Default values for API token.
        /// </summary>
        private static string DefaultApiToken { get; set; }

        /// <summary>
        /// Initializes static members of <see cref="RuckusApiConfiguration"/> class.
        /// </summary>
        static RuckusApiConfiguration()
        {
            DefaultServerUrl = ConfigurationManager.AppSettings["Ruckus:ServerUrl"];
            DefaultApiToken = ConfigurationManager.AppSettings["Ruckus:ApiToken"];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuckusApiConfiguration"/> class.
        /// </summary>
        public RuckusApiConfiguration()
        {
            this.ApiToken = DefaultApiToken;
            this.ServerUrl = DefaultServerUrl;
        }
#endif

        /// <summary>
        /// Gets or sets address of the server endpoint.
        /// </summary>
        public string ServerUrl { get; set; }

        /// <summary>
        /// Get or sets API access token.
        /// </summary>
        public string ApiToken { get; set; }
    }
}
