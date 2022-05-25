using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.Quickpay.Models.Payments {
    
    /// <summary>
    /// Class representing a payment link as returned by the Quickpay API.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#GET-payments--id---format-</cref>
    /// </see>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#PUT-payouts--id-link---format-</cref>
    /// </see>
    public class QuickpayPaymentLinkUrl : QuickpayObject {

        #region Properties

        /// <summary>
        /// Gets the URL to the payment window for this payment link.
        /// </summary>
        public string Url { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected QuickpayPaymentLinkUrl(JObject json) : base(json) {
            Url = json.GetString("url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="QuickpayPaymentLinkUrl"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="QuickpayPaymentLinkUrl"/>.</returns>
        public static QuickpayPaymentLinkUrl Parse(JObject json) {
            return json == null ? null : new QuickpayPaymentLinkUrl(json);
        }

        #endregion

    }

}