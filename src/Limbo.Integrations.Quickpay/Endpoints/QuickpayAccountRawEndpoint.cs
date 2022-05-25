using Limbo.Integrations.Quickpay.Http;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.Quickpay.Endpoints {
    
    /// <summary>
    /// Raw implementation of the <strong>Account</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#account</cref>
    /// </see>
    /// <see>
    ///     <cref>https://api.quickpay.net/docs/v10/merchant/api/account.json</cref>
    /// </see>
    public class QuickpayAccountRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="QuickpayHttpClient"/>.
        /// </summary>
        public QuickpayHttpClient Client { get; }

        #endregion

        #region Constructors

        internal QuickpayAccountRawEndpoint(QuickpayHttpClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns information about the current merchant account.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#GET-account---format-</cref>
        /// </see>
        public IHttpResponse GetAccount() {
            return Client.Get("/account");
        }

        #endregion

    }

}