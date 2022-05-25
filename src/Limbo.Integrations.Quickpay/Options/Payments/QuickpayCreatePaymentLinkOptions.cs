using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;

namespace Limbo.Integrations.Quickpay.Options.Payments {
    
    /// <summary>
    /// Class with options for creating a new payment.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#PUT-payments--id-link---format-</cref>
    /// </see>
    public class QuickpayCreatePaymentLinkOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the payment.
        /// </summary>
        public long PaymentId { get; set; }

        /// <summary>
        /// Gets or sets the amount to pay. Eg. <c>400000</c> for 400 DKK, if the currency is DKK. 
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the language of the payment page - eg. <c>da</c> for Danish, or <c>en</c> for English.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the URL the cardholder is redirected to after authorize.
        /// </summary>
        public string ContinueUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL the cardholder is redirected to after cancelation
        /// </summary>
        public string CancelUrl { get; set; }

        /// <summary>
        /// Gets or sets the endpoint for async callback.
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Gets or sets whether the payment should be captured after authorization. Default is <c>false</c>.
        /// </summary>
        public bool AutoCapture { get; set; }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            if (PaymentId == 0) throw new PropertyNotSetException(nameof(PaymentId));

            JObject body = new();
            
            if (Amount > 0) body.Add("amount", Amount);
            if (!string.IsNullOrWhiteSpace(Language)) body.Add("language", Language);
            if (!string.IsNullOrWhiteSpace(ContinueUrl)) body.Add("continue_url", ContinueUrl);
            if (!string.IsNullOrWhiteSpace(CancelUrl)) body.Add("cancel_url", CancelUrl);
            if (!string.IsNullOrWhiteSpace(CallbackUrl)) body.Add("callback_url", CallbackUrl);
            if (AutoCapture) body.Add("auto_capture", "true");

            return HttpRequest.Put($"/payments/{PaymentId}/link", body);

        }

        #endregion

    }

}