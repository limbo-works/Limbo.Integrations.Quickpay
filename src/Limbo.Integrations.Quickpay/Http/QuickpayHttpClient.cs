using Limbo.Integrations.Quickpay.Endpoints;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Essentials.Security;

namespace Limbo.Integrations.Quickpay.Http {

    /// <summary>
    /// Class for handling the HTTP communication with the Quickpay API.
    /// </summary>
    public class QuickpayHttpClient : HttpClient {

        #region Properties

        /// <summary>
        /// Gets or sets the API token.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets a reference to the raw <strong>Account</strong> repository.
        /// </summary>
        public QuickpayAccountRawEndpoint Account { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Payments</strong> repository.
        /// </summary>
        public QuickpayPaymentsRawEndpoint Payments { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Ping</strong> repository.
        /// </summary>
        public QuickpayPingRawEndpoint Ping { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options
        /// </summary>
        public QuickpayHttpClient() {
            Account = new QuickpayAccountRawEndpoint(this);
            Payments = new QuickpayPaymentsRawEndpoint(this);
            Ping = new QuickpayPingRawEndpoint(this);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="apiKey"/>.
        /// </summary>
        /// <param name="apiKey">The API key to be used.</param>
        public QuickpayHttpClient(string apiKey) {
            ApiKey = apiKey;
            Payments = new QuickpayPaymentsRawEndpoint(this);
            Ping = new QuickpayPingRawEndpoint(this);
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        protected override void PrepareHttpRequest(IHttpRequest request) {
            
            // This integration is currently for V10 of the Quickpay API
            request.Headers.Add("Accept-Version", "v10");

            // Prepend the domain and scheme to the URL if not already specified
            if (request.Url.StartsWith("/")) request.Url = $"https://api.quickpay.net/{request.Url}";

            // Add the API key via the "Authorization" header (if specified)
            if (string.IsNullOrWhiteSpace(ApiKey) == false) {
                request.Authorization = $"Basic {SecurityUtils.Base64Encode($":{ApiKey}")}";
            }

        }

        #endregion

    }

}