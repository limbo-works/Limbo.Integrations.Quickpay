using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Limbo.Integrations.Quickpay.Models.Payments {
    
    /// <summary>
    /// Class representing a payment link as returned by the Quickpay API.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#GET-payments--id---format-</cref>
    /// </see>
    public class QuickpayPaymentLink : QuickpayPaymentLinkUrl {

        #region Properties

        /// <summary>
        /// Gets the two letter language code that determines the language of the payment window.
        /// </summary>
        public string Language { get; }

        /// <summary>
        /// Gets the mount to authorize
        /// </summary>
        public int Amount { get; }

        /// <summary>
        /// Gets the URL where cardholder is redirected after success.
        /// </summary>
        public string ContinueUrl { get; }

        /// <summary>
        /// Gets the URL where cardholder is redirected after cancel.
        /// </summary>
        public string CancelUrl { get; }

        /// <summary>
        /// Gets the endpoint for a POST callback.
        /// </summary>
        public string CallbackUrl { get; }

        /// <summary>
        /// Gets the payment methods.
        /// </summary>
        public string PaymentMethods { get; }

        /// <summary>
        /// If true, will capture the transaction after authorize succeeds.
        /// </summary>
        public bool AutoCapture { get; }

        /// <summary>
        /// The payment wil be captured on time corresponding to the timestamp.
        /// </summary>
        public EssentialsTime AutoCaptureAt { get; }

        /// <summary>
        /// Gets the branding to use in the payment window.
        /// </summary>
        public int? BrandingId { get; }

        /// <summary>
        /// Gets the version of payment window and API.
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// PayPal specific: Customer email.
        /// </summary>
        public string CustomerEmail { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected QuickpayPaymentLink(JObject json) : base(json) {
            Language = json.GetString("language");
            Amount = json.GetInt32("amount");
            ContinueUrl = json.GetString("continue_url");
            CancelUrl = json.GetString("cancel_url");
            CallbackUrl = json.GetString("callback_url");
            PaymentMethods = json.GetString("payment_methods");
            AutoCapture = json.GetBoolean("auto_capture");
            AutoCaptureAt = json.GetString("auto_capture_at", ParseTimestamp);
            BrandingId = json.HasValue("branding_id") ? json.GetInt32("branding_id") : null;
            Version = json.GetString("version");
            CustomerEmail = json.GetString("customer_email");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="QuickpayPaymentLink"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="QuickpayPaymentLink"/>.</returns>
        public static new QuickpayPaymentLink Parse(JObject json) {
            return json == null ? null : new QuickpayPaymentLink(json);
        }

        #endregion

    }

}