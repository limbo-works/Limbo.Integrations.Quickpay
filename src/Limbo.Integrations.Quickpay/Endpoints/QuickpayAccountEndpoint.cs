using Limbo.Integrations.Quickpay.Responses.Account;

namespace Limbo.Integrations.Quickpay.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Account</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#account</cref>
    /// </see>
    public class QuickpayAccountEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Quickpay service implementation.
        /// </summary>
        public QuickpayHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public QuickpayAccountRawEndpoint Raw => Service.Client.Account;

        #endregion

        #region Constructors

        internal QuickpayAccountEndpoint(QuickpayHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns information about the current merchant account.
        /// </summary>
        /// <returns>An instance of <see cref="QuickpayMerchantResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#GET-account---format-</cref>
        /// </see>
        public QuickpayMerchantResponse GetAccount() {
            return new QuickpayMerchantResponse(Raw.GetAccount());
        }

        #endregion

    }

}