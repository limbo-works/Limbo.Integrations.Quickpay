using System;
using Limbo.Integrations.Quickpay.Http;
using Limbo.Integrations.Quickpay.Options.Payments;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.Quickpay.Endpoints {
    
    /// <summary>
    /// Raw implementation of the <strong>Payments</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#payments</cref>
    /// </see>
    public class QuickpayPaymentsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="QuickpayHttpClient"/>.
        /// </summary>
        public QuickpayHttpClient Client { get; }

        #endregion

        #region Constructors

        internal QuickpayPaymentsRawEndpoint(QuickpayHttpClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Creates a new payment with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="options"/> is <c>null</c>.</exception>
        public IHttpResponse CreatePayment(QuickpayCreatePaymentOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Creates a new payment link with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="options"/> is <c>null</c>.</exception>
        public IHttpResponse CreatePaymentLink(QuickpayCreatePaymentLinkOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Returns information about the payment with the specified <paramref name="paymentId"/>.
        /// </summary>
        /// <param name="paymentId">The ID of the payment.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPayment(long paymentId) {
            return GetPayment(new QuickpayGetPaymentOptions(paymentId));
        }

        /// <summary>
        /// Returns information about the payment matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="options"/> is <c>null</c>.</exception>
        public IHttpResponse GetPayment(QuickpayGetPaymentOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}