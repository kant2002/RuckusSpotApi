namespace Ruckus.Spot.Api
{
#if NET451
    using System.Configuration;
#endif

    public class RuckusApiConfiguration
    {
#if NET451
        private static string DefaultServerUrl { get; set; }

        private static string DefaultApiToken { get; set; }

        static RuckusApiConfiguration()
        {
            DefaultServerUrl = ConfigurationManager.AppSettings["Ruckus:ServerUrl"];
            DefaultApiToken = ConfigurationManager.AppSettings["Ruckus:ApiToken"];
        }

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
