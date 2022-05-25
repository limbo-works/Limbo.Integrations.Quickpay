using System;
using Limbo.Integrations.Quickpay.Options.Payments;
using Limbo.Integrations.Quickpay.Responses.Payments;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.Quickpay.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Payments</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#payments</cref>
    /// </see>
    public class QuickpayPaymentsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Quickpay service implementation.
        /// </summary>
        public QuickpayHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public QuickpayPaymentsRawEndpoint Raw => Service.Client.Payments;

        #endregion

        #region Constructors

        internal QuickpayPaymentsEndpoint(QuickpayHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Creates a new payment with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="QuickpayPaymentResponse"/> representing the response.</returns>
        public QuickpayPaymentResponse CreatePayment(QuickpayCreatePaymentOptions options) {
            return new QuickpayPaymentResponse(Raw.CreatePayment(options));
        }

        /// <summary>
        /// Creates a new payment link with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="QuickpayPaymentLinkResponse"/> representing the response.</returns>
        public QuickpayPaymentLinkResponse CreatePaymentLink(QuickpayCreatePaymentLinkOptions options) {
            return new QuickpayPaymentLinkResponse(Raw.CreatePaymentLink(options));
        }

        /// <summary>
        /// Returns information about the payment with the specified <paramref name="paymentId"/>.
        /// </summary>
        /// <param name="paymentId">The ID of the payment.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public QuickpayPaymentResponse GetPayment(long paymentId) {
            return new QuickpayPaymentResponse(Raw.GetPayment(paymentId));
        }

        /// <summary>
        /// Returns information about the payment matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="options"/> is <c>null</c>.</exception>
        public QuickpayPaymentResponse GetPayment(QuickpayGetPaymentOptions options) {
            return new QuickpayPaymentResponse(Raw.GetPayment(options));
        }

        #endregion

    }

}