using Limbo.Integrations.Quickpay.Responses.Ping;

namespace Limbo.Integrations.Quickpay.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Payments</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#ping</cref>
    /// </see>
    public class QuickpayPingEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Quickpay service implementation.
        /// </summary>
        public QuickpayHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public QuickpayPingRawEndpoint Raw => Service.Client.Ping;

        #endregion

        #region Constructors

        internal QuickpayPingEndpoint(QuickpayHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Sends a ping request to the Quickpay API. This may be used to test connectivity to the API.
        /// </summary>
        /// <returns>An instance of <see cref="QuickpayPongResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#GET-ping---format-</cref>
        /// </see>
        public QuickpayPongResponse GetPing() {
            return new QuickpayPongResponse(Raw.GetPing());
        }

        #endregion

    }

}