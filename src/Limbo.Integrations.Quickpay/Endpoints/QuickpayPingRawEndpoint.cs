using Limbo.Integrations.Quickpay.Http;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.Quickpay.Endpoints {
    
    /// <summary>
    /// Raw implementation of the <strong>Ping</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#ping</cref>
    /// </see>
    public class QuickpayPingRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="QuickpayHttpClient"/>.
        /// </summary>
        public QuickpayHttpClient Client { get; }

        #endregion

        #region Constructors

        internal QuickpayPingRawEndpoint(QuickpayHttpClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Sends a ping request to the Quickpay API. This may be used to test connectivity to the API.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#GET-ping---format-</cref>
        /// </see>
        public IHttpResponse GetPing() {
            return Client.Get("/ping");
        }

        #endregion

    }

}