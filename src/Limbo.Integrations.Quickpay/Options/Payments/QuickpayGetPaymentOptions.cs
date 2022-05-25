using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;

namespace Limbo.Integrations.Quickpay.Options.Payments {

    /// <summary>
    /// Class with options for getting an existing payment.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#GET-payments--id---format-</cref>
    /// </see>
    public class QuickpayGetPaymentOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the payment.
        /// </summary>
        public long PaymentId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public QuickpayGetPaymentOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="paymentId"/>.
        /// </summary>
        /// <param name="paymentId">The ID of the payment.</param>
        public QuickpayGetPaymentOptions(long paymentId) {
            PaymentId = paymentId;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {
            if (PaymentId == 0) throw new PropertyNotSetException(nameof(PaymentId));
            return HttpRequest.Get($"/payments/{PaymentId}");
        }

        #endregion

    }

}